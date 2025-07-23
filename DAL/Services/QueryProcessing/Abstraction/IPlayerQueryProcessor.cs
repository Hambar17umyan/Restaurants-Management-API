using DAL.Entities;
using DAL.Models.QueryModels;

namespace DAL.Services.QueryProcessing.Abstraction;

public interface IPlayerQueryProcessor
{
    IQueryable<PlayerEntity> Process(IQueryable<PlayerEntity> collection, PlayerQueryModel query);
}
