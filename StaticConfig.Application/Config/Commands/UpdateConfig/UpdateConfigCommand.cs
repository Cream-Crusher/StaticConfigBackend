using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Commands.UpdateConfig;

public class UpdateConfigCommand : IRequest<GetConfigResponse>
{
    public string Key { get; set; }
    public string Value { get; set; }
}