using Application.DTOs;
using DAL.Repositories.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.MembershipApi.GetMembershipsByMinAgeQuery;

public class GetMembershipsByMinAgeRequestHandler : IRequestHandler<GetMembershipsByMinAgeRequest, Result<GetMembershipsByMinAgeResponse>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public GetMembershipsByMinAgeRequestHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Result<GetMembershipsByMinAgeResponse>> Handle(GetMembershipsByMinAgeRequest request, CancellationToken cancellationToken)
    {
        var memberships = this._restaurantRepository.GetMembershipsByMinAge(request.RestaurantId, request.MinAge);
        if (memberships.IsFailed)
        {
            return Result.Fail(memberships.Errors);
        }

        var response = new GetMembershipsByMinAgeResponse
        {
            Records = memberships.Value.Records.Select(m => new MembershipRecord
            {
                PlayerId = m.PlayerId!.Value,
                RestaurantId = m.RestaurantId!.Value,
            }).ToList()
        };

        return Result.Ok(response);
    }
}
