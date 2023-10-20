using TrybeHotel.Models;
namespace TrybeHotel.Dto 
{
    public class CityDto {
        public int CityId { get; set; }
        public string? Name { get; set; }

        // public CityDto(City city) {
        //     Id = city.CityId;
        //     Nome = city.Name;
        // }
    }
}