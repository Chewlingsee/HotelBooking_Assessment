using HotelBooking.Models;

namespace HotelBooking.Services
{
    public interface IBookingService
    {
        public List<Booking> GetBookings();
        public string CreateBooking(Booking booking);
        public string CancelBooking(int id);
    }
}
