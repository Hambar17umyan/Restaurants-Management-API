using System.Net;

namespace Application.Api.Common;

public class BindedResponse
{
    public HttpStatusCode Error { get; }
    public IResponse Response { get; }

    public BindedResponse(HttpStatusCode error, IResponse response)
    {
        this.Error = error;
        this.Response = response;
    }
}
