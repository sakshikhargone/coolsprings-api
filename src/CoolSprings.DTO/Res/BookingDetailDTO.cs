namespace CoolSprings.DTO.Res;

public  class BookingDetailDTO
{
    public string ValidFrom { get; set; }
    public string ExpiryDate { get; set; }
    public IEnumerable<DetailOfTicket> TicketId { get; set; }
}
public class DetailOfTicket
{
    public Guid TicketId { get; set; }
}