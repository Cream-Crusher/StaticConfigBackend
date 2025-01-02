using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StaticConfig.WebApi.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/1/[controller]")]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediatr;

    protected IMediator Mediator =>
        _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();
}