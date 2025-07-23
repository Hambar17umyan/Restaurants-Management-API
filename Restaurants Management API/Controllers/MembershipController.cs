using Application.Api.MembershipApi.GetMembershipsByMinAgeQuery;
using Application.Api.MembershipApi.RegisterMembershipCommand;
using Application.Services.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class MembershipController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IResultHandlerService _resultHandlerService;

    public MembershipController(IMediator mediator, IResultHandlerService resultHandlerService)
    {
        _mediator = mediator;
        _resultHandlerService = resultHandlerService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterMembershipRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }

    [HttpGet]
    public async Task<IActionResult> GetMemberships([FromQuery]GetMembershipsByMinAgeRequest request)
    {
        var res = await this._mediator.Send(request);
        var response = this._resultHandlerService.HandleResult(res);
        return this.StatusCode((int)response.Error, response.Response);
    }
}
