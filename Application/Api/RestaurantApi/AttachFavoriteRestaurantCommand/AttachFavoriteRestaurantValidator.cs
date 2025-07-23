using FluentValidation;

namespace Application.Api.RestaurantApi.AttachFavoriteRestaurantCommand;

public class AttachFavoriteRestaurantValidator : FluentValidation.AbstractValidator<AttachFavoriteRestaurantRequest>
{
    public AttachFavoriteRestaurantValidator()
    {
        RuleFor(x => x.PlayerId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        RuleFor(x => x.RestaurantId).GreaterThan(0).WithMessage("RestaurantId must be greater than 0.");
    }
}