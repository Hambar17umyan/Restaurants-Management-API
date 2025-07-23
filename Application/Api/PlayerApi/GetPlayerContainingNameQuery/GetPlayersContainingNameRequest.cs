using FluentResults;
using MediatR;

namespace Application.Api.PlayerApi.GetPlayerContainingNameQuery;

public class GetPlayersContainingNameRequest : IRequest<Result<GetPlayersContainingNameResponse>>
{
    public string Name { get; set; } = string.Empty;
}
