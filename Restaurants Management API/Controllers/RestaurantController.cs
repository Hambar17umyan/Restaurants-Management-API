using Application.Api.RestaurantApi.GetRestaurantByIdQuery;
using Application.Api.RestaurantApi.AddRestaurantCommand;
using Application.Services.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Api.RestaurantApi.GetRestaurantContainingNameQuery;
using Application.Api.RestaurantApi.GetPlayersFavoriteRestaurantsByName;
using Application.Api.RestaurantApi.AttachFavoriteRestaurantCommand;

namespace Restaurants_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IResultHandlerService _resultHandlerService;
    private readonly IMediator _mediator;

    public RestaurantController(IMediator mediator, IResultHandlerService resultHandlerService)
    {
        _mediator = mediator;
        _resultHandlerService = resultHandlerService;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetRestaurantByIdAsync([FromQuery]GetRestaurantByIdRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRestaurantAsync(AddRestaurantRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }
    

    [HttpPost("attach-favorite-restaurant")]
    public async Task<IActionResult> AttachFavoriteAsync(AttachFavoriteRestaurantRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }

    [HttpGet("get-containing-name")]
    public async Task<IActionResult> GetPLayersContainingNameAsync([FromQuery] GetRestaurantsContainingNameRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }

    [HttpGet("get-favorites-containing-name")]
    public async Task<IActionResult> GetPLayersContainingNameAsync([FromQuery] GetPlayersFavoriteRestaurantsByNameRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }
}
