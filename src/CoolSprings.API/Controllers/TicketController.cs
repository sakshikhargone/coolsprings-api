namespace CoolSprings.API.Controllers;
[ApiController]
[ApiException]
[Route(ApiEndpoint.Ticket.TicketBase)]
public class TicketController : ControllerBase
   {

    private readonly ITicketRepository _ticketContract;
    private readonly ISmsService _smsService;
    private readonly ICustomerRepository _customerContract;

    public TicketController(ITicketRepository ticketContract, ISmsService smsService, ICustomerRepository customerContract)
    {
        _ticketContract = ticketContract;
        _smsService = smsService;
        _customerContract = customerContract;
    }

    [HttpGet]
    [Route("{bookingId}")]
   public async Task<IActionResult> GetTicket([FromRoute]Guid bookingId)
    {
       
            var ticketDetail = await _ticketContract.GetTicket(bookingId);
        if (ticketDetail == null)
        {
            return Ok(new ApiResponse(HttpStatusCode.NoContent, true, message: "no tickets for this : " + bookingId));
        }

        var customerDetail = await _customerContract.GetCustomerByBookingId(bookingId);
        
        if(customerDetail != null)
        {
            _smsService.Send(new Sms
            {
                Content = $"Hey {customerDetail.CustomerName}, Thank you for booking with us. Download your ticket: https://50f3-103-171-189-185.ngrok-free.app/{bookingId}",
                ToPhoneNumber = customerDetail.CustomerPhone
            });
        }

        return Ok(new ApiResponse(HttpStatusCode.OK, true, ticketDetail));
        
        
        
    }
    
}
