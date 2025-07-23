using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.GetRestaurantContainingNameQuery;

public class GetRestaurantsContainingNameRequest : IRequest<Result<GetRestaurantsContainingNameResponse>>
{
    public string Name { get; set; } = string.Empty;
}
