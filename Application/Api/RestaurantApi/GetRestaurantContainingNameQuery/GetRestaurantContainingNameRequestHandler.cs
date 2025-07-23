using Application.DTOs;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.GetRestaurantContainingNameQuery;

public class GetRestaurantContainingNameRequestHandler : IRequestHandler<GetRestaurantsContainingNameRequest, Result<GetRestaurantsContainingNameResponse>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public GetRestaurantContainingNameRequestHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Result<GetRestaurantsContainingNameResponse>> Handle(GetRestaurantsContainingNameRequest request, CancellationToken cancellationToken)
    {
        var RestaurantR = _restaurantRepository.GetRestaurantsContainingInName(request.Name);
        if (RestaurantR.IsFailed)
        {
            return Result.Fail(RestaurantR.Errors);
        }

        var Restaurant = RestaurantR.Value;

        var response = new GetRestaurantsContainingNameResponse
        {
            Restaurants = Restaurant.Records.Select(p => new GetRestaurantsContainingNameRecord
            {
                AddressId = p.AddressId!.Value,
                ClosingTime = p.ClosingTime!.Value,
                Id = p.Id!.Value,
                Name = p.Name!,
                OpenningTime = p.OpenningTime!.Value,
                PhoneNumber = p.PhoneNumber!
            }).ToList()
        };
        return response;
    }
}
