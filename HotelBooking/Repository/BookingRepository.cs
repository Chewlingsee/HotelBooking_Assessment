using HotelBooking.DBContext;
using HotelBooking.Models;
namespace HotelBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelBookingContext _context;
        public BookingRepository(HotelBookingContext context)
        {
            _context = context;
        }
        public List<Booking> GetAllBookings()
        {
            return _context.Booking.ToList();
        }
        public void AddBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            _context.SaveChanges();
        }

        public Booking? GetBookingById(int id)
        {
            return _context.Booking.FirstOrDefault(b => b.Id == id);
        }

        public void DeleteBooking(int id)
        {
            var booking = GetBookingById(id);

            if (booking != null)
            {
                _context.Booking.Remove(booking);
                _context.SaveChanges();
            }
        }

    }
}
