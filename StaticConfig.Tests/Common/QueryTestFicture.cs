using AutoMapper;
using StaticConfig.Application.Common.Mappings;
using StaticConfig.Persistence.Database;
using Xunit;

namespace Static.Tests.Common;

public class QueryTestFicture : IDisposable
{
    public RemoteConfigContext Context;
    public IMapper Mapper;

    public QueryTestFicture()
    {
        Context = ConfigsContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ConfigMappingProfile());
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        ConfigsContextFactory.Destroy(Context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFicture> { }
}