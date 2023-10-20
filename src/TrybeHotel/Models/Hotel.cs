namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 1. Implemente as models da aplicação
// CityId: Chave estrangeira para a model City (int) Cada hotel tem vários quartos. A propriedade de navegação para Room deve se chamar Rooms (anulável). Cada hotel tem apenas uma cidade. A propriedade de navegação para City deve se chamar City (anulável).
public class Hotel {
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public virtual List<Room>? Rooms { get; set; }

    [ForeignKey("CityId")]
    public int CityId { get; set; }
    public City? City { get; set; }

    // public Hotel() {
    //     Name = "";
    //     Address = "";
    //     Rooms = new List<Room>();
    // }
}