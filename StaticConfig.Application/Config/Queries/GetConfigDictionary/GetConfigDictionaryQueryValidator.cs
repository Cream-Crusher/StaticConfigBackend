using FluentValidation;
using StaticConfig.Application.Config.Queries;

namespace RemoteConfig.Application.Enemies.Queries;

public class GetConfigDictionaryQueryValidator : AbstractValidator<GetConfigDictionaryQuery>
{
    public GetConfigDictionaryQueryValidator()
    {

    }
}