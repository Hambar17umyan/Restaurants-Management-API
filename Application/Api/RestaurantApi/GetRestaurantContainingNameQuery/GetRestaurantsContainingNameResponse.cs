using Application.Api.Common;
using Application.DTOs;

namespace Application.Api.RestaurantApi.GetRestaurantContainingNameQuery;

public class GetRestaurantsContainingNameResponse : IResponse
{
    public IReadOnlyCollection<GetRestaurantsContainingNameRecord> Restaurants { get; set; } = [];
}
