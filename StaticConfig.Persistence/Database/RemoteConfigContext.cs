using Microsoft.EntityFrameworkCore;
using StaticConfig.Application.Interfaces;
using StaticConfig.Domain;
using StaticConfig.Persistence.EntityTypeConfigurations;

namespace StaticConfig.Persistence.Database;

public class RemoteConfigContext(DbContextOptions<RemoteConfigContext> options)
    : DbContext(options), IRemoteConfigContext
{
    public DbSet<Config> Configs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfigConfiguration());
    }
}