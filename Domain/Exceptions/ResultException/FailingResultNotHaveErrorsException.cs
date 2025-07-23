namespace Domain.Exceptions.ResultException;

public class FailingResultNotHaveErrorsException : Exception
{
    public FailingResultNotHaveErrorsException()
    {
    }

    public FailingResultNotHaveErrorsException(string? message) : base(message)
    {
    }

    public FailingResultNotHaveErrorsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
