using Application.Api.Common;
using Application.Services.Abstraction;
using System.Net;

namespace Application.Services.Concrete;

public class CreateFailService : ICreateFailService
{
    public BindedResponse CreateFail(HttpStatusCode statusCode, string message, Dictionary<string, object>? metaData = null)
    {
        metaData = metaData ?? [];
        var fail = new FailResponse()
        {
            Message = message,
            MetaData = metaData
        };

        return new BindedResponse(statusCode, fail);
    }
}
