using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using StaticConfig.Domain;

namespace StaticConfig.Persistence.EntityTypeConfigurations;

public class ConfigConfiguration : IEntityTypeConfiguration<Config>
{
    private const string CONFIGS_COLLECTION  = "DatabaseSettings:ConfigsCollection";

    public void Configure(EntityTypeBuilder<Config> builder)
    {
        builder
            .ToCollection(CONFIGS_COLLECTION);

        builder
            .HasKey(config => config.Key);

        builder
            .Property(config => config.Key)
            .HasElementName("_id")
            .HasMaxLength(256);

        builder
            .Property(config => config.Value)
            .IsRequired()
            .HasMaxLength(512);

    }
}
