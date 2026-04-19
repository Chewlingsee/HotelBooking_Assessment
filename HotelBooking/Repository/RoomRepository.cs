using HotelBooking.Models;
using HotelBooking.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingContext _context;

        public RoomRepository(HotelBookingContext context)
        {
            _context = context;
        }
        public List<Room> GetAllRooms()
        {
            return _context.Room.ToList();
        }

        public Room? GetById(int id)
        {
            return _context.Room.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            _context.SaveChanges();
        }
    }
}
