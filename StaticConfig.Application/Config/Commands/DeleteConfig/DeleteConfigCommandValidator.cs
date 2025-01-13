using FluentValidation;

namespace StaticConfig.Application.Config.Commands.DeleteConfig;

public class DeleteConfigCommandValidator : AbstractValidator<DeleteConfigCommand>
{
    public DeleteConfigCommandValidator()
    {
        RuleFor(c => c.Key)
            .NotEmpty()
            .NotNull();
    }
}