using Application.Api.PlayerApi.AddPlayerCommand;
using FluentResults;

namespace Application.Services.Abstraction;

public interface IPlayerService
{
    Task<Result<AddPlayerResponse>> AddPlayerAsync(AddPlayerRequest request);
}
