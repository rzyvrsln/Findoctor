using FindoctorData.DAL;
using FindoctorData.Extesions;
using FindoctorEntity.Entities;
using FindoctorService.Extensions;
using Microsoft.AspNetCore.Identity;
using Stripe;

namespace FindoctorWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("Stripe:ApiKey");
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.LoadDataLAyerExtension(builder.Configuration);
            builder.Services.LoadServiceLayerExtension();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}