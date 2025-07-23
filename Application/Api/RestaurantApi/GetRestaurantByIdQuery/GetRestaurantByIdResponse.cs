using Application.Api.Common;
using Application.DTOs;

namespace Application.Api.RestaurantApi.GetRestaurantByIdQuery;

public class GetRestaurantByIdResponse : IResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int AddressId { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public TimeOnly OpenningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public GetRestaurantByIdAddressRecord? Address { get; set; }
}
