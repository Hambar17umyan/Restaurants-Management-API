using Application.Api.PlayerApi.AddPlayerCommand;
using Application.Services.Abstraction;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using Domain.Infrastructure.ResultModels;
using FluentResults;

namespace Application.Services.Concrete;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IAddressRepository _addressRepository;

    public PlayerService(IPlayerRepository playerRepository, IAddressRepository addressRepository)
    {
        _playerRepository = playerRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Result<AddPlayerResponse>> AddPlayerAsync(AddPlayerRequest request)
    {
        var query = new AddressQueryModel.Builder()
            .SelectId()
            .Where(x => true)
            .Build();
        var address = this._addressRepository.GetAddressById(request.PrimaryAddressId, query);
        var address1 = this._addressRepository.GetAddressById(request.OfficeAddressId, query);
        var address2 = this._addressRepository.GetAddressById(request.AlternateAddressId, query);
        if (address.IsSuccess == false ||
           address1.IsFailed ||
           address2.IsFailed)
        {
            return ResultHelper.ErrorResultWithMessage<AddPlayerResponse>(ErrorType.AddressdNotFound, "Address not found.");
        }

        var res = this._playerRepository.AddPlayer(new()
        {
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            AlternateAddressId = request.AlternateAddressId,
            DateOfBirth = request.DateOfBirth,
            DriverLicenseNumber = request.DriverLicenseNumber,
            PassportNumber = request.PassportNumber,
            PrimaryAddressId = request.PrimaryAddressId,
            OfficeAddressId = request.OfficeAddressId
        });

        if (res.IsFailed)
        {
            return Result.Fail(res.Errors);
        }

        var response = new AddPlayerResponse
        {
            Id = res.Value
        };

        return Result.Ok(response);
    }
}
