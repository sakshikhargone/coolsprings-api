using CoolSprings.Contract.Repository;

namespace CoolSprings.API.Controllers;

[ApiController]
[ApiException]
[Route(ApiEndpoint.Discount.DiscountBase)]
public class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _discountContract;

    public DiscountController(IDiscountRepository discountContract)
    {
        _discountContract = discountContract;
    }

    //get discount details
    [HttpGet]
    public async Task<IActionResult> GetDiscount([FromQuery] string discountCode)
    {
        var discount = await _discountContract.GetDiscount(discountCode);
        var discountDetail = discount.Adapt<DiscountDTO>();
        return Ok(new ApiResponse(HttpStatusCode.Found, true, discountDetail));
    }
}