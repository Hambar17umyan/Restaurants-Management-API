using DAL.Db;
using DAL.Entities;
using DAL.Models;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using DAL.Services.QueryProcessing.Abstraction;
using Domain.Exceptions.Db;
using Domain.Infrastructure.ResultModels;
using FluentResults;

namespace DAL.Repositories.Concrete;

public class PlayerRepository(AppDbContext dbContext, IPlayerQueryProcessor playerQueryProcessor) : IPlayerRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IPlayerQueryProcessor _playerQueryProcessor = playerQueryProcessor;

    public Result<int> AddPlayer(AddPlayerDto playerDto)
    {
        var entity = new PlayerEntity
        {
            Name = playerDto.Name,
            DateOfBirth = playerDto.DateOfBirth,
            PhoneNumber = playerDto.PhoneNumber,
            Email = playerDto.Email,
            DriverLicenseNumber = playerDto.DriverLicenseNumber,
            PassportNumber = playerDto.PassportNumber,
            PrimaryAddressId = playerDto.PrimaryAddressId,
            AlternateAddressId = playerDto.AlternateAddressId,
            OfficeAddressId = playerDto.OfficeAddressId
        };
        try
        {
            this._dbContext.Players.Add(entity);
            this._dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DbException(ex, DbExceptionType.CantAddPlayer);
        }

        return Result.Ok(entity.Id!.Value);
    }

    public Result<PlayerEntity> GetPlayerById(int id, PlayerQueryModel query)
    {
        var res = this._playerQueryProcessor.Process(this._dbContext.Players.Where(x=>x.Id == id), query);
        var player = res.FirstOrDefault();
        if (player == null)
        {
            return ResultHelper.ErrorResultWithMessage<PlayerEntity>(ErrorType.PlayerByIdNotFound, "Player with specified id not found.");
        }

        return Result.Ok(player);
    }

    public Result<PlayerEntity> GetPlayerById(int id)
    {
        return this.GetPlayerById(id, PlayerQueryModel.Default);
    }

    public Result<QueryResult<PlayerEntity>> GetPlayers(PlayerQueryModel query, int pageSize, int pageNumber)
    {
        var res = this._playerQueryProcessor.Process(this._dbContext.Players.Skip(pageSize * (pageNumber - 1)).Take(pageSize), query);
        var ret = new QueryResult<PlayerEntity>(res.ToList());
        return Result.Ok(ret);
    }

    public Result<QueryResult<PlayerEntity>> GetPlayers(int pageSize, int pageNumber)
    {
        return this.GetPlayers(PlayerQueryModel.Default, pageSize, pageNumber);
    }

    public Result<QueryResult<PlayerEntity>> GetPlayersContainingInName(string name, PlayerQueryModel query)
    {
        var res = this._playerQueryProcessor.Process(this._dbContext.Players.Where(x => x.Name!.ToLower()!.Contains(name.ToLower())), query);
        var ret = new QueryResult<PlayerEntity>(res.ToList());
        return Result.Ok(ret);
    }

    public Result<QueryResult<PlayerEntity>> GetPlayersContainingInName(string name)
    {
        return this.GetPlayersContainingInName(name, PlayerQueryModel.Default);
    }
}
