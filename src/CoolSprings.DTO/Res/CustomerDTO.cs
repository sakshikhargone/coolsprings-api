namespace CoolSprings.DTO.Res;

public  class CustomerDTO
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPassword { get; set; }
}
