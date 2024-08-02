using Domain.Abstractions;
using Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.ContextDb;
using Persistence.Repositorys;

namespace Persistence.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ZacContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICategoriaAlimentoRepository, CategoriaAlimentoRepository>();
            services.AddScoped<IAlimentoRepository, AlimentoRepository>();
            return services;
        }
    }
}
