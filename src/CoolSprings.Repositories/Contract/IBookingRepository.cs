namespace CoolSprings.Repository.Contract;

public interface IBookingRepository
{
    Task<bool> AddBooking(Booking newBooking);
}