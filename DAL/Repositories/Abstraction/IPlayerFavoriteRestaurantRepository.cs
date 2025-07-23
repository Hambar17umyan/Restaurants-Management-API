using DAL.Entities;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using DAL.Models;
using FluentResults;

namespace DAL.Repositories.Abstraction;

public interface IPlayerFavoriteRestaurantRepository
{
    Result<QueryResult<PlayerFavoriteRestaurantEntity>> GetByPlayerId(int id, PlayerFavoriteRestaurantQueryModel query);

    Result<QueryResult<PlayerFavoriteRestaurantEntity>> GetByPlayerId(int id);

    Result<QueryResult<PlayerEntity>> GetPlayerFavoriteRestaurants(PlayerFavoriteRestaurantQueryModel query, int pageSize, int pageNumber);

    Result<QueryResult<PlayerEntity>> GetPlayerFavoriteRestaurants(int pageSize, int pageNumber);

    Result AddPlayerFavoriteRestaurant(AddPlayerFavoriteRestaurantDto favDto);
}
