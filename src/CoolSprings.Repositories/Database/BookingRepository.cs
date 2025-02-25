
namespace CoolSprings.Repository.Database;

public class BookingRepository : BaseRepository, IBookingRepository
{
    public async Task<bool> AddBooking(Booking newBooking)
    {
        try
        {
            using (var db = Connect())
            {
                var sql = @"INSERT INTO Booking
                               (BookingId, CustomerId, DiscountId, ValidFrom, ExpiryDate, NumOfTickets,ActualAmount, PaymentMode, UPITxnRefNumber,CreatedAt)
                              VALUES
                              (@BookingId, @CustomerId, @DiscoutId, @ValidFrom, @ExpiryDate, @NumOfTickets, @ActualAmount, @PaymentMode, @UPITxnRefNumber, @CreatedAt)";

                await db.ExecuteAsync(sql, newBooking);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}