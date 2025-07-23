namespace Domain.Exceptions.Db;

public class DbException : Exception
{
    public DbExceptionType Type { get; init; } = DbExceptionType.Unspecified;
    
    public DbException()
    {
    }

    public DbException(string? message) : base(message)
    {
    }

    public DbException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public DbException(DbExceptionType type)
    {
        this.Type = type;
    }

    public DbException(Exception? innerException, DbExceptionType type) : this(null, innerException)
    {
        this.Type = type;
    }

    public DbException(string? message, DbExceptionType type) : base(message)
    {
        this.Type = type;
    }

    public DbException(string? message, Exception? innerException, DbExceptionType type) : base(message, innerException)
    {
        this.Type = type;
    }
}
