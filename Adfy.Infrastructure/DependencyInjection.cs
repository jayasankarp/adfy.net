using Adfy.Application.Abstractions.Data;
using Adfy.Application.Abstractions.Date;
using Adfy.Domain.Abstractions;
using Adfy.Domain.Advertisements;
using Adfy.Domain.Users;
using Adfy.Infrastructure.Data;
using Adfy.Infrastructure.Date;
using Adfy.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace Adfy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        AddPersistence(services, configuration);
        
        AddAuthentication(services);

        return services;
    }
    
    private static void AddAuthentication(IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        serviceCollection.AddAuthorizationBuilder();

        serviceCollection.AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
    }
    
    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));
    }
}