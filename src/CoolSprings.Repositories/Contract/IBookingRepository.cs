namespace CoolSprings.Repository.Contract;

public interface IBookingRepository
{
    Task AddBooking(Booking newBooking);
}