using FluentValidation;

namespace StaticConfig.Application.Config.Commands.CreateConfig;

public class CreateConfigValidator : AbstractValidator<CreateConfigCommand>
{
    public CreateConfigValidator()
    {
        RuleFor(config => config.Id)
            .NotEmpty();
        RuleFor(config => config.Key)
            .NotEmpty()
            .MaximumLength(64);
        RuleFor(config => config.Value)
            .NotEmpty()
            .MaximumLength(512);
    }
}