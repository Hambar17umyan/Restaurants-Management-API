using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

/// <summary>
/// Represents a many-to-many relationship between players and their favorite restaurants.
/// </summary>
public class PlayerFavoriteRestaurantEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the player who has a favorite restaurant.
    /// </summary>
    [Required]
    public int? PlayerId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the favorite restaurant.
    /// </summary>
    [Required]
    public int? RestaurantId { get; set; }

    /// <summary>
    /// Gets or sets the player associated with this favorite restaurant entry.
    /// </summary>
    public PlayerEntity? Player { get; set; }

    /// <summary>
    /// Gets or sets the restaurant associated with this favorite restaurant entry.
    /// </summary>
    public RestaurantEntity? Restaurant { get; set; }
}
