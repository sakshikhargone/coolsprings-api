namespace CoolSprings.Repository;

public class ExceptionRepository : BaseRepository, IExceptionRepository
{
    public async Task AddException(ExceptionLog newException)
    {
        var sql = """
                  INSERT INTO ExceptionLog(Id, StackTrace, Message, RequestUrl,CreatedAt)
                  Values(@Id, @StackTrace, @Message, @RequestUrl,@CreatedAt)
                  """;
        using var db = Connect();
        await db.ExecuteAsync(sql, new
        {
            Id = newException.Id,
            StackTrace = newException.StackTrace,
            Message = newException.Message,
            RequestUrl = newException.RequestUrl,
            CreatedAt = newException.CreatedAt
        });
    }
}