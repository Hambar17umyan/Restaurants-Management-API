using DAL.Db;
using DAL.Entities;
using DAL.Models;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using DAL.Services.QueryProcessing.Abstraction;
using FluentResults;

namespace DAL.Repositories.Concrete;

public class PlayerFavoriteRestaurantRepository : IPlayerFavoriteRestaurantRepository
{
    private readonly AppDbContext _dbContext;

    public PlayerFavoriteRestaurantRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly IPlayerFavoriteRestaurantQueryProcessor _playerFavoriteRestaurantQueryProcessor;

    public Result<int> AddPlayerFavoriteRestaurant(AddPlayerFavoriteRestaurantDto favDto)
    {
        throw new NotImplementedException();
    }

    public Result<QueryResult<PlayerFavoriteRestaurantEntity>> GetByPlayerId(int id, PlayerFavoriteRestaurantQueryModel query)
    {
        throw new NotImplementedException();
    }

    public Result<QueryResult<PlayerFavoriteRestaurantEntity>> GetByPlayerId(int id)
    {
        throw new NotImplementedException();
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
