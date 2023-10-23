using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            var hotels = _context.Hotels.Select(hotel => new HotelDto {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId,
                CityName = hotel.City != null ? hotel.City.Name : null
            });
            return hotels;
        }
        
        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            var hotelToReturn = _context.Hotels
                    .Include(h => h.City)
                    .FirstOrDefault(h => h.HotelId == hotel.HotelId);
            return new HotelDto {
                HotelId = hotelToReturn?.HotelId ?? 0,
                Name = hotelToReturn?.Name,
                Address = hotelToReturn?.Address,
                CityId = hotelToReturn?.CityId ?? 0,
                CityName = hotelToReturn?.City?.Name
                };
        }
    }
}