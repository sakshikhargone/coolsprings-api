using Microsoft.AspNetCore.Mvc;

namespace CoolSprings.API.Controllers
{
    [Route("")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok(new { Message = "Welcome to CoolSprings API" });
        }
    }
}