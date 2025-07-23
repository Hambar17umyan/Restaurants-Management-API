using Application.Api.Common;
using System.Net;

namespace Application.Services.Abstraction;
public interface ICreateFailService
{
    /// <summary>
    /// Creates failed BindedResponse.
    /// </summary>
    /// <param name="statusCode">The error code.</param>
    /// <param name="message">Message.</param>
    /// <param name="metaData">Additional key-value pairs.</param>
    /// <returns></returns>
    BindedResponse CreateFail(HttpStatusCode statusCode, string message, Dictionary<string, object>? metaData = null);
}