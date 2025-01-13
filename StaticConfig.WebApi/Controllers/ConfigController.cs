using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaticConfig.Application.Config.Commands.CreateConfig;
using StaticConfig.Application.Config.Commands.UpdateConfig;
using StaticConfig.Application.Config.Queries;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.WebApi.Controllers;


[Route("[controller]")]
public class ConfigController(IMapper mapper) : BaseController
{
    [HttpGet("all")]
    public async Task<ActionResult<Dictionary<string, string>>> GetAll()
    {
        var query = new GetConfigDictionaryQuery();
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<GetConfigResponse>> GetByKey(string key)
    {
        var query = new GetConfigQuery(key);
        var response = await Mediator.Send(query);
        return response.HasError ? StatusCode(response.StatusCode, response.Message) :
            Ok(response);
    }

    [HttpPost("")]
    public async Task<ActionResult<string>> CreateConfig([FromBody] CreateConfigCommand command)
    {
        var response = await Mediator.Send(command);
        return response.HasError ? StatusCode(response.StatusCode, response.Message) :
            Created($"[config/{response.Key}]", response.Key);
    }

    [HttpPut("")]
    public async Task<ActionResult> UpdateConfig([FromBody] UpdateConfigCommand command)
    {
        var response = await Mediator.Send(command);
        return response.HasError ? StatusCode(response.StatusCode, response.Message) :
            Ok();
    }
}