namespace DAL.Models;

public class QueryResult<TEntity>
{
    public readonly IReadOnlyCollection<TEntity> Records;

    public QueryResult(IReadOnlyCollection<TEntity> records)
    {
        Records = records;
    }
}
