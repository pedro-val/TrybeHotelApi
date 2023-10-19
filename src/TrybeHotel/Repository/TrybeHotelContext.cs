using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;

namespace TrybeHotel.Repository;
public class TrybeHotelContext : DbContext, ITrybeHotelContext
{
    public TrybeHotelContext(DbContextOptions<TrybeHotelContext> options) : base(options) 
    { 
    }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Hotel>? Hotels { get; set; }
    public DbSet<Room>? Rooms { get; set; } 


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=127.0.0.1;Database=trybe_hotel_db;User=sa;Password=TrybeHotel12!;TrustServerCertificate=true;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}