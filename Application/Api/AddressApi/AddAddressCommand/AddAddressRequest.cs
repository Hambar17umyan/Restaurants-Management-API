using FluentResults;
using MediatR;

namespace Application.Api.AddressApi.AddAddressCommand;

public class AddAddressRequest : IRequest<Result<AddAddressResponse>>
{
    public string StreetName { get; set; } = string.Empty;

    public string AddressLine1 { get; set; } = string.Empty;

    public string AddressLine2 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;
}
