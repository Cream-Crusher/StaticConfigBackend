using System.ComponentModel.DataAnnotations;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using StaticConfig.Application.Common.Exceptions;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Behaviors;

public class GlobalRequestExceptionHandler<TRequest, TResponse, TException>
    : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TResponse : BaseResponse, new()
    where TException : Exception
{
    private readonly ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> _logger;

    public GlobalRequestExceptionHandler(
        ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }

    public Task Handle(
        TRequest request,
        TException exception,
        RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken
        )
    {
        int statusCode;
        switch (exception)
        {
            case NotFoundException:
                statusCode = 404;
                break;
            case FluentValidation.ValidationException:
                statusCode = 400;
                break;
            default:
                statusCode = 500;
                break;
        }
        _logger.LogError(
            exception,
            "Request error: {@requestType}",
            typeof(TRequest)
        );

        var response = new TResponse
        {
            HasError = true,
            StatusCode = statusCode,
            Message = exception.Message,
        };
        state.SetHandled(response);
        return Task.CompletedTask;
    }
}