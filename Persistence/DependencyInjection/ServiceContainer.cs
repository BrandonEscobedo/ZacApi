using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ZacContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
