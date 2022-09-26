using EFCoreEncapsulate.Domain;
using EFCoreEncapsulate.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCoreEncapsulate.Infrastructure;

public static class ServiceRegistration 
{
      // This is a way to encapsulate DbContext (reduce number of possible config options, keeping invariants)
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,  string connectionString, bool useConsoleLogger)
    {
        services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();

        services.AddDbContext<SchoolContext>(options => {
             options.UseSqlServer(connectionString, 
             sqlOptions => {
                sqlOptions.MigrationsAssembly(typeof(ServiceRegistration).Assembly.FullName);
             });

            if (useConsoleLogger)
            {
                options
                    .UseLoggerFactory(CreateLoggerFactory())
                    .EnableSensitiveDataLogging();
            }
            else
            {
                options
                    .UseLoggerFactory(CreateEmptyLoggerFactory());
            }     
        });

        return services;
    }

    private static ILoggerFactory CreateEmptyLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((_, _) => false));
    }

    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
            .AddConsole());
    }
}