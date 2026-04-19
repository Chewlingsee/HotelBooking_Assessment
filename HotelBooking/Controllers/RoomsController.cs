using HotelBooking.DBContext;
using HotelBooking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepo;

        public RoomsController(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        [HttpGet("rooms")]
        public IActionResult GetRooms()
        {
            var roomList = _roomRepo.GetAllRooms();
            return Ok(roomList);
        }


    }
}
