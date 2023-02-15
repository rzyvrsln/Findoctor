using FindoctorService.Services;
using FindoctorService.Validations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace FindoctorService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            //services.AddControllersWithViews().AddFluentValidation(opt =>
            //{
            //    opt.RegisterValidatorsFromAssemblyContaining<CategoryValidation>();
            //    opt.DisableDataAnnotationsValidation = true;
            //    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("az");
            //});

            return services;
        }
    }
}
