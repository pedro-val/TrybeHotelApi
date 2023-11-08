using Microsoft.AspNetCore.Mvc;


namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatusController : Controller
    {
        [HttpGet]
        public JsonResult GetStatus()
        {
            return new JsonResult(new { message = "online" });
        }
    }
}
