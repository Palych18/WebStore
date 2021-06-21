using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entities.Identity;
using WebStore.Services;
using WebStore.Services.InCookies;
using WebStore.Services.InMemory;
using WebStore.Services.InSQL;
using WebStore.Services.Interfaces;

namespace WebStore
{
    public class Startup
    {      
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MSSQL")));
            services.AddTransient<WebStoreDBInitializer>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<WebStoreDB>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
                {
#if DEBUG
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredUniqueChars = 3;
#endif
                    opt.User.RequireUniqueEmail = false;
                    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

                    opt.Lockout.AllowedForNewUsers = false;
                    opt.Lockout.MaxFailedAccessAttempts = 10;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                });

            services.ConfigureApplicationCookie(opt => 
                {
                    opt.Cookie.Name = "WebStore.GB";
                    opt.Cookie.HttpOnly = true;
                    opt.ExpireTimeSpan = TimeSpan.FromDays(10);

                    opt.LoginPath = "/Account/Login";
                    opt.LogoutPath = "/Account/Logout";
                    opt.AccessDeniedPath = "/Account/AccessDenied";

                    opt.SlidingExpiration = true;
                });

            services.AddScoped<IEmployeesData, SqlEmployeesData>();
            services.AddScoped<ICartService, InCookiesCartService>();
            if(Configuration["ProductsDataSource"] == "db")            
                services.AddScoped<IProductData, SqlProductData>();
           else
                services.AddSingleton<IProductData, InMemoryProductData>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            using (var scope = services.CreateScope())
                scope.ServiceProvider.GetRequiredService<WebStoreDBInitializer>().Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {    
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
