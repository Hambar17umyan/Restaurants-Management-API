using Application.Api.AddressApi.AddAddressCommand;
using Application.DTOs;
using Application.Services.Abstraction;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Repositories.Abstraction;
using FluentResults;
using System.Collections.ObjectModel;

namespace Application.Services.Concrete;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        this._addressRepository = addressRepository;
    }

    public Result<int> AddAddress(AddAddressRequest request)
    {
        var dto = new AddAddressDto()
        {
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            City = request.City,
            Country = request.Country,
            PostalCode = request.PostalCode,
            State = request.State,
            StreetName = request.StreetName
        };

        var result = this._addressRepository.AddAddress(dto);
        if (result.IsSuccess)
        {
            return Result.Ok(result.Value);
        }
        else
        {
            return Result.Fail(result.Errors);
        }
    }

    public Result<IReadOnlyCollection<GetAllAddressesRecord>> GetAllAddresses(int pageSize, int pageNumber)
    {
        var addresses = this._addressRepository.GetAddresses(pageSize, pageNumber);

        if (addresses.IsSuccess)
        {
            var records = addresses.Value.Records.Select(a => new GetAllAddressesRecord
            {
                Id = a.Id!.Value,
                StreetName = a.StreetName!,
                AddressLine1 = a.AddressLine1!,
                AddressLine2 = a.AddressLine2!,
                City = a.City!,
                State = a.State!,
                PostalCode = a.PostalCode!,
                Country = a.Country!
            }).ToList();

            return records;
        }
        else
        {
            return Result.Fail(addresses.Errors);
        }
    }
}
