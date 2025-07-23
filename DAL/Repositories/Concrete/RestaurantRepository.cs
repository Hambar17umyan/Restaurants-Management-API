using DAL.Db;
using DAL.Entities;
using DAL.Models;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using DAL.Services.QueryProcessing.Abstraction;
using Domain.Exceptions.Db;
using Domain.Infrastructure.ResultModels;
using FluentResults;

namespace DAL.Repositories.Concrete;

public class RestaurantRepository(AppDbContext dbContext, IRestaurantQueryProcessor restaurantQueryProcessor) : IRestaurantRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IRestaurantQueryProcessor _restaurantQueryProcessor = restaurantQueryProcessor;

    public Result<int> AddRestaurant(AddRestaurantDto playerDto)
    {
        var entity = new RestaurantEntity
        {
            AddressId = playerDto.AddressId,
            Name = playerDto.Name,
            PhoneNumber = playerDto.PhoneNumber,
            OpenningTime = playerDto.OpenningTime,
            ClosingTime = playerDto.ClosingTime
        };
        try
        {
            this._dbContext.Restaurants.Add(entity);
            this._dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DbException(ex, DbExceptionType.CantAddRestaurant);
        }

        return Result.Ok(entity.Id!.Value);
    }

    public Result<RestaurantEntity> GetRestaurantById(int id, RestaurantQueryModel query)
    {
        var res = this._restaurantQueryProcessor.Process(this._dbContext.Restaurants.Where(x => x.Id == id), query);
        var player = res.FirstOrDefault();
        if (player == null)
        {
            return ResultHelper.ErrorResultWithMessage<RestaurantEntity>(ErrorType.RestaurantByIdNotFound, "Restaurant with specified id not found.");
        }

        return Result.Ok(player);
    }

    public Result<RestaurantEntity> GetRestaurantById(int id)
    {
        return this.GetRestaurantById(id,RestaurantQueryModel.Default);
    }

    public Result<QueryResult<RestaurantEntity>> GetRestaurants(RestaurantQueryModel query, int pageSize, int pageNumber)
    {
        var res = this._restaurantQueryProcessor.Process(this._dbContext.Restaurants.Skip(pageSize * (pageNumber - 1)).Take(pageSize), query);
        var ret = new QueryResult<RestaurantEntity>(res.ToList());
        return Result.Ok(ret);
    }

    public Result<QueryResult<RestaurantEntity>> GetRestaurants(int pageSize, int pageNumber)
    {
        return this.GetRestaurants(RestaurantQueryModel.Default, pageSize, pageNumber);
    }

    public Result<QueryResult<RestaurantEntity>> GetRestaurantsContainingInName(string name, RestaurantQueryModel query)
    {
        var res = this._restaurantQueryProcessor.Process(this._dbContext.Restaurants.Where(x => x.Name!.ToLower()!.Contains(name.ToLower())), query);
        var ret = new QueryResult<RestaurantEntity>(res.ToList());
        return Result.Ok(ret);
    }

    public Result<QueryResult<RestaurantEntity>> GetRestaurantsContainingInName(string name)
    {
        return this.GetRestaurantsContainingInName(name, RestaurantQueryModel.Default);
    }
}
