using Application.Services.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.PlayerApi.AddPlayerCommand;

public class AddPlayerRequestHandler : IRequestHandler<AddPlayerRequest, Result<AddPlayerResponse>>
{
    private readonly IPlayerService _playerService;

    public AddPlayerRequestHandler(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    public async Task<Result<AddPlayerResponse>> Handle(AddPlayerRequest request, CancellationToken cancellationToken)
    {
        return await _playerService.AddPlayerAsync(request);
    }
}