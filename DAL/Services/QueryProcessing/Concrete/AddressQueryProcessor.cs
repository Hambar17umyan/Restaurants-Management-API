using DAL.Entities;
using DAL.Models.QueryModels;
using DAL.Services.QueryProcessing.Abstraction;

namespace DAL.Services.QueryProcessing.Concrete;

public class AddressQueryProcessor : IAddressQueryProcessor
{
    public IQueryable<AddressEntity> Process(IQueryable<AddressEntity> collection, AddressQueryModel query)
    {
        if (query.Predicate != null)
        {
            collection = collection.Where(query.Predicate);
        }

        var projection = collection.Select(player => new AddressEntity
        {
            Id = query.SelectId ? player.Id : null,
            StreetName = query.SelectStreetName ? player.StreetName : null,
            City = query.SelectCity ? player.City : null,
            State = query.SelectState ? player.State : null,
            AddressLine1 = query.SelectAddressLine1 ? player.AddressLine1 : null,
            AddressLine2 = query.SelectAddressLine2 ? player.AddressLine2 : null,
            Country = query.SelectCountry ? player.Country : null,
            PostalCode = query.SelectPostalCode ? player.PostalCode : null
        });

        return projection;
    }
}
