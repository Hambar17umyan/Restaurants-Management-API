using DAL.Entities;
using DAL.Models;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using FluentResults;

namespace DAL.Repositories.Abstraction;

public interface IPlayerRepository
{
    Result<PlayerEntity> GetPlayerById(int id, PlayerQueryModel query);

    Result<PlayerEntity> GetPlayerById(int id);

    Result<QueryResult<PlayerEntity>> GetPlayersContainingInName(string name, PlayerQueryModel query);

    Result<QueryResult<PlayerEntity>> GetPlayersContainingInName(string name);

    Result<QueryResult<PlayerEntity>> GetPlayers(PlayerQueryModel query, int pageSize, int pageNumber);

    Result<QueryResult<PlayerEntity>> GetPlayers(int pageSize, int pageNumber);

    Result<int> AddPlayer(AddPlayerDto playerDto);
}
