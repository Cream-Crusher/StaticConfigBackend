using FluentValidation;

namespace StaticConfig.Application.Config.Commands.UpdateConfig;

public class UpdateConfigValidator : AbstractValidator<UpdateConfigCommand>
{
    public UpdateConfigValidator()
    {
        RuleFor(config => config.Key)
            .NotEmpty()
            .MaximumLength(64);
        RuleFor(config => config.Value)
            .NotEmpty()
            .MaximumLength(512);
    }
}