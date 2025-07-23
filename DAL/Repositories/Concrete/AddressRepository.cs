using DAL.Db;
using DAL.Entities;
using DAL.Models;
using DAL.Models.DTOs.CommandDTOs;
using DAL.Models.QueryModels;
using DAL.Repositories.Abstraction;
using DAL.Services.QueryProcessing.Abstraction;
using Domain.Infrastructure.ResultModels;
using FluentResults;

namespace DAL.Repositories.Concrete;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IAddressQueryProcessor _addressQueryProcessor;

    public AddressRepository(AppDbContext dbContext, IAddressQueryProcessor addressQueryProcessor)
    {
        this._dbContext = dbContext;
        _addressQueryProcessor = addressQueryProcessor;
    }

    public Result<int> AddAddress(AddAddressDto addressDto)
    {
        if (addressDto == null)
        {
            return Result.Fail("Address DTO cannot be null.");
        }

        var addressEntity = new AddressEntity
        {
            StreetName = addressDto.StreetName,
            City = addressDto.City,
            State = addressDto.State,
            AddressLine1 = addressDto.AddressLine1,
            AddressLine2 = addressDto.AddressLine2,
            Country = addressDto.Country,
            PostalCode = addressDto.PostalCode
        };
        this._dbContext.Add(addressEntity);
        this._dbContext.SaveChanges();

        return Result.Ok(addressEntity.Id!.Value);
    }

    public Result<AddressEntity> GetAddressById(int id, AddressQueryModel query)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id should be greater than 0.", nameof(id));
        }

        var address = this._addressQueryProcessor.Process(this._dbContext.Addresses, query)
            .FirstOrDefault(a => a.Id == id);
        if (address == null)
        {
            return ResultHelper.ErrorResult<AddressEntity>(ErrorType.AddressByIdNotFound, "Address not found.");
        }
        return Result.Ok(address);
    }

    public Result<AddressEntity> GetAddressById(int id)
    {
        return this.GetAddressById(id, AddressQueryModel.Default);
    }

    public Result<QueryResult<AddressEntity>> GetAddresses(int pageSize, int pageNumber)
    {
        return this.GetAddresses(AddressQueryModel.Default, pageSize, pageNumber);
    }

    public Result<QueryResult<AddressEntity>> GetAddresses(AddressQueryModel query, int pageSize, int pageNumber)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            throw new ArgumentException("PageSize and PageNumber should be greater then 0.");
        }

        var totalCount = this._dbContext.Addresses.Count();
        var addresses = this._addressQueryProcessor.Process(this._dbContext.Addresses, query)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        var queryResult = new QueryResult<AddressEntity>(addresses);
        return Result.Ok(queryResult);
    }
}
