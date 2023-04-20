using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("FUCK");
        }
    }
}
