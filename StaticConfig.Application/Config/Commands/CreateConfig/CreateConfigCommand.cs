using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Commands.CreateConfig;

public class CreateConfigCommand : IRequest<GetConfigResponse>
{
    public string Key { get; set; }
    public string Value { get; set; }
}