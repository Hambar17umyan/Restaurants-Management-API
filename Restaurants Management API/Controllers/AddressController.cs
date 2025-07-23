using Application.Api.AddressApi.AddAddressCommand;
using Application.Api.AddressApi.GetAllAddressesQuery;
using Application.Services.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants_Management_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController(IMediator mediator, IResultHandlerService resultHandlerService) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IResultHandlerService _resultHandlerService = resultHandlerService;

    [HttpPost("add")]
    public async Task<IActionResult> AddCommentAsync(AddAddressRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }

    [HttpGet("get/all")]
    public async Task<IActionResult> GetAllAddressesAsgnc([FromQuery]GetAllAddressesRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }
}
