using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class GetRestaurantsContainingNameRecord
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int AddressId { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public TimeOnly OpenningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }
}
