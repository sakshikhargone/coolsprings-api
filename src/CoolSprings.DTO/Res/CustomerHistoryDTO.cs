namespace CoolSprings.DTO;

public class CustomerHistoryDTO
{
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public IEnumerable<BookingDetail> Booking { get; set; }
}
public  class BookingDetail
{
    public int NumOfTickets { get; set; }
    public string PaymentMode { get; set; }
    public float ActualAmount { get; set; }
    public float PaidAmount { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ExpiryDate { get; set; }
}