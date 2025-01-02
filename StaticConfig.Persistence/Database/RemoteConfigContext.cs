using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.EntityFrameworkCore.Extensions;
using StaticConfig.Application.Interfaces;
using StaticConfig.Domain;

namespace StaticConfig.Persistence.Database;

public class RemoteConfigContext(DbContextOptions<RemoteConfigContext> options, IConfiguration configuration)
    : DbContext(options), IRemoteConfigContext
{
    private const string CONFIGS_COLLECTION  = "DatabaseSettings:ConfigsCollection";

    public DbSet<Config> Configs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Config>()
            .ToCollection(configuration.GetSection(CONFIGS_COLLECTION).Value);
    }
}