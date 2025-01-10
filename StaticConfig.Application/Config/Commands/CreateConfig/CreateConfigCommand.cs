using MediatR;

namespace StaticConfig.Application.Config.Commands.CreateConfig;

public class CreateConfigCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}