using EFCoreEncapsulate.Domain;
using EFCoreEncapsulate.Infrastructure.Configuration;
using EFCoreEncapsulate.Infrastructure.Repositories;
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

        Action<DbContextOptionsBuilder> optionsAction = options =>
        {
            options.UseSqlServer(connectionString,
                sqlOptions =>
                {
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
        }; 
        
        services.AddDbContext<SchoolContext>(optionsAction, ServiceLifetime.Scoped);

        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<ICourseRepository, CourseRepository>();

        // TODO: Why can't I register it as singleton?
        services.AddScoped<Messages>();

        services.AddHandlers();
        
        // services.AddTransient<ICommandHandler<EditStudentPersonalInfoCommand>>(provider => new AuditLoggingDecorator<EditStudentPersonalInfoCommand>(
        //     new DatabaseRetryDecorator<EditStudentPersonalInfoCommand>(
        //         new EditStudentPersonalInfoCommandHandler(
        //             provider.GetService<IStudentRepository>(),
        //             provider.GetService<SchoolContext>()))));
        //
        // services.AddTransient<ICommandHandler<RegisterStudentCommand>, RegisterStudentCommandHandler>();
        // services.AddTransient<ICommandHandler<EnrollInCourseCommand>, EnrollInCourseCommandHandler>();
        // services.AddTransient<IQueryHandler<GetStudentsQuery, Result<IReadOnlyList<StudentDto>>>, GetStudentsQueryHandler>();
        // services.AddTransient<IQueryHandler<GetStudentQuery, Result<StudentDto>>, GetStudentQueryHandler>();
        //
        // services.AddTransient<IQueryHandler<GetCoursesQuery, Result<IReadOnlyList<CourseDto>>>, GetCoursesQueryHandler>();
        // services.AddTransient<ICommandHandler<RegisterCourseCommand>, RegisterCourseCommandHandler>();
        
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
