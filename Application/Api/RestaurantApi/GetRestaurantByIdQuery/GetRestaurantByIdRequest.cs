using FluentResults;
using MediatR;

namespace Application.Api.RestaurantApi.GetRestaurantByIdQuery;

public class GetRestaurantByIdRequest : IRequest<Result<GetRestaurantByIdResponse>>
{
    public int Id { get; set; }
}
