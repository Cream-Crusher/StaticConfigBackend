using Microsoft.Extensions.Configuration;
using StaticConfig.Persistence.Database;

namespace Static.Tests.Common;


public abstract class TestCommandBase : IDisposable
{
    protected readonly RemoteConfigContext Context;

    public TestCommandBase()
    {
        Context = ConfigsContextFactory.Create();
    }

    public void Dispose()
    {
        ConfigsContextFactory.Destroy(Context);
    }
}