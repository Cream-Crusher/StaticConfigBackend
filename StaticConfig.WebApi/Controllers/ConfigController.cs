using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaticConfig.Application.Config.Commands.CreateConfig;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<IList<GetConfigResponse>>> GetById(Guid id)
    {
        var query = new GetConfigQuery(id);
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("")]
    public async Task<ActionResult<Guid>> CreateEnemy([FromBody] CreateConfigCommand command)
    {
        var id = await Mediator.Send(command);
        return Created($"[config/{id}]", id);
    }
}