using FluentResults;
using MediatR;

namespace Application.Api.MembershipApi.RegisterMembershipCommand;

public class RegisterMembershipRequest : IRequest<Result<RegisterMembershipResponse>>
{
    public int RestaurantId { get; set; }

    public int PlayerId { get; set; }
}
