using DAL.Entities;
using DAL.Models;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using FluentResults;

namespace DAL.Repositories.Abstraction;

public interface IAddressRepository
{
    Result<int> AddAddress(AddAddressDto addressDto);

    Result<QueryResult<AddressEntity>> GetAddresses(int pageSize, int pageNumber);

    Result<QueryResult<AddressEntity>> GetAddresses(AddressQueryModel query, int pageSize, int pageNumber);

    Result<AddressEntity> GetAddressById(int id, AddressQueryModel query);

    Result<AddressEntity> GetAddressById(int id);
}
