using FluentResults;

namespace Domain.Infrastructure.ResultModels;

public class ApplicationError : IError
{
    internal ApplicationError()
    {
    }

    public List<IError> Reasons { get; internal set; } = [];

    public string Message { get; internal set; } = string.Empty;

    public string? ApiMessage { get; internal set; } = null;

    public bool ShouldExposeMessage { get; internal set; } = true;

    public Dictionary<string, object> Metadata { get; internal set; } = [];

    public ErrorType Type { get; internal set; } = ErrorType.Unspecified;
}
