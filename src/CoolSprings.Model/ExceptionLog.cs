namespace CoolSprings.Model;

public class ExceptionLog
{
    public Guid Id { set; get; }
    public string StackTrace { get; set; }
    public string Message { get; set; }
    public string RequestUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}