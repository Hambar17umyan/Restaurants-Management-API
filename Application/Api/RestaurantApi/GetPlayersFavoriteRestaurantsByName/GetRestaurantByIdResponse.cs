using Application.Api.Common;
using Application.DTOs;

namespace Application.Api.RestaurantApi.GetPlayersFavoriteRestaurantsByName;

public class GetPlayersFavoriteRestaurantsByNameResponse : IResponse
{
    public IReadOnlyCollection<PlayerFavoritesDto> Records { get; set; } = Array.Empty<PlayerFavoritesDto>();
}

