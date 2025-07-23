using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.GetPlayersFavoriteRestaurantsByName;

public class GetPlayersFavoriteRestaurantsByNameRequest : IRequest<Result<GetPlayersFavoriteRestaurantsByNameResponse>>
{
    public string Name { get; set; } = "";
}
