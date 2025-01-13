using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Commands.DeleteConfig;

public class DeleteConfigCommand : IRequest<ErrorResponse>
{
    public string Key { get; set; }
}