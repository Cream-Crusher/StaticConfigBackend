using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StaticConfig.Application.Config.Responses;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigDictionaryQueryHandler(IRemoteConfigContext dbContext, IMapper mapper)
    : IRequestHandler<GetConfigDictionaryQuery, Dictionary<string, string>>
{
    public async Task<Dictionary<string, string>> Handle(GetConfigDictionaryQuery request, CancellationToken cancellationToken)
    {
        var dictionary = await dbContext.Configs
            .ToDictionaryAsync(
                config => config.Key,
                config => config.Value,
                cancellationToken
                );

        return dictionary;
    }
}
