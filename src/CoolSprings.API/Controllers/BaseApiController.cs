namespace CoolSprings.API.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    public IActionResult ComposeResponse(ApiResponse response)
    {
        return Ok(response);
    }
}