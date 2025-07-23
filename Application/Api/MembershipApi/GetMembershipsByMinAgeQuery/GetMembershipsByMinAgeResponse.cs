using Application.Api.Common;
using Application.DTOs;

namespace Application.Api.MembershipApi.GetMembershipsByMinAgeQuery;

public class GetMembershipsByMinAgeResponse : IResponse
{
    public IReadOnlyCollection<MembershipRecord> Records { get; set;  } = [];
}
