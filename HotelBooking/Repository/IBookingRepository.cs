using HotelBooking.Models;
namespace HotelBooking.Repository
{
    public interface IBookingRepository
    {
        public List<Booking> GetAllBookings();
        public void AddBooking(Booking booking);
        public Booking? GetBookingById(int id);

        public void DeleteBooking(int id);

    }
}
