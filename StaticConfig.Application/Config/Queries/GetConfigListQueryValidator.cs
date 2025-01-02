using FluentValidation;
using StaticConfig.Application.Config.Queries;

namespace RemoteConfig.Application.Enemies.Queries;

public class GetConfigListQueryValidator : AbstractValidator<GetConfigListQuery>
{
    public GetConfigListQueryValidator()
    {

    }
}