using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using StaticConfig.Domain;
using StaticConfig.Persistence.Database;

namespace Static.Tests.Common;

public class ConfigsContextFactory
{
    public static string ConfigAKey = "ConfigAKey";
    public static string ConfigBKey = "ConfigBKey";

    public static string ConfigKeyForDelete = "ConfigKeyForDelete";
    public static string ConfigKeyForUpdate = "ConfigKeyForUpdate";

    public static RemoteConfigContext Create(IConfiguration configuration)
    {
        var options = new DbContextOptionsBuilder<RemoteConfigContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new RemoteConfigContext(options, configuration);

        context.Database.EnsureCreated();
        context.Configs.AddRange(
            new Config
            {
                Key = ConfigAKey,
                Value = "ValueA"
            },
            new Config
            {
                Key = ConfigBKey,
                Value = "ValueB"
            },
            new Config
            {
                Key = ConfigKeyForDelete,
                Value = "ValueForDelete"
            },
            new Config
            {
                Key = ConfigKeyForUpdate,
                Value = "ValueForUpdate"
            }
        );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(RemoteConfigContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
