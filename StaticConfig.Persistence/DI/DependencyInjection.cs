using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StaticConfig.Application.Interfaces;
using StaticConfig.Persistence.Database;

namespace StaticConfig.Persistence.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;
        var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
        
        var mongoClient = new MongoClient(connectionString);

        services
            .AddDbContext<IRemoteConfigContext, RemoteConfigContext>(options => options
                .UseMongoDB(mongoClient, databaseName));

        return services;
    }
}