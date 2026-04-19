using HotelBooking.Models;

namespace HotelBooking.Repository
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        Room? GetById(int id);
        void UpdateRoom(Room room);
    }
}
