using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models.DTOs.CommandDTOs;

public class AddPlayerFavoriteRestaurantDto
{
    public int? PlayerId { get; set; }

    public int? RestaurantId { get; set; }
}
