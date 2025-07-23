using Application.Api.RestaurantApi.AddRestaurantCommand;
using Application.Api.RestaurantApi.GetRestaurantByIdQuery;
using FluentResults;

namespace Application.Services.Abstraction;

public interface IRestaurantService
{
    Task<Result<GetRestaurantByIdResponse>> GetRestaurantByIdAsync(int id);

    Task<Result<AddRestaurantResponse>> AddRestaurantAsync(AddRestaurantRequest request);
}
