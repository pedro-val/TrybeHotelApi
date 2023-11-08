using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Dto;
using TrybeHotel.Repository;
using TrybeHotel.Services;


namespace TrybeHotel.Controllers;

    [ApiController]
    [Route("geo/address")]   
    public class GeoAddressController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITrybeHotelContext _context;

        public GeoAddressController(IHttpClientFactory clientFactory, ITrybeHotelContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeoDtoHotelResponse>>> GetHotelsByLocation([FromQuery] GeoDto geoDto)
        {
            try
            {
                var repository = new HotelRepository(_context);
                var hotels = repository.GetHotels();
                var client = _clientFactory.CreateClient();
                var geoService = new GeoService(client);
                var hotelResponses = await geoService.GetHotelsByGeo(geoDto, repository);
                return Ok(hotelResponses);                
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }


