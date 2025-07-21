using CoolSprings.Contract.Repository;
using CoolSprings.DTO.Res;

namespace CoolSprings.Repository;

public class TicketRepository : BaseRepository, ITicketRepository
{
    public async Task AddTicket(Ticket newTicket)
    {
        try
        {
            var sql = """
                     INSERT INTO Ticket(TicketId,BookingId,IsValid)
                     VALUES(@TicketId, @BookingId, @IsValid)
                     """;
            using var db = Connect();
            await db.ExecuteAsync(sql, new
            {
                TicketId = newTicket.TicketId,
                BookingId = newTicket.BookingId,
                IsValid = newTicket.IsValid
            }, commandTimeout: commandTimeoutSeconds);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<DTO.Res.BookingDetailDTO> GetTicket(Guid bookingId)
    {
        try
        {
            var tickets = """
                          SELECT TicketId FROM Ticket
                          WHERE BookingId = @bookingId
                          """;
            var bookingDate = """
                              SELECT ValidFrom,ExpiryDate FROM Booking
                              WHERE BookingId = @bookingId
                              """;
            using var db = Connect();
            var ticketDetail = await db.QueryFirstOrDefaultAsync<DTO.Res.BookingDetailDTO>(bookingDate,
                new { bookingId }, commandTimeout: commandTimeoutSeconds);
            if (ticketDetail != null)
            {
                var ticket = await db.QueryAsync<DetailOfTicket>(tickets, new { bookingId });
                ticketDetail.TicketId = ticket;
            }
            return ticketDetail;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}