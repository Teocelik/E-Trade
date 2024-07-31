using E_Trade.DataAccess;
using E_Trade.DataAccess.Repositories;
using E_Trade.Models;
using E_Trade.Services.Concrete;
using E_Trade.Services.Implementations;
using E_Trade.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trade
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//Mvc dizayn pattern

            //Database connection
            services.AddDbContext<AppDbContext>(options => options.
            UseSqlServer(Configuration.GetConnectionString("SqlConnection")));


            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICartService, CartService>();


            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            services.AddHttpContextAccessor();
            services.AddSession();

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            #region K�lt�r ayarlar�n� yap�land�rma

            /*ASP.NET Core, �ok dilli ve �ok k�lt�rl� uygulamalar olu�turmay� kolayla�t�ran g��l� yerelle�tirme ve k�lt�r deste�i sa�lar.
              RequestLocalizationOptions s�n�f�, desteklenen k�lt�rleri ve dilleri belirlemenize olanak tan�r.
              UseRequestLocalization middleware'i, uygulaman�z�n isteklerin k�lt�r bilgilerini kullanarak do�ru �ekilde yan�t vermesini sa�lar.*/

            var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("tr-TR") };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            app.UseRequestLocalization(localizationOptions);

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
