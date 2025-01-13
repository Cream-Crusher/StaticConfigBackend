using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigQuery(string key) : IRequest<GetConfigResponse>
{
    public string Key { get; set; } = key;
}
