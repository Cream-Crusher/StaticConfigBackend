using MediatR;
using StaticConfig.Application.Interfaces;

namespace StaticConfig.Application.Config.Commands.CreateConfig;

public class CreateConfigCommandHandler(IRemoteConfigContext dbContext) : IRequestHandler<CreateConfigCommand, Guid>
{
    public async Task<Guid> Handle(CreateConfigCommand request, CancellationToken cancellationToken)
    {
        var config = new Domain.Config()
        {
            Id = Guid.NewGuid(),

            Key = request.Key,
            Value = request.Value,
            CreatedAt = DateTime.Now,
            Active = true
        };
        await dbContext.Configs.AddAsync(config, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return config.Id;
    }
}
