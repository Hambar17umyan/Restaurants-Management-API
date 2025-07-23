using Application.Services.Abstraction;
using DAL.Models.QueryModels;
using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.GetRestaurantByIdQuery;

public class GetRestaurantByIdRequestHandler : IRequestHandler<GetRestaurantByIdRequest, Result<GetRestaurantByIdResponse>>
{
    private readonly IRestaurantService _restaurantService;

    public GetRestaurantByIdRequestHandler(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public async Task<Result<GetRestaurantByIdResponse>> Handle(GetRestaurantByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _restaurantService.GetRestaurantByIdAsync(request.Id);
        return result;
    }
}
