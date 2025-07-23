using DAL.Entities;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using DAL.Models;
using FluentResults;

namespace DAL.Repositories.Abstraction;

public interface IRestaurantRepository
{
    Result<RestaurantEntity> GetRestaurantById(int id, RestaurantQueryModel query);

    Result<RestaurantEntity> GetRestaurantById(int id);

    Result<QueryResult<RestaurantEntity>> GetRestaurants(RestaurantQueryModel query, int pageSize, int pageNumber);

    Result<QueryResult<RestaurantEntity>> GetRestaurants(int pageSize, int pageNumber);

    Result<int> AddRestaurant(AddRestaurantDto playerDto);

    Result<QueryResult<RestaurantEntity>> GetRestaurantsContainingInName(string name, RestaurantQueryModel query);

    Result<QueryResult<RestaurantEntity>> GetRestaurantsContainingInName(string name);
}
