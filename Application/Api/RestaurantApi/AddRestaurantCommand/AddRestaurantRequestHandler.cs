using Application.Services.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.AddRestaurantCommand;

public class AddRestaurantRequestHandler : IRequestHandler<AddRestaurantRequest, Result<AddRestaurantResponse>>
{
    private readonly IRestaurantService _restaurantService;

    public AddRestaurantRequestHandler(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public Task<Result<AddRestaurantResponse>> Handle(AddRestaurantRequest request, CancellationToken cancellationToken)
    {
        return _restaurantService.AddRestaurantAsync(request);
    }
}
