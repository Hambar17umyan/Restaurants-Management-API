using DAL.Entities;
using DAL.Models.QueryModels;

namespace DAL.Services.QueryProcessing.Abstraction;

public interface IRestaurantQueryProcessor
{
    IQueryable<RestaurantEntity> Process(IQueryable<RestaurantEntity> collection, RestaurantQueryModel query);
}
