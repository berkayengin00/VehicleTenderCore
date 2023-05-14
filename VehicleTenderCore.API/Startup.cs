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
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.BLL.Concrete;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Concrete;
using VehicleTenderCore.DAL.Context;
using Microsoft.AspNetCore.Http;

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
            services.AddScoped<IRetailCustomerDal, RetailCustomerDal>();
            services.AddScoped<ICorporateCustomer, CorporateCustomer>();
            services.AddScoped<IRetailCustomerService, RetailCustomerManager>();
            services.AddScoped<ITenderService, TenderManager>();
            services.AddScoped<ITenderDal, TenderDal>();
            services.AddScoped<IVehicleService, VehicleManager>();
            services.AddScoped<IVehicleDal, VehicleDal>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
