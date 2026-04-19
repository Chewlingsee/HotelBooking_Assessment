using HotelBooking.Repository;
using HotelBooking.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HotelBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingrepo;
        private readonly IRoomRepository _roomrepo;
        public BookingService(IBookingRepository bookingrepo, IRoomRepository roomrepo)
        {
            _bookingrepo = bookingrepo;
            _roomrepo = roomrepo;
        }

        public List<Booking> GetBookings()
        {
            return _bookingrepo.GetAllBookings();
        }

        public string CreateBooking(Booking booking)
        {
            var room = _roomrepo.GetById(booking.RoomId);

            if (room == null)
                return "Room not found";
            if (room.IsAvailable == false)
                return "Room is not available";
            if (booking.CheckOutDate <= booking.CheckInDate)
                return "Invalid Date. Check out date must after check in date.";
            if (booking.CheckInDate < DateOnly.FromDateTime(DateTime.Now))
                return "Invalid Date. Check in date must be in the future.";

            room.IsAvailable = false;
            _roomrepo.UpdateRoom(room);

            _bookingrepo.AddBooking(booking);

            return "Booking created successfully";

        }

        public string CancelBooking(int bookingId)
        {
            var booking = _bookingrepo.GetBookingById(bookingId);

            if (booking == null)
                return "Booking not found";

            var room = _roomrepo.GetById(booking.RoomId);

            if (room != null)
            {
                room.IsAvailable = true;
                _roomrepo.UpdateRoom(room);
            }

            _bookingrepo.DeleteBooking(bookingId);

            return "Booking cancelled successfully";
        }
    }
}
