namespace CoolSprings.API.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    protected IActionResult ComposeResponse(ApiResponse response)
    {
        return Ok(response);
    }
}