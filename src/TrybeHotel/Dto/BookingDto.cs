using System.ComponentModel.DataAnnotations;
using TrybeHotel.Models;

namespace TrybeHotel.Dto
{
    public class BookingDtoInsert
    {
        [Required]
        public string CheckIn { get; set; }
        [Required]
        public string CheckOut { get; set; }
        [Required]
        public int GuestQuant { get; set; }
        [Required]
        public int RoomId { get; set; }
    }

    public class BookingResponse
    {
        public int BookingId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestQuant { get; set; }
        public Room? Room { get; set; }
    }
}