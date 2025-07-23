using FluentResults;
using MediatR;

namespace Application.Api.PlayerApi.AddPlayerCommand;

public class AddPlayerRequest : IRequest<Result<AddPlayerResponse>>
{
    public string Name { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string DriverLicenseNumber { get; set; } = string.Empty;

    public string PassportNumber { get; set; } = string.Empty;

    public int PrimaryAddressId { get; set; }

    public int AlternateAddressId { get; set; }

    public int OfficeAddressId { get; set; }
}
