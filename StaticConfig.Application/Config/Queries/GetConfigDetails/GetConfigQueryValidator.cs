using FluentValidation;

namespace StaticConfig.Application.Config.Queries;

public class GetConfigQueryValidator : AbstractValidator<GetConfigQuery>
{
    public GetConfigQueryValidator()
    {
        RuleFor(query => query.Key)
            .NotEmpty()
            .NotNull();
    }
}