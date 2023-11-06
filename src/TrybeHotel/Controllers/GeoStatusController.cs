using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Services;


namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("geo/status")]   
    public class GeoStatusController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public GeoStatusController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var request = new GeoService(client);
                return Ok(await request.GetGeoStatus());                
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}