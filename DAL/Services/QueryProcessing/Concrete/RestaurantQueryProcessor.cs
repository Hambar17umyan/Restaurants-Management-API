using DAL.Entities;
using DAL.Models.QueryModels;
using DAL.Services.QueryProcessing.Abstraction;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DAL.Services.QueryProcessing.Concrete;

public class RestaurantQueryProcessor : IRestaurantQueryProcessor
{
    public IQueryable<RestaurantEntity> Process(IQueryable<RestaurantEntity> collection, RestaurantQueryModel query)
    {
        if (query.Predicate != null)
        {
            collection = collection.Where(query.Predicate);
        }

        var projection = collection.Select(player => new RestaurantEntity
        {
            Id = query.SelectId ? player.Id : null,
            Name = query.SelectName ? player.Name : null,
            AddressId = query.SelectAddressId ? player.AddressId : null,
            PhoneNumber = query.SelectPhoneNumber ? player.PhoneNumber : null,
            OpenningTime = query.SelectOpenningTime ? player.OpenningTime : null,
            ClosingTime = query.SelectClosingTime ? player.ClosingTime : null,
            Address = query.IncludeAddress ? player.Address : null,
        });

        return projection;
    }

}
