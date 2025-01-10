using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigQuery(Guid id) : IRequest<GetConfigResponse>
{
    public Guid Id { get; set; } = id;
}
