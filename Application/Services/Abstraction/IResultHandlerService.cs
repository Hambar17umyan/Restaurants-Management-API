using Application.Api.Common;
using FluentResults;

namespace Application.Services.Abstraction;

public interface IResultHandlerService
{
    /// <summary>
    /// Handles the result of an operation, returning a success or failure response.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="result">The result to handle.</param>
    /// <returns>A response indicating success or failure.</returns>
    BindedResponse HandleResult<T>(Result<T> result)
        where T : IResponse;
}
