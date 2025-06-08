using CoolSprings.Contract.Repository;

namespace CoolSprings.Repository;

public class TokenRepository : BaseRepository, ITokenRepository
{
    public async Task AddToken(Token newToken)
    {
        var sql = """
                  INSERT INTO Token(TokenId, TokenValue,CustomerId,ValidFrom, ExpireAt, IsActive)
                  VALUES(@TokenId, @TokenValue, @CustomerId, @ValidFrom, @ExpireAt, @IsActive)
                  """;
        using var db = Connect();
        await db.ExecuteAsync(sql, new
        {
            TokenId = newToken.TokenId,
            TokenValue = newToken.TokenValue,
            CustomerId = newToken.CustomerId,
            ValidFrom = newToken.ValidFrom,
            ExpireAt = newToken.ExpireAt,
            IsActive = newToken.IsActive
        }, commandTimeout: commandTimeoutSeconds);
    }

    public async Task<Token> GetToken(string customerPhone)
    {
        var sql = """
                  SELECT * FROM Token t
                  JOIN Customer c ON t.CustomerId = c.CustomerId
                  WHERE c.CustomerPhone = @customerPhone AND
                  t.ExpireAt > GETDATE()
                  """;
        using var db = Connect();
        var token = await db.QueryFirstOrDefaultAsync<Token>(sql, new { customerPhone },
            commandTimeout: commandTimeoutSeconds);
        return token;
    }
}