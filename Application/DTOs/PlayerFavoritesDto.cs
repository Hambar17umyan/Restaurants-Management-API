namespace Application.DTOs;

public class PlayerFavoritesDto
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; } = default!;
    public IReadOnlyCollection<int> RestaurantIds { get; set; } = Array.Empty<int>();
}
