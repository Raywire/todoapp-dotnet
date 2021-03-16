using Microsoft.AspNetCore.Mvc;

namespace todoapp_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestRun()
        {
            return Ok("Success");
        }
    }
}