using Microsoft.AspNetCore.Mvc;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult GetError()
        {
            throw new Exception("Simulated exception from TestController");
        }
    }
}
