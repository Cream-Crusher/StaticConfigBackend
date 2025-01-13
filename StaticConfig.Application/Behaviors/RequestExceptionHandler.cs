using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using StaticConfig.Application.Common.Exceptions;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Behaviors;

public class RequestExceptionHandler<TRequest, TResponse, TException>
    : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TResponse : ErrorResponse, new()
    where TException : Exception
{
    private readonly ILogger<RequestExceptionHandler<TRequest, TResponse, TException>> _logger;

    public RequestExceptionHandler(
        ILogger<RequestExceptionHandler<TRequest, TResponse, TException>> logger)
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
        var statusCode = exception switch
        {
            NotFoundException => 404,
            FluentValidation.ValidationException => 400,
            _ => 500
        };
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