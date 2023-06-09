using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.BLL.Concrete;
using VehicleTenderCore.BLL.Mapper;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Concrete;
using VehicleTenderCore.UI.Providers;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI
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
	        services.AddScoped<IApiProvider, ApiProviderBaseClass>();
	        services.AddHttpContextAccessor();
			services.AddHttpClient<LoginApiProvider>(x =>
            {
                x.BaseAddress = new Uri(Configuration["apiBaseUrl"]);
            });
            services.AddHttpClient<RetailCustomerApiProvider>(x =>
            {
                x.BaseAddress = new Uri(Configuration["apiBaseUrl"]);
            });
            services.AddHttpClient<TenderApiProvider>(x =>
            {
                x.BaseAddress = new Uri(Configuration["apiBaseUrl"]);
            });

            services.AddHttpClient<TenderDetailApiProvider>(x =>
            {
                x.BaseAddress = new Uri(Configuration["apiBaseUrl"]);
            });

            services.AddHttpClient<VehicleApiProvider>(x =>
            {
                x.BaseAddress = new Uri(Configuration["apiBaseUrl"]);
            });
            services.AddHttpClient<TenderHistoryApiProvider>(x =>
            {
                x.BaseAddress = new Uri(Configuration["apiBaseUrl"]);
            });
            
            services.AddSession(options =>
            {
                options.Cookie.Name = "MyApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddAutoMapper(typeof(TenderHistoryProfile));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	            .AddCookie(o => o.LoginPath = new PathString("/login/login"));

			services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/Error/Page{0}");
            
            app.UseStaticFiles();

            app.UseRouting();

			app.UseAuthentication();
			
			app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
