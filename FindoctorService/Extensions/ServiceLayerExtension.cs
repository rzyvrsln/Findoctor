using FindoctorService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindoctorService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            return services;
        }
    }
}
