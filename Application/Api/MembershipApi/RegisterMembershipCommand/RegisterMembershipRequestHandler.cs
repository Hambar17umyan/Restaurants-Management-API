using DAL.Repositories.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.MembershipApi.RegisterMembershipCommand;

public class RegisterMembershipRequestHandler : IRequestHandler<RegisterMembershipRequest, Result<RegisterMembershipResponse>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RegisterMembershipRequestHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Result<RegisterMembershipResponse>> Handle(RegisterMembershipRequest request, CancellationToken cancellationToken)
    {
        var res = this._restaurantRepository.RegisterMembership(request.RestaurantId, request.PlayerId);
        if (res.IsFailed)
        {
            return Result.Fail(res.Errors);
        }

        return Result.Ok(new RegisterMembershipResponse());
    }
}
