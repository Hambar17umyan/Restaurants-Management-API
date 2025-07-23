using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.AttachFavoriteRestaurantCommand;

public class AttachFavoriteRestaurantRequest : IRequest<Result<AttachFavoriteRestaurantResponse>>
{
    public int PlayerId { get; set; } 

    public int RestaurantId { get; set; }
}
