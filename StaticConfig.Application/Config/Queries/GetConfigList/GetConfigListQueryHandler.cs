using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StaticConfig.Application.Config.Responses;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigListQueryHandler(IRemoteConfigContext dbContext, IMapper mapper)
    : IRequestHandler<GetConfigListQuery, IList<GetConfigResponse>>
{
    public async Task<IList<GetConfigResponse>> Handle(GetConfigListQuery request, CancellationToken cancellationToken)
    {
        var list = await dbContext.Configs
            .ToListAsync(cancellationToken);

        return mapper.Map<IList<GetConfigResponse>>(list);
    }
}
