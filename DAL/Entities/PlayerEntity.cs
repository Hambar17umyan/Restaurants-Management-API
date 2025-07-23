namespace DAL.Entities;

/// <summary>
/// Represents a player entity in the database.
/// </summary>
public class PlayerEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the player.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the player.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date of birth of the player.
    /// </summary>
    public DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the primary address identifier for the player.
    /// </summary>
    public int PrimaryAddressId { get; set; }

    /// <summary>
    /// Gets or sets the alternate address identifier for the player.
    /// </summary>
    public int AlternateAddressId { get; set; }

    /// <summary>
    /// Gets or sets the office address identifier for the player.
    /// </summary>
    public int OfficeAddressId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the player.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the player.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the driver's license number of the player.
    /// </summary>
    public string DriverLicenseNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the passport number of the player.
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary address entity associated with the player.
    /// </summary>
    public AddressEntity? PrimaryAddress { get; set; }

    /// <summary>
    /// Gets or sets the alternate address entity associated with the player.
    /// </summary>
    public AddressEntity? AlternateAddress { get; set; }

    /// <summary>
    /// Gets or sets the office address entity associated with the player.
    /// </summary>
    public AddressEntity? OfficeAddress { get; set; }
}
