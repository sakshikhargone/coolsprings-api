namespace CoolSprings.API.Controllers;

[ApiController]
[ApiException]
[Route(ApiEndpoint.Booking.BookingBase)]
public class BookingController : ControllerBase

{
    private readonly ICustomerRepository _customerContract;
    private readonly IBookingRepository _bookingContract;
    private readonly IDiscountRepository _discountContract;
    private readonly ITicketRepository _ticketContract;
    private readonly ISmsService _smsService;

    public BookingController(ICustomerRepository customerContract, IBookingRepository bookingContract, IDiscountRepository discountContract, ITicketRepository ticketContract, ISmsService smsService)
    {
        _customerContract = customerContract;
        _bookingContract = bookingContract;
        _discountContract = discountContract;
        _ticketContract = ticketContract;
        _smsService = smsService;
    }

    //Add booking
    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] BookingDTO newBooking)
    {
        Guid customerId = Guid.Empty;
        Guid? discountId = null;

        if (string.IsNullOrEmpty(newBooking.CustomerPhone))
        {
            return BadRequest(new ApiResponse(HttpStatusCode.BadRequest, false, message: "customer phone no is required "));
        }
        if (newBooking.CustomerPhone != null)
        {
            var customer = await _customerContract.GetCustomer(newBooking?.CustomerPhone);

            if (customer == null)
            {
                var c = new Customer();
                c.CustomerId = Guid.NewGuid();
                c.CustomerName = newBooking.CustomerName;
                c.CustomerPhone = newBooking.CustomerPhone;
                c.CreatedAt = DateTime.Now;
                customerId = c.CustomerId;
                await _customerContract.AddCustomer(c);
            }
            else
            {
                customerId = customer.CustomerId;
            }
        }

        if (newBooking.DiscountCode != null && newBooking.DiscountCode != "")
        {
            var discount = await _discountContract.GetDiscount(newBooking.DiscountCode);
            if (discount == null)
            {
                var d = new Discount();
                d.DiscountId = Guid.NewGuid();
                d.DiscountCode = newBooking.DiscountCode;
                discountId = d.DiscountId;
                await _discountContract.AddDiscount(d);
            }
            else
            {
                discountId = discount.DiscountId;
            }
        }
        var bookingId = Guid.NewGuid();
        var booking = newBooking.Adapt<Booking>();
        booking.DiscountId = discountId;
        booking.CustomerId = customerId;
        booking.BookingId = bookingId;
        await _bookingContract.AddBooking(booking);
        for (int i = 0; i < newBooking.NumOfTickets; i++)
        {
            var ticket = new Ticket();
            ticket.TicketId = Guid.NewGuid();
            ticket.BookingId = bookingId;
            ticket.IsValid = true;
            await _ticketContract.AddTicket(ticket);
        }

        var s = new Sms();
        s.Content = s.Content = $"Hey, thank you for booking with us. Download your ticket: https://50f3-103-171-189-185.ngrok-free.app/{bookingId}";

        s.ToPhoneNumber = booking.CustomerPhone;

        var smsDetails = s.Adapt<Sms>();
        var result = _smsService.Send(smsDetails);

        return Ok(new ApiResponse(HttpStatusCode.Created, true, new {bookingId = booking.BookingId}));
    }
}