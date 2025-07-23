using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.AddRestaurantCommand;

public class AddRestaurantRequest : IRequest<Result<AddRestaurantResponse>>
{
    public string Name { get; set; } = string.Empty;

    public int AddressId { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public TimeOnly OpenningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }
}
