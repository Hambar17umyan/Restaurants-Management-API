using System.Runtime.Serialization;

namespace Domain.Exceptions.ResultException;

public class FirstErrorIsNotApplicationErrorException : Exception
{
    public FirstErrorIsNotApplicationErrorException()
    {
    }

    public FirstErrorIsNotApplicationErrorException(string? message) : base(message)
    {
    }

    public FirstErrorIsNotApplicationErrorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
