using Microsoft.AspNetCore.Mvc;
using HotelBooking.DBContext;
using HotelBooking.Repository;
using HotelBooking.Services;
using HotelBooking.Models;
namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : Controller
    {
        private readonly IBookingService _service;
        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _service.GetBookings();

            return Ok(new
            {
                Message = bookings.Any() ? "Bookings retrieved successfully" : "No bookings found",
                Data = bookings
            });
        }


        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            var result = _service.CreateBooking(booking);
            if (result != "Booking created successfully")
                return BadRequest(result);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public IActionResult CancelBooking(int id)
        {
            var result = _service.CancelBooking(id);

            if (result != "Booking cancelled successfully")
                return BadRequest(result);

            return Ok(result);
        }
    }
}
