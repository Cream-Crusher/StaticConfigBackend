using MediatR;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigDictionaryQuery : IRequest<Dictionary<string, string>>
{

}