using Application.Api.Common;

namespace Application.Api.PlayerApi.AddPlayerCommand;

public class AddPlayerResponse : IResponse
{
    public int Id { get; set; }
}
