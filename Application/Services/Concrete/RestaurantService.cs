using Application.Api.RestaurantApi.AddRestaurantCommand;
using Application.Api.RestaurantApi.GetRestaurantByIdQuery;
using Application.Services.Abstraction;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using FluentResults;

namespace Application.Services.Concrete;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Result<AddRestaurantResponse>> AddRestaurantAsync(AddRestaurantRequest request)
    {
        var res = this._restaurantRepository.AddRestaurant(new()
        {
            AddressId = request.AddressId,
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            OpenningTime = request.OpenningTime,
            ClosingTime = request.ClosingTime,
        });
        if (res.IsFailed)
        {
            return Result.Fail(res.Errors);
        }

        var response = new AddRestaurantResponse
        {
            Id = res.Value
        };

        return Result.Ok(response);
    }

    public async Task<Result<GetRestaurantByIdResponse>> GetRestaurantByIdAsync(int id)
    {
        var builder = new RestaurantQueryModel.Builder();
        var query = builder.SelectPhoneNumber()
               .SelectAddressId()
               .SelectPhoneNumber()
               .SelectOpenningTime()
               .SelectName()
               .SelectClosingTime()
               .SelectId()
               .IncludeAddress()
               .Build();
        var restaurant = _restaurantRepository.GetRestaurantById(id, query);
        if (restaurant.IsFailed)
        {
            return Result.Fail(restaurant.Errors);
        }

        var response = new GetRestaurantByIdResponse
        {
            Id = restaurant.Value.Id!.Value,
            Name = restaurant.Value.Name!,
            Address = new()
            {
                AddressLine1 = restaurant.Value.Address!.AddressLine1!,
                AddressLine2 = restaurant.Value.Address.AddressLine2 ?? string.Empty,
                City = restaurant.Value.Address.City!,
                State = restaurant.Value.Address.State!,
                PostalCode = restaurant.Value.Address.PostalCode!,
                Country = restaurant.Value.Address.Country!
            },
            PhoneNumber = restaurant.Value.PhoneNumber!,
            AddressId = restaurant.Value.Address.Id!.Value,
            ClosingTime = restaurant.Value.ClosingTime!.Value,
            OpenningTime = restaurant.Value.OpenningTime!.Value
        };

        return Result.Ok(response);
    }
}
