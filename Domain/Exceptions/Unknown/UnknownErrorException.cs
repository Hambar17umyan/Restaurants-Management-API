using System.Runtime.Serialization;

namespace Domain.Exceptions.Unknown;

public class UnknownErrorException : Exception
{
    public UnknownErrorException()
    {
    }

    public UnknownErrorException(string? message) : base(message)
    {
    }

    public UnknownErrorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
