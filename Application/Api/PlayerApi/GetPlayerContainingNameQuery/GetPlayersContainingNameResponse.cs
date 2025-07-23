using Application.Api.Common;
using Application.DTOs;

namespace Application.Api.PlayerApi.GetPlayerContainingNameQuery;

public class GetPlayersContainingNameResponse : IResponse
{
    public IReadOnlyCollection<GetPLayersContainingNameRecord> Players { get; set; } = [];
}
