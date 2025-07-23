using DAL.Entities;
using DAL.Models.QueryModels;

namespace DAL.Services.QueryProcessing.Abstraction;

public interface IAddressQueryProcessor
{
    IQueryable<AddressEntity> Process(IQueryable<AddressEntity> collection, AddressQueryModel query);
}
