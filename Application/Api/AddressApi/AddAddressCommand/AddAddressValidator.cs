using FluentValidation;

namespace Application.Api.AddressApi.AddAddressCommand;

public class AddAddressValidator : AbstractValidator<AddAddressRequest>
{
    public AddAddressValidator()
    {
        _ = this.RuleFor(x => x.StreetName).NotEmpty().WithMessage("Street name is required.");
        _ = this.RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Address line 1 is required.");
        _ = this.RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
        _ = this.RuleFor(x => x.State).NotEmpty().WithMessage("State is required.");
        _ = this.RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required.");
        _ = this.RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
    }
}