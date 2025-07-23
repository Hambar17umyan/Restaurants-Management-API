using DAL.Entities;
using DAL.Models.QueryModels;

namespace DAL.Services.QueryProcessing.Abstraction;

public interface IPlayerFavoriteRestaurantQueryProcessor
{
    IQueryable<PlayerFavoriteRestaurantEntity> Process(IQueryable<PlayerFavoriteRestaurantEntity> collection, PlayerFavoriteRestaurantQueryModel query);
}
