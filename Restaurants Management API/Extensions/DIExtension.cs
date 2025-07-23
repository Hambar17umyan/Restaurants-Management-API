using Application.Api.AddressApi.AddAddressCommand;
using Application.Api.AddressApi.GetAllAddressesQuery;
using Application.Services.Abstraction;
using Application.Services.Concrete;
using DAL.Db;
using DAL.Repositories.Abstraction;
using DAL.Repositories.Concrete;
using DAL.Services.QueryProcessing.Abstraction;
using DAL.Services.QueryProcessing.Concrete;
using Domain.Infrastructure.Contracts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Restaurants_Management_API.Services;
using System.Reflection;

namespace Restaurants_Management_API.Extensions;

internal static class DIExtension
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        builder.RegisterDatabase();
        builder.RegisterLogger();
        builder.Services.RegisterControllers()
            .RegisterSwagger()
            .RegisterRepositories()
            .RegisterServices()
            .RegisterMediator()
            .RegisterValidators();
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

    private static WebApplicationBuilder RegisterLogger(this WebApplicationBuilder builder)
    {
        _ = builder.Logging.ClearProviders();
        _ = builder.Logging.AddConsole();
        _ = builder.Logging.AddDebug();
        return builder;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IPlayerRepository, PlayerRepository>()
            .AddScoped<IPlayerQueryProcessor, PlayerQueryProcessor>()
            .AddScoped<IRestaurantRepository, RestaurantRepository>()
            .AddScoped<IRestaurantQueryProcessor, RestaurantQueryProcessor>()
            .AddScoped<IPlayerFavoriteRestaurantRepository, PlayerFavoriteRestaurantRepository>()
            .AddScoped<IPlayerFavoriteRestaurantQueryProcessor, PlayerFavoriteRestaurantQueryProcessor>()
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<IAddressQueryProcessor, AddressQueryProcessor>()
            .AddScoped<ICreateFailService, CreateFailService>();
    }

    private static IServiceCollection RegisterMediator(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddMediatR(builder => builder.RegisterServicesFromAssembly(typeof(AddAddressRequestHandler).Assembly));
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services.AddScoped<IResultHandlerService, ResultHandlerService>()
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<IRestaurantService, RestaurantService>()
            .AddScoped<IPlayerService, PlayerService>();
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

    private static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        var assemblies = new List<Assembly>
        {
            typeof(AddAddressValidator).Assembly,
        };
        _ = services.AddFluentValidationAutoValidation();
        _ = services.AddFluentValidationAutoValidation();
        _ = services.AddValidatorsFromAssemblies(assemblies);
        return services;
    }
}
