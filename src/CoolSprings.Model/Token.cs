namespace CoolSprings.Model;

public class Token
{
    public Guid TokenId { get; set; }
    public string TokenValue { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ExpireAt { get; set; }
    public bool IsActive { get; set; }
}