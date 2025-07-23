using FluentResults;
using MediatR;

namespace Application.Api.MembershipApi.GetMembershipsByMinAgeQuery;

public class GetMembershipsByMinAgeRequest : IRequest<Result<GetMembershipsByMinAgeResponse>>
{
    public int MinAge { get; set; }
    public int RestaurantId { get; set; }
}
