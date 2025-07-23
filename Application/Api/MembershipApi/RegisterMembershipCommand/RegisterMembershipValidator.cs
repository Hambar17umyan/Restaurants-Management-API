using FluentValidation;

namespace Application.Api.MembershipApi.RegisterMembershipCommand;

public class RegisterMembershipValidator : AbstractValidator<RegisterMembershipRequest>
{
    public RegisterMembershipValidator()
    {
        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .WithMessage("Restaurant ID is required.");
        RuleFor(x => x.PlayerId)
            .NotEmpty()
            .WithMessage("Player ID is required.");
        RuleFor(x => x.RestaurantId)
            .GreaterThan(0)
            .WithMessage("Restaurant ID must be greater than zero.");
        RuleFor(x => x.PlayerId)
            .GreaterThan(0)
            .WithMessage("Player ID must be greater than zero.");
    }
}
