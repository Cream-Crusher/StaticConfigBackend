using AutoMapper;
using MediatR;
using StaticConfig.Application.Config.Responses;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Commands.CreateConfig;

public class CreateConfigCommandHandler(IRemoteConfigContext dbContext, IMapper mapper) : IRequestHandler<CreateConfigCommand, GetConfigResponse>
{
    public async Task<GetConfigResponse> Handle(CreateConfigCommand request, CancellationToken cancellationToken)
    {
        var config = new Domain.Config()
        {
            Key = request.Key,
            Value = request.Value,
        };
        await dbContext.Configs.AddAsync(config, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<GetConfigResponse>(config);
    }
}
