using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

/// <summary>
/// Represents a membership of a player in a restaurant.
/// </summary>
public class RestaurantMembershipEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the restaurant entity.
    /// </summary>
    [Required]
    public int? RestaurantId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the player associated with this restaurant membership.
    /// </summary>
    [Required]
    public int? PlayerId { get; set; }

    /// <summary>
    /// Gets or sets the restaurant entity associated with this membership.
    /// </summary>
    public PlayerEntity? Player { get; set; }

    /// <summary>
    /// Gets or sets the restaurant entity associated with this membership.
    /// </summary>
    public RestaurantEntity? Restaurant { get; set; }
}
