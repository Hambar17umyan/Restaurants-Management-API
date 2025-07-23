using Application.DTOs;
using Application.Services.Abstraction;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using Domain.Infrastructure.ResultModels;
using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.GetPlayersFavoriteRestaurantsByName;

public class GetPlayersFavoriteRestaurantsByNameRequestHandler : IRequestHandler<GetPlayersFavoriteRestaurantsByNameRequest, Result<GetPlayersFavoriteRestaurantsByNameResponse>>
{
    private readonly IRestaurantService _restaurantService;
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayerFavoriteRestaurantRepository _playerFavoriteRepository;

    public GetPlayersFavoriteRestaurantsByNameRequestHandler(IRestaurantService restaurantService, IPlayerRepository playerRepository, IPlayerFavoriteRestaurantRepository playerFavoriteRepository)
    {
        _restaurantService = restaurantService;
        _playerRepository = playerRepository;
        _playerFavoriteRepository = playerFavoriteRepository;
    }

    public async Task<Result<GetPlayersFavoriteRestaurantsByNameResponse>> Handle(
    GetPlayersFavoriteRestaurantsByNameRequest request,
    CancellationToken cancellationToken)
    {
        var players = _playerRepository.GetPlayersContainingInName(request.Name);
        if (players.IsFailed)
            return Result.Fail(players.Errors);

        var list = players.Value.Records
            .Select(x => new PlayerFavoritesDto
            {
                PlayerId = x.Id!.Value,
                PlayerName = x.Name!,
                RestaurantIds = new List<int>()
            })
            .ToList();

        for (int i = 0; i < list.Count; i++)
        {
            var dto = list[i];
            var favs = _playerFavoriteRepository.GetByPlayerId(dto.PlayerId);
            if (favs.IsSuccess)
            {
                dto.RestaurantIds = favs.Value.Records
                                        .Select(fr => fr.RestaurantId!.Value)
                                        .ToList();
            }
        }

        return Result.Ok(new GetPlayersFavoriteRestaurantsByNameResponse
        {
            Records = list
        });
    }
}
