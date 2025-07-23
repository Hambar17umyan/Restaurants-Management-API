namespace DAL.Entities;

/// <summary>
/// Represents a restaurant entity in the database.
/// </summary>
public class RestaurantEntity
{
    /// <summary>
    /// Gets or sets unique identifier for the restaurant.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the restaurant.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address identifier for the restaurant.
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the restaurant.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the opening time of the restaurant.
    /// </summary>
    public TimeOnly OpeningTime { get; set; }

    /// <summary>
    /// Gets or sets the closing time of the restaurant.
    /// </summary>
    public TimeOnly ClosingTime { get; set; }

    /// <summary>
    /// Gets or sets the address entity associated with the restaurant.
    /// </summary>
    public AddressEntity? Address { get; set; }
}
