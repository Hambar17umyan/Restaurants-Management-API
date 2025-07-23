using FluentValidation;

namespace Application.Api.AddressApi.GetAllAddressesQuery;

public class GetAllAddressesValidator : AbstractValidator<GetAllAddressesRequest>
{
    public GetAllAddressesValidator()
    {
        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0.");
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be greater than or equal to 1.");
    }
}
