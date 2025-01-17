using Microsoft.Extensions.Configuration;
using StaticConfig.Persistence.Database;

namespace Static.Tests.Common;


public abstract class TestCommandBase : IDisposable
{
    protected readonly RemoteConfigContext Context;
    protected readonly IConfiguration Configuration;

    public TestCommandBase()
    {
        Context = ConfigsContextFactory.Create(Configuration);
    }

    public void Dispose()
    {
        ConfigsContextFactory.Destroy(Context);
    }
}