namespace CoolSprings.Contract.Repository;

public interface IBookingRepository
{
    Task AddBooking(Booking newBooking);
}
