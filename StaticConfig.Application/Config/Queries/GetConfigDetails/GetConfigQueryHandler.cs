using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StaticConfig.Application.Common.Exceptions;
using StaticConfig.Application.Config.Responses;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigQueryHandler(IRemoteConfigContext dbContext, IMapper mapper) : IRequestHandler<GetConfigQuery, GetConfigResponse>
{
    public async Task<GetConfigResponse> Handle(GetConfigQuery request, CancellationToken cancellationToken)
    {
        var config = await dbContext.Configs.FirstOrDefaultAsync(
            c => c.Key == request.Key, cancellationToken);

        if (config == null)
        {
            throw new NotFoundException(nameof(Config), request.Key);
        }
        return mapper.Map<GetConfigResponse>(config);
    }
}