using Application.Utility;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyInjection
{
    public static class ServiceContainerApplication
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperApplicationProfile));
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(ServiceContainerApplication).Assembly);
            });

            return services;
        }
    }
}
