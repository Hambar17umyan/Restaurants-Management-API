using FluentValidation;

namespace Application.Api.RestaurantApi.GetRestaurantByIdQuery;

public class GetRestaurantByIdValidator : AbstractValidator<GetRestaurantByIdRequest>
{
    public GetRestaurantByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Restaurant ID is required.")
            .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");
    }
}
