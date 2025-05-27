namespace CoolSprings.Contract.Repository;

public interface ITicketRepository
{
    Task AddTicket(Ticket newTicket);
    Task<TicketDetail> GetTicket(Guid bookingId);
}