namespace CoolSprings.Model;

public class Discount
{
    public Guid DiscountId { get; set; }
    public string DiscountCode { get; set; }
    public string DiscountValue { get; set; }
    public DateTime ExpiryDate { get; set; }
    public DateTime ActivationDate { get; set; }
}