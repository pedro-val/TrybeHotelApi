using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
public IEnumerable<RoomDto> GetRooms(int HotelId)
{
    var rooms = _context.Rooms
        .Include(r => r.Hotel)
        .Where(r => r.HotelId == HotelId);
    var roomsDto = rooms.Select(r => new RoomDto {
        RoomId = r.RoomId,
        Name = r.Name,
        Capacity = r.Capacity,
        Image = r.Image,
        Hotel = r.Hotel == null ? null : new HotelDto {
            HotelId = r.Hotel.HotelId,
            Name = r.Hotel.Name,
            Address = r.Hotel.Address,
            CityId = r.Hotel.CityId,
            CityName = r.Hotel.City == null ? null : r.Hotel.City.Name
        }
    });
    return roomsDto;
}

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room) {
            throw new NotImplementedException(); 
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId) {
            throw new NotImplementedException();
        }
    }
}