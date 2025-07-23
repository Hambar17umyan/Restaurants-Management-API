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
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public Result<QueryResult<RestaurantMembershipEntity>> GetMembershipsByMinAge(int restaurantId, int minAge)
    {
        var rest = this.GetRestaurantById(restaurantId, new RestaurantQueryModel.Builder()
            .SelectId()
            .Where(x => true)
            .Build());
        if (rest.IsFailed)
        {
            return ResultHelper.ErrorResultWithMessage<QueryResult<RestaurantMembershipEntity>>(ErrorType.RestaurantByIdNotFound, "Restaurant with specified id not found.");
        }

        var joined = this._dbContext.RestaurantMemberships
        .Where(x => x.RestaurantId == restaurantId)
        .Join(this._dbContext.Players,
            membership => membership.PlayerId,
            player => player.Id,
            (membership, player) => new { membership, player });

        var res = new QueryResult<RestaurantMembershipEntity>(
        joined
        .Where(x => ((DateOnly.FromDateTime(DateTime.Today)).Year - x.player.DateOfBirth!.Value.Year >= minAge))
        .Select(x => x.membership)
                .ToList()
        );

        return Result.Ok(res);
    }

    public Result<QueryResult<RestaurantMembershipEntity>> GetMembershipsByRestaurant(int restaurantId)
    {
        var memberships = this._dbContext.RestaurantMemberships
            .Where(x => x.RestaurantId == restaurantId)
            .ToList();

        var queryResult = new QueryResult<RestaurantMembershipEntity>(memberships);
        return Result.Ok(queryResult);
    }

    public Result<QueryResult<RestaurantMembershipEntity>> GetMembershipsByRestaurantWhere(int restaurantId, Expression<Func<RestaurantMembershipEntity, bool>> predicate)
    {
        var memberships = this._dbContext.RestaurantMemberships
            .Where(x => x.RestaurantId == restaurantId)
            .Where(predicate)
            .ToList();

        var queryResult = new QueryResult<RestaurantMembershipEntity>(memberships);
        return Result.Ok(queryResult);
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
        return this.GetRestaurantById(id, RestaurantQueryModel.Default);
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

    public Result RegisterMembership(int restaurantId, int playerId)
    {
        var query = new RestaurantQueryModel.Builder()
            .SelectId()
            .Where(x => true)
            .Build();
        var restaurant = this.GetRestaurantById(restaurantId, query);
        if (restaurant.IsFailed)
        {
            return ResultHelper.ErrorResultWithMessage(ErrorType.RestaurantByIdNotFound, "Restaurant with specified id not found.");
        }

        var player = this._dbContext.Players.Find(playerId);
        if (player == null)
        {
            return ResultHelper.ErrorResultWithMessage(ErrorType.PlayerByIdNotFound, "Player with specified id not found.");
        }

        var membership = this._dbContext.RestaurantMemberships.FirstOrDefault(x => x.RestaurantId == restaurant.Value.Id && x.PlayerId == playerId);
        if (membership != null)
        {
            return ResultHelper.ErrorResultWithMessage(ErrorType.RestaurantMembershipAlreadyExists, "Restaurant membership already exists.");
        }

        membership = new RestaurantMembershipEntity
        {
            RestaurantId = restaurant.Value.Id,
            PlayerId = playerId
        };
        this._dbContext.RestaurantMemberships.Add(membership);
        try
        {
            this._dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DbException(ex, DbExceptionType.CantAddRestaurantMembership);
        }

        return Result.Ok();
    }
}
