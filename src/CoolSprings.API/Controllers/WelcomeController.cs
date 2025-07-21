

namespace CoolSprings.API.Controllers;

[Route("/")]
[ApiController]
public class WelcomeController : BaseApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Welcome to CoolSprings API" });
    }
}