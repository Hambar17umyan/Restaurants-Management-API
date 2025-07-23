using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

/// <summary>
/// Represents an address entity in the database.
/// </summary>
public class AddressEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the address.
    /// </summary>
    [Required]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the street name of the address.
    /// </summary>
    [Required]
    public string? StreetName { get; set; }

    /// <summary>
    /// Gets or sets the first line of the address.
    /// </summary>
    [Required]
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// Gets or sets the second line of the address, if applicable.
    /// </summary>
    [Required]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Gets or sets the city of the address.
    /// </summary>
    [Required]
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the state or province of the address.
    /// </summary>
    [Required]
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the postal code of the address.
    /// </summary>
    [Required]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the country of the address.
    /// </summary>
    [Required]
    public string? Country { get; set; }
}
