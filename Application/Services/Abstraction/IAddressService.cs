using Application.Api.AddressApi.AddAddressCommand;
using Application.DTOs;
using DAL.Models.DTOs.CommandDTOs;
using FluentResults;

namespace Application.Services.Abstraction;

public interface IAddressService
{
    Result<int> AddAddress(AddAddressRequest request);

    Result<IReadOnlyCollection<GetAllAddressesRecord>> GetAllAddresses(int pageSize, int pageNumber);
}
