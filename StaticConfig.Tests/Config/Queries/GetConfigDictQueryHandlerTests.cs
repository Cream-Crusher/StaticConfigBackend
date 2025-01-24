using AutoMapper;
using Shouldly;
using Static.Tests.Common;
using StaticConfig.Application.Config.Queries;
using StaticConfig.Persistence.Database;
using Xunit;

namespace Static.Tests.Config.Queries;

[Collection("QueryCollection")]
public class GetConfigDictQueryHandlerTests : TestCommandBase
{
    private readonly RemoteConfigContext Context;
    private readonly IMapper Mapper;

    public GetConfigDictQueryHandlerTests(QueryTestFicture ficture)
    {
        Context = ficture.Context;
        Mapper = ficture.Mapper;
    }

    [Fact]
    public async Task GetConfigDictQueryHandler_Success()
    {
        // Arrange
        var handler = new GetConfigDictionaryQueryHandler(Context, Mapper);

        // Act
        var result = await handler.Handle(
            new GetConfigDictionaryQuery
                { }, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<Dictionary<string, string>>();
        result.Count.ShouldBe(4);
    }
}