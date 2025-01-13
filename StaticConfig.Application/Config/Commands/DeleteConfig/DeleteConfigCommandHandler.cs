using AutoMapper;
using MediatR;
using StaticConfig.Application.Common.Exceptions;
using StaticConfig.Application.Config.Responses;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Commands.DeleteConfig;

public class DeleteConfigCommandHandler(IRemoteConfigContext dbContext, IMapper mapper) : IRequestHandler<DeleteConfigCommand, ErrorResponse>
{
    public async Task<ErrorResponse> Handle(DeleteConfigCommand command, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Configs.FindAsync(
            [command.Key],
            cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(entity), command.Key);

        dbContext.Configs.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ErrorResponse
        {
            HasError = false,
            StatusCode = 200
        };
    }
}