using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

/// <summary>
/// Represents a restaurant entity in the database.
/// </summary>
public class RestaurantEntity
{
    /// <summary>
    /// Gets or sets unique identifier for the restaurant.
    /// </summary>
    [Required]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the restaurant.
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the address identifier for the restaurant.
    /// </summary>
    [Required]
    public int? AddressId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the restaurant.
    /// </summary>
    [Required]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the opening time of the restaurant.
    /// </summary>
    [Required]
    public TimeOnly? OpenningTime { get; set; }

    /// <summary>
    /// Gets or sets the closing time of the restaurant.
    /// </summary>
    [Required]
    public TimeOnly? ClosingTime { get; set; }

    /// <summary>
    /// Gets or sets the address entity associated with the restaurant.
    /// </summary>
    public AddressEntity? Address { get; set; }
}
