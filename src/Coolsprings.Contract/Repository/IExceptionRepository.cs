namespace CoolSprings.Contract;

public interface IExceptionRepository
{
    Task AddException(ExceptionLog newException);
}