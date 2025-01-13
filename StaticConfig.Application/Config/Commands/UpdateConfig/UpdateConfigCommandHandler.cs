using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StaticConfig.Application.Common.Exceptions;
using StaticConfig.Application.Config.Responses;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Commands.UpdateConfig;

public class UpdateConfigCommandHandler(IRemoteConfigContext dbContext, IMapper mapper) : IRequestHandler<UpdateConfigCommand, GetConfigResponse>
{
    public async Task<GetConfigResponse> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Configs.FirstOrDefaultAsync(
            e=> e.Key == request.Key, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), request.Key);

        entity.Key = request.Key;
        entity.Value = request.Value;

        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<GetConfigResponse>(entity);
    }
}