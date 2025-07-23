using Application.Api.PlayerApi.AddPlayerCommand;
using Application.Api.PlayerApi.GetPlayerContainingNameQuery;
using Application.Services.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants_Management_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IResultHandlerService _resultHandlerService;

    public PlayerController(IMediator mediator, IResultHandlerService resultHandlerService)
    {
        _mediator = mediator;
        _resultHandlerService = resultHandlerService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddPlayer(AddPlayerRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }

    [HttpGet("get-containing-name")]
    public async Task<IActionResult> GetPLayersContainingNameAsync([FromQuery]GetPlayersContainingNameRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }
}
