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

public class PlayerFavoriteRestaurantRepository : IPlayerFavoriteRestaurantRepository
{
    private readonly AppDbContext _dbContext;

    public PlayerFavoriteRestaurantRepository(AppDbContext dbContext, IPlayerFavoriteRestaurantQueryProcessor playerFavoriteRestaurantQueryProcessor)
    {
        _dbContext = dbContext;
        _playerFavoriteRestaurantQueryProcessor = playerFavoriteRestaurantQueryProcessor;
    }

    private readonly IPlayerFavoriteRestaurantQueryProcessor _playerFavoriteRestaurantQueryProcessor;

    public Result AddPlayerFavoriteRestaurant(AddPlayerFavoriteRestaurantDto favDto)
    {
        var rec = this._dbContext.PlayerFavoriteRestaurants
            .FirstOrDefault(x => x.PlayerId == favDto.PlayerId && x.RestaurantId == favDto.RestaurantId);
        if (rec is not null)
        {
            return ResultHelper.ErrorResultWithMessage(ErrorType.FavoriteRestaurantAlreadyExists, "This restaurant is already in the player's favorites.");
        }

        try
        {
            var entity = new PlayerFavoriteRestaurantEntity() { PlayerId = favDto.PlayerId, RestaurantId = favDto.RestaurantId };
            this._dbContext.PlayerFavoriteRestaurants.Add(entity);
            this._dbContext.SaveChanges();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            throw new DbException(ex, DbExceptionType.CantAddFavRestaurant);
        }
    }

    public Result<QueryResult<PlayerFavoriteRestaurantEntity>> GetByPlayerId(int id, PlayerFavoriteRestaurantQueryModel query)
    {
        throw new NotImplementedException();
    }

    public Result<QueryResult<PlayerFavoriteRestaurantEntity>> GetByPlayerId(int id)
    {
        return new QueryResult<PlayerFavoriteRestaurantEntity>(this._dbContext.PlayerFavoriteRestaurants.Where(x => x.PlayerId == id).ToList());
    }

    public Result<QueryResult<PlayerEntity>> GetPlayerFavoriteRestaurants(PlayerFavoriteRestaurantQueryModel query, int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Result<QueryResult<PlayerEntity>> GetPlayerFavoriteRestaurants(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }
}
