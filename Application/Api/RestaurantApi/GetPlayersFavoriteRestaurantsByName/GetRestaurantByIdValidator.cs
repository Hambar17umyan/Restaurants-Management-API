using FluentValidation;

namespace Application.Api.RestaurantApi.GetPlayersFavoriteRestaurantsByName;

public class GetPlayersFavoriteRestaurantsByNameValidator : AbstractValidator<GetPlayersFavoriteRestaurantsByNameRequest>
{
    public GetPlayersFavoriteRestaurantsByNameValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    }
}
