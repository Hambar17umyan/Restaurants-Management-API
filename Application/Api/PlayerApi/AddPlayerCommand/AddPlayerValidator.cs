using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.PlayerApi.AddPlayerCommand;

public class AddPlayerValidator : AbstractValidator<AddPlayerRequest>
{
    public AddPlayerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.PrimaryAddressId)
            .NotEmpty().WithMessage("PrimaryAddressId is required.")
            .GreaterThan(0).WithMessage("PrimaryAddressId must be a positive integer.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("PhoneNumber must be a valid international phone number.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required.");

        RuleFor(x => x.DriverLicenseNumber)
            .NotEmpty().WithMessage("DriverLicenseNumber is required.")
            .MaximumLength(50).WithMessage("DriverLicenseNumber must not exceed 50 characters.");

        RuleFor(x => x.PassportNumber)
            .NotEmpty().WithMessage("PassportNumber is required.")
            .MaximumLength(50).WithMessage("PassportNumber must not exceed 50 characters.");

        RuleFor(x => x.AlternateAddressId)
            .NotEmpty().WithMessage("AlternateAddressId is required.")
            .GreaterThan(0).WithMessage("AlternateAddressId must be a positive integer.");

        RuleFor(x => x.OfficeAddressId)
            .NotEmpty().WithMessage("OfficeAddressId is required.")
            .GreaterThan(0).WithMessage("OfficeAddressId must be a positive integer.");

        RuleFor(x => x)
            .Must(x => x.PrimaryAddressId != x.AlternateAddressId &&
                        x.PrimaryAddressId != x.OfficeAddressId &&
                        x.AlternateAddressId != x.OfficeAddressId)
            .WithMessage("Primary, Alternate, and Office addresses must be different.");


    }
}
