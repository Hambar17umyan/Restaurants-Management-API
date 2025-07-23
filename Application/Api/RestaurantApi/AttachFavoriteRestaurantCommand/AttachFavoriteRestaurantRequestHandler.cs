using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.AttachFavoriteRestaurantCommand;

public class AttachFavoriteRestaurantRequestHandler : IRequestHandler<AttachFavoriteRestaurantRequest, Result<AttachFavoriteRestaurantResponse>>
{
    private readonly IPlayerFavoriteRestaurantRepository _playerFavoriteRestaurantRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public AttachFavoriteRestaurantRequestHandler(IPlayerFavoriteRestaurantRepository playerFavoriteRestaurantRepository, IPlayerRepository playerRepository, IRestaurantRepository restaurantRepository)
    {
        _playerFavoriteRestaurantRepository = playerFavoriteRestaurantRepository;
        _playerRepository = playerRepository;
        _restaurantRepository = restaurantRepository;
    }

    public Task<Result<AttachFavoriteRestaurantResponse>> Handle(AttachFavoriteRestaurantRequest request, CancellationToken cancellationToken)
    {
        var q1 = new PlayerQueryModel.Builder()
            .SelectId()
            .Where(_ => true);
        var q2 = new RestaurantQueryModel.Builder()
            .SelectId()
            .Where(_ => true);

        var playerResult = _playerRepository.GetPlayerById(request.PlayerId, q1.Build());
        if (playerResult.IsFailed)
        {
            return Task.FromResult(Result.Fail<AttachFavoriteRestaurantResponse>(playerResult.Errors));
        }

        var restaurantResult = _restaurantRepository.GetRestaurantById(request.RestaurantId, q2.Build());
        if (restaurantResult.IsFailed)
        {
            return Task.FromResult(Result.Fail<AttachFavoriteRestaurantResponse>(restaurantResult.Errors));
        }

        var res = this._playerFavoriteRestaurantRepository.AddPlayerFavoriteRestaurant(new() { PlayerId = request.PlayerId, RestaurantId = request.RestaurantId });
        if (res.IsFailed)
        {
            return Task.FromResult(Result.Fail<AttachFavoriteRestaurantResponse>(res.Errors));
        }

        return Task.FromResult(Result.Ok(new AttachFavoriteRestaurantResponse()));
    }
}
