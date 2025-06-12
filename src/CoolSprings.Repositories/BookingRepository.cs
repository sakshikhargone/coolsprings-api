using CoolSprings.Contract.Repository;

namespace CoolSprings.Repository;

public class BookingRepository : BaseRepository, IBookingRepository

{
    public async Task AddBooking(Booking newBooking)
    {
        try
        {
            var query = @"INSERT INTO Booking (BookingId, CustomerId, DiscountId,
                          ValidFrom, ExpiryDate, NumOfTickets, PaymentMode, ActualAmount, PaidAmount,UPITxnRefNumber,CreatedAt)
                          VALUES(@BookingId, @CustomerId, @DiscountId, @ValidFrom, @ExpiryDate, @NumOfTickets, @PaymentMode,
                          @ActualAmount, @PaidAmount, @UPITxnRefNumber, @CreatedAt) ";
            using var db = Connect();
            await db.ExecuteAsync(query, new
            {
                BookingId = newBooking.BookingId,
                CustomerId = newBooking.CustomerId,
                DiscountId = newBooking.DiscountId,
                ValidFrom = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(2),
                NumOfTickets = newBooking.NumOfTickets,
                PaymentMode = newBooking.PaymentMode,
                ActualAmount = newBooking.ActualAmount,
                PaidAmount = newBooking.PaidAmount,
                UpiTxnRefNumber = newBooking.UPITxnRefNumber,
                CreatedAt = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}