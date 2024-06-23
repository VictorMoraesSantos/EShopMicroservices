using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInsfrasctructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionSting = configuration.GetConnectionString("Database");

            return services;
        }
    }
}
