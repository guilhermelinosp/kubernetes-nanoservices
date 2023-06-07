using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/v1/command/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        public PlatformController()
        {

        }


        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--------");

            return Ok("Inbound test of from Platform Controller");
        }
    }
}
