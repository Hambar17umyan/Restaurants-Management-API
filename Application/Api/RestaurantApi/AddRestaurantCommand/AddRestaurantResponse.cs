using Application.Api.Common;

namespace Application.Api.RestaurantApi.AddRestaurantCommand;

public class AddRestaurantResponse : IResponse
{
    public int Id { get; set; }
}
