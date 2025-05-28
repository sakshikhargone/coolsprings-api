namespace CoolSprings.Contract.Repository;

public interface ITokenRepository
{
    Task AddToken(Token newToken);
    Task<Token> GetToken(string customerPhone);
}