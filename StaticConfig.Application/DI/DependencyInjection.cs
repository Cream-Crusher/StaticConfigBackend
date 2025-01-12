using System.Reflection;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using StaticConfig.Application.Behaviors;

namespace StaticConfig.Application.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidatorBehavior<,>))
            .AddTransient(
                typeof(IRequestExceptionHandler<,,>),
                typeof(GlobalRequestExceptionHandler<,,>)
                );
}