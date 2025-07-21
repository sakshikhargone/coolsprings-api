namespace CoolSprings.Contract.Repository;

public interface ITicketRepository
{
    Task AddTicket(Ticket newTicket);

    Task<DTO.Res.BookingDetailDTO> GetTicket(Guid bookingId);
}