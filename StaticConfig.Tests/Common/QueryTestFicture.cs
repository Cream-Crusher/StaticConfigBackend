using AutoMapper;
using Microsoft.Extensions.Configuration;
using StaticConfig.Application.Common.Mappings;
using StaticConfig.Application.Interfaces;
using StaticConfig.Persistence.Database;
using Xunit;

namespace Static.Tests.Common;

public class QueryTestFicture : IDisposable
{
    private IConfiguration _configuration;
    public RemoteConfigContext Context;
    public IMapper Mapper;

    public QueryTestFicture()
    {
        Context = ConfigsContextFactory.Create(_configuration);
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