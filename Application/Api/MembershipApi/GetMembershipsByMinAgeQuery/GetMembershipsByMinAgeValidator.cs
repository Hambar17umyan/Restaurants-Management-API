using FluentValidation;

namespace Application.Api.MembershipApi.GetMembershipsByMinAgeQuery;

public class GetMembershipsByMinAgeValidator : AbstractValidator<GetMembershipsByMinAgeRequest>
{
    public GetMembershipsByMinAgeValidator()
    {
        RuleFor(x => x.MinAge)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Minimum age must be a non-negative integer.");
        RuleFor(x => x.RestaurantId)
            .GreaterThan(0)
            .WithMessage("Restaurant ID must be a positive integer.");
    }
}
