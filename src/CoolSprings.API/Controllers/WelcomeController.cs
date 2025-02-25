namespace CoolSprings.API.Controllers
{
    [Route("")]
    public class WelcomeController : APIController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Welcome to CoolSprings API" });
        }
    }
}