using DAL.Entities;
using DAL.Models.QueryModels;
using DAL.Services.QueryProcessing.Abstraction;

namespace DAL.Services.QueryProcessing.Concrete;

public class PlayerFavoriteRestaurantQueryProcessor : IPlayerFavoriteRestaurantQueryProcessor
{
    public IQueryable<PlayerFavoriteRestaurantEntity> Process(IQueryable<PlayerFavoriteRestaurantEntity> collection, PlayerFavoriteRestaurantQueryModel query)
    {
        if (query.Predicate != null)
        {
            collection = collection.Where(query.Predicate);
        }

        var projection = collection.Select(player => new PlayerFavoriteRestaurantEntity
        {
            PlayerId = query.SelectPlayerId ? player.PlayerId : null,
            RestaurantId = query.SelectRestaurantId ? player.RestaurantId : null,
            Player = query.IncludePlayer ? player.Player : null,
            Restaurant = query.IncludeRestaurant ? player.Restaurant : null
        });

        return projection;
    }
}
