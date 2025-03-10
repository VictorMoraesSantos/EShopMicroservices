﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Database")!;

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new AuditableEntityInterceptors());
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
