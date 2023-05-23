using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.BLL.Concrete;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Concrete;
using VehicleTenderCore.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using VehicleTenderCore.BLL.Mapper;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<EfVehicleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("myConnection")));
			services.AddHangfire(config =>
				{
					config.UseSqlServerStorage("Server=.;Database=HangDB;Trusted_Connection=true;");
					RecurringJob.AddOrUpdate<TenderHistoryDal>(x => x.Test2(), Cron.MinuteInterval(1));
					RecurringJob.AddOrUpdate<HangfireDal>(x => x.CheckTenderStatus(), Cron.Daily(19, 58));
				});
			services.AddHangfireServer();
			services.AddScoped<IRetailCustomerDal, RetailCustomerDal>();
			services.AddScoped<ICorporateCustomerDal, CorporateCustomerDal>();
			services.AddScoped<IRetailCustomerService, RetailCustomerManager>();
			services.AddScoped<ITenderService, TenderManager>();
			services.AddScoped<ITenderDal, TenderDal>();
			services.AddScoped<IVehicleService, VehicleManager>();
			services.AddScoped<IVehicleDal, VehicleDal>();
			services.AddScoped<ITenderHistoryService, TenderHistoryManager>();
			services.AddScoped<ITenderHistoryDal, TenderHistoryDal>();
			services.AddScoped<ICorporateCustomerService, CorporateCustomerManager>();
			services.AddScoped<IRetailCustomerService, RetailCustomerManager>();
			services.AddScoped<HangfireDal>();
			services.AddAutoMapper(typeof(TenderHistoryProfile));
			services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
			{
				option.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["Token:Issuer"],
					ValidAudience = Configuration["Token:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseHangfireServer();
			app.UseHangfireDashboard();
			app.UseRouting();
			app.UseAuthentication();

			app.UseAuthorization();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
