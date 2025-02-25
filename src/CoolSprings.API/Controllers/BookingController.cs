
namespace CoolSprings.API.Controllers;
[Route("api/bookings")]
public class BookingController : APIController
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IDiscountRepository _discountRepository;

    public BookingController(IBookingRepository bookingRepository, 
        ICustomerRepository customerRepository, IDiscountRepository discountRepository)
    {
        _bookingRepository = bookingRepository;
        _customerRepository = customerRepository;
        _discountRepository = discountRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] Booking newBooking)
    {
        try
        {
            
            var bId =  Guid.NewGuid();
            var cId = Guid.NewGuid();
            var dId = Guid.NewGuid();

            newBooking.BookingId = bId;
            newBooking.CustomerId = cId;
            var Customer = new Customer();
            {
                Customer.CustomerId = cId;
                Customer.CustomerName = newBooking.CustomerName;
                Customer.CustomerPhone = newBooking.CustomerPhone;
            }

            await _customerRepository.AddCustomer(Customer);
            
            var booking = await _bookingRepository.AddBooking(newBooking);
            return Ok(booking);
        }
        catch (Exception ex)
        {
            ExceptionHandler.Log(ex);
            throw;
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok("Hello");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}