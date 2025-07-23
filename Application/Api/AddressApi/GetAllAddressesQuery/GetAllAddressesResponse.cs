using Application.Api.Common;
using Application.DTOs;

namespace Application.Api.AddressApi.GetAllAddressesQuery;

public class GetAllAddressesResponse : IResponse
{
    public IReadOnlyCollection<GetAllAddressesRecord> Addresses { get; set; } = new List<GetAllAddressesRecord>();
}
