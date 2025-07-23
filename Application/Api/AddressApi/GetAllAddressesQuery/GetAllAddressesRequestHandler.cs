using Application.Api.AddressApi.GetAllAddressesQuery;
using Application.Services.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.AddressApi.GetAddressQuery;

public class GetAllAddressesRequestHandler : IRequestHandler<GetAllAddressesRequest, Result<GetAllAddressesResponse>>
{
    private readonly IAddressService _addressService;

    public GetAllAddressesRequestHandler(IAddressService addressService)
    {
        this._addressService = addressService;
    }

    public async Task<Result<GetAllAddressesResponse>> Handle(GetAllAddressesRequest request, CancellationToken cancellationToken)
    {
        var id = this._addressService.GetAllAddresses(request.PageSize, request.PageNumber);
        if (id.IsFailed)
        {
            return Result.Fail(id.Errors);
        }

        return Result.Ok(new GetAllAddressesResponse
        {
            Addresses = id.Value
        });
    }
}
