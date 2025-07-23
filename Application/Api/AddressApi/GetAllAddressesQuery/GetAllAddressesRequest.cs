using Application.Api.AddressApi.GetAddressQuery;
using FluentResults;
using MediatR;

namespace Application.Api.AddressApi.GetAllAddressesQuery;

public class GetAllAddressesRequest : IRequest<Result<GetAllAddressesResponse>>
{
    public int PageSize { get; set; } 

    public int PageNumber { get; set; }
}
