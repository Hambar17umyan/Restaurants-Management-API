using Application.Services.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.AddressApi.AddAddressCommand;

public class AddAddressRequestHandler : IRequestHandler<AddAddressRequest, Result<AddAddressResponse>>
{
    private readonly IAddressService _addressService;

    public AddAddressRequestHandler(IAddressService addressService)
    {
        this._addressService = addressService;
    }

    public async Task<Result<AddAddressResponse>> Handle(AddAddressRequest request, CancellationToken cancellationToken)
    {
        var id = this._addressService.AddAddress(request);
        return Result.Ok(new AddAddressResponse
        {
            Id = id.Value
        });
    }
}
