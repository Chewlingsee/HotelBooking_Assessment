using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DBContext
{
    public class HotelBookingContext : DbContext
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
