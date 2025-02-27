using Microsoft.Data.SqlClient;
namespace CoolSprings.Repository.Database;

public class BookingRepository : BaseRepository, IBookingRepository
{
    public async Task AddBooking(Booking newBooking)
    {
        try
        {
            using (var db = Connect())
            {
                var sql = @"INSERT INTO Booking
                               (BookingId, CustomerId, DiscountId, ValidFrom, ExpiryDate, NumOfTickets,ActualAmount, PaidAmount, PaymentMode, UPITxnRefNumber,CreatedAt)
                              VALUES
                              (@BookingId, @CustomerId, @DiscountId, @ValidFrom,  @ExpiryDate, @NumOfTickets, @ActualAmount, @PaidAmount, @PaymentMode, @UPITxnRefNumber, @CreatedAt)";

                await db.ExecuteAsync(sql, new {
                BookingId = newBooking.BookingId,
                CustomerId = newBooking.CustomerId,
                DiscountId = newBooking.DiscountId,
                ValidFrom = newBooking.ValidFrom,
                ExpiryDate = newBooking.ExpiryDate,
                NumOfTickets = newBooking.NumOfTickets,
      
                ActualAmount = newBooking.ActualAmount,
                PaidAmount = newBooking.PaidAmount,
                PaymentMode = newBooking.PaymentMode,
                UPITxnRefNumber = newBooking.UPITxnRefNumber,
                 CreatedAt = newBooking.CreatedAt



                });


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}