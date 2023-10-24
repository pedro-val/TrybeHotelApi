using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("booking")]
  
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize(Policy = "Client")]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert)
        {
            try
            {
                var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                var bookingResponse = _repository.Add(bookingInsert, userEmail ?? string.Empty);
                return CreatedAtAction(nameof(GetBooking), new { id = bookingResponse.BookingId }, bookingResponse);                
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        [HttpGet("{Bookingid}")]
        [Authorize(Policy = "Client")]
        public IActionResult GetBooking(int Bookingid)
        {
            try
            {
                var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                var bookingResponse = _repository.GetBooking(Bookingid, userEmail ?? string.Empty);
                return Ok(bookingResponse);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}