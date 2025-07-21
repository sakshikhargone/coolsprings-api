namespace CoolSprings.API.Controllers;

[ApiException]
[ApiController]
[Route(ApiEndpoint.Customer.CustomerBase)]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerContract;
    private readonly IEncoding _encodingService;
    private readonly ITokenRepository _tokenContract;

    public CustomerController(ICustomerRepository customerContract, IEncoding encodingService, ITokenRepository tokenContract)
    {
        _customerContract = customerContract;
        _encodingService = encodingService;
        _tokenContract = tokenContract;
    }

    [HttpGet("{customerPhone}")]
    public async Task<IActionResult> GetCustomer([FromRoute] string customerPhone)
    {
        var customer = await _customerContract.GetCustomer(customerPhone);
        if (customer == null)
        {
            return BadRequest(new ApiResponse(HttpStatusCode.NotFound, false, message: $"Customer with mobile number {customerPhone}  not found. "));
        }
        var customerDTO = customer.Adapt<CustomerDTO>();
        return Ok(new ApiResponse(HttpStatusCode.Found, true, customerDTO));
    }

    [HttpPut]
    public async Task<IActionResult> SignUp([FromBody] TokenCredentialDTO credential)
    {
        await _customerContract.UpdateCustomer(credential);
        var token = _encodingService.Encoding(credential);

        var t = new Token();
        {
            t.TokenId = Guid.NewGuid();
            t.TokenValue = token;
            t.CustomerId = credential.CustomerId;
            t.ValidFrom = DateTime.Now;
            t.ExpireAt = DateTime.Now.AddMinutes(15);
        }
        await _tokenContract.AddToken(t);

        return Ok(new ApiResponse(HttpStatusCode.Created, true, data: new { token = token }, message: "token created successfully"));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] TokenCredentialDTO credential)
    {
        var token = await _tokenContract.GetToken(credential.CustomerPhone);
        var customer = await _customerContract.GetCustomer(credential.CustomerPhone);

        if (credential.CustomerPassword == customer.CustomerPassword)
        {
            if (token == null)
            {
                var newToken = _encodingService.Encoding(credential);
                var t = new Token();
                {
                    t.TokenId = Guid.NewGuid();
                    t.TokenValue = newToken;
                    t.CustomerId = credential.CustomerId;
                    t.ValidFrom = DateTime.Now;
                    t.ExpireAt = DateTime.Now.AddMinutes(15);
                }
                await _tokenContract.AddToken(t);
                return Ok(new ApiResponse(HttpStatusCode.Created, true, data: new { token = newToken }, message: "token created successfully"));
            }
            return Ok(new ApiResponse(HttpStatusCode.Found, true, data: new { token = token.TokenValue }));
        }
        return BadRequest(new ApiResponse(HttpStatusCode.Unauthorized, false, message: "Invalid password. Please try again."));
    }

    [HttpGet("bookings/{customerId}")]
    public async Task<IActionResult> getCustomerBooking([FromRoute] Guid customerId)
    {
        var customerBooking = await _customerContract.GetCustomerHistory(customerId);
        return Ok(new ApiResponse(HttpStatusCode.Found, true, customerBooking));
    }
}