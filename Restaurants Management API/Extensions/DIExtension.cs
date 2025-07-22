using DAL.Db;
using Domain.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Restaurants_Management_API.Services;

namespace Restaurants_Management_API.Extensions;

internal static class DIExtension
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        builder.RegisterDatabase();
        builder.Services.RegisterControllers()
            .RegisterSwagger()
            .RegisterRepositories()
            .RegisterServices()
            .RegisterMapper();
    }

    private static IServiceCollection RegisterDatabase(this WebApplicationBuilder builder)
    {
        return builder.Services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>()
            .AddDbContext<AppDbContext>(opt =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                opt.UseSqlite(connectionString);
            });
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        throw new NotImplementedException("Repository registration is not implemented yet.");
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        throw new NotImplementedException("Service registration is not implemented yet.");
    }

    private static IServiceCollection RegisterMapper(this IServiceCollection services)
    {
        throw new NotImplementedException("Mapper registration is not implemented yet.");
    }

    private static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        return services.AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }

    private static IServiceCollection RegisterControllers(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}
