namespace CoolSprings.DTO.Req;

public class BookingDTO
{
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string? DiscountCode { get; set; }
    public int NumOfTickets { get; set; }
    public string PaymentMode { get; set; }
    public float ActualAmount { get; set; }
    public float PaidAmount { get; set; }
    public string? UPITxnRefNumber { get; set; }
}
