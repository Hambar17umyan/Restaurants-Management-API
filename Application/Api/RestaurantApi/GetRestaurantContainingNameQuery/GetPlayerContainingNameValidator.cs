using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.RestaurantApi.GetRestaurantContainingNameQuery
{
    public class GetRestaurantContainingNameValidator : AbstractValidator<GetRestaurantsContainingNameRequest>
    {
        public GetRestaurantContainingNameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
        }
    }
}
