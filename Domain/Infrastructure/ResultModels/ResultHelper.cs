using FluentResults;

namespace Domain.Infrastructure.ResultModels;

public static class ResultHelper
{
    public static Result<T> ErrorResultWithMessage<T>(ErrorType type, string applicationMessage, string message = "")
    {
        var error = new ApplicationError()
        {
            ApiMessage = applicationMessage,
            Message = message,
            Metadata = [],
            Reasons = [],
            ShouldExposeMessage = true,
            Type = type,
        };
        return Result.Fail<T>(error);
    }

    public static Result<T> ErrorResult<T>(ErrorType type, string message)
    {
        var error = new ApplicationError()
        {
            ApiMessage = default,
            Message = message,
            Metadata = [],
            Reasons = [],
            ShouldExposeMessage = false,
            Type = type,
        };
        return Result.Fail<T>(error);
    }

    public static Result ErrorResultWithMessage(ErrorType type, string applicationMessage, string message = "")
    {
        var error = new ApplicationError()
        {
            ApiMessage = applicationMessage,
            Message = message,
            Metadata = [],
            Reasons = [],
            ShouldExposeMessage = true,
            Type = type,
        };
        return Result.Fail(error);
    }

    public static Result ErrorResult(ErrorType type, string message)
    {
        var error = new ApplicationError()
        {
            ApiMessage = default,
            Message = message,
            Metadata = [],
            Reasons = [],
            ShouldExposeMessage = false,
            Type = type,
        };
        return Result.Fail(error);
    }
}
