namespace CoolSprings.Model;

public class Ticket
{
    public Guid TicketId { get; set; }
    public Guid BookingId { get; set; }
    public bool IsValid { get; set; }
}