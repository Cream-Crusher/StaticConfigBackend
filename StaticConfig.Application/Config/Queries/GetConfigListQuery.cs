using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigListQuery : IRequest<List<GetConfigResponse>>
{

}