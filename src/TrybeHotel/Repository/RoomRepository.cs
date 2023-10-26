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
        _context.Rooms.Add(room);
        _context.SaveChanges();
        var roomToReturn = _context.Rooms
            .Include(r => r.Hotel)
            .FirstOrDefault(r => r.RoomId == room.RoomId);
        var hotelToReturn = _context.Hotels
            .Include(h => h.City)
            .FirstOrDefault(h => h.HotelId == room.HotelId);    
        return new RoomDto {
            RoomId = roomToReturn?.RoomId ?? 0,
            Name = roomToReturn?.Name,
            Capacity = roomToReturn?.Capacity ?? 0,
            Image = roomToReturn?.Image,
            Hotel = roomToReturn?.Hotel == null ? null : new HotelDto {
                HotelId = roomToReturn.Hotel.HotelId,
                Name = roomToReturn.Hotel.Name,
                Address = roomToReturn.Hotel.Address,
                CityId = roomToReturn.Hotel.CityId,
                CityName = hotelToReturn?.City == null ? null : hotelToReturn.City.Name
            }
        };
    }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId) {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId);
            if (room != null) {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}