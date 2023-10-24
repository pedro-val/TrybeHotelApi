using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email) ?? throw new ArgumentException("User not found");
            var room = _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefault(r => r.RoomId == booking.RoomId);
            if (room?.Capacity < booking.GuestQuant)
            {
                throw new ArgumentException("Guest quantity over room capacity");
            }
            var bookingToAdd = new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                RoomId = booking.RoomId,
                UserId = user.UserId
            };
            _context.Bookings.Add(bookingToAdd);
            _context.SaveChanges();
            var bookingResponse = _context.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
                .Select(b => new BookingResponse
                {
                    BookingId = b.BookingId,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    GuestQuant = b.GuestQuant,
                    Room = _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefault(r => r.RoomId == booking.RoomId)
                })
                .FirstOrDefault(b => b.BookingId == bookingToAdd.BookingId) ?? throw new ArgumentException("Booking not found");
            return bookingResponse;
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            var bookingResponse = _context.Bookings
                .Where(b => b.User.Email == email)
                .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
                .Select(b => new BookingResponse
                {
                    BookingId = b.BookingId,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    GuestQuant = b.GuestQuant,
                    Room = _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefault(r => r.RoomId == b.RoomId)
                })
                .FirstOrDefault(b => b.BookingId == bookingId);
            return bookingResponse ?? throw new ArgumentException("Booking not found");
        }

        public Room GetRoomById(int RoomId)
        {
            var room = _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefault(r => r.RoomId == RoomId);
            if (room == null)
            {
                throw new ArgumentException("Room not found");
            }
            return room;
        }

    }

}