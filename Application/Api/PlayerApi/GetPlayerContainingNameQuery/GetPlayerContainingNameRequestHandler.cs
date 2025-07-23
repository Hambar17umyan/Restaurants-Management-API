using Application.DTOs;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using FluentResults;
using MediatR;

namespace Application.Api.PlayerApi.GetPlayerContainingNameQuery;

public class GetPlayerContainingNameRequestHandler : IRequestHandler<GetPlayersContainingNameRequest, Result<GetPlayersContainingNameResponse>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerContainingNameRequestHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result<GetPlayersContainingNameResponse>> Handle(GetPlayersContainingNameRequest request, CancellationToken cancellationToken)
    {
        var query = new PlayerQueryModel.Builder()
            .SelectAlternateAddressId()
            .SelectDateOfBirth()
            .SelectDriverLicenseNumber()
            .SelectEmail()
            .SelectId()
            .SelectName()
            .SelectOfficeAddressId()
            .SelectPassportNumber()
            .SelectPhoneNumber()
            .SelectPrimaryAddressId()
            .Where(x => x.Name!.Contains(request.Name))
            .Build();
        var playerR = _playerRepository.GetPlayersContainingInName(request.Name, query);
        if (playerR.IsFailed)
        {
            return Result.Fail(playerR.Errors);
        }

        var player = playerR.Value;

        var response = new GetPlayersContainingNameResponse
        {
            Players = player.Records.Select(p => new GetPLayersContainingNameRecord
            {
                Id = p.Id!.Value,
                Name = p.Name!,
                Email = p.Email!,
                PhoneNumber = p.PhoneNumber!,
                AlternateAddressId = p.AlternateAddressId!.Value,
                DateOfBirth = p.DateOfBirth!.Value,
                DriverLicenseNumber = p.DriverLicenseNumber!,
                OfficeAddressId = p.OfficeAddressId!.Value,
                PassportNumber = p.PassportNumber!,
                PrimaryAddressId = p.PrimaryAddressId!.Value,
            }).ToList()
        };
        return response;
    }
}
