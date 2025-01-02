using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using StaticConfig.Application.Config.Queries;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.WebApi.Controllers;


[Route("[controller]")]
public class ConfigController(IMapper mapper) : BaseController
{
    [HttpGet("all")]
    public async Task<ActionResult<IList<GetConfigResponse>>> GetAll()
    {
        var query = new GetConfigListQuery();
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}