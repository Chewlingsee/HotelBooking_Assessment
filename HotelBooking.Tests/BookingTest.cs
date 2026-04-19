using Xunit;
using Moq;
using HotelBooking.Models;
using HotelBooking.Repository;
using HotelBooking.Services;
using System;

namespace HotelBooking.Tests
{
    public class BookingTest
    {
        [Fact]
        public void CreateBooking_WhenRoomIsAvailable_Succeed()
        {
            // Arrange
            var roomRepo = new Mock<IRoomRepository>();
            var bookingRepo = new Mock<IBookingRepository>();

            roomRepo.Setup(r => r.GetById(1))
                .Returns(new Room
                {
                    Id = 1,
                    Name = "301",
                    Type = "Suite",
                    IsAvailable = true
                });

            var service = new BookingService(
                bookingRepo.Object,
                roomRepo.Object
            );

            var booking = new Booking
            {
                RoomId = 1,
                GuestName = "Meiling",
                CheckInDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                CheckOutDate = DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            };

            var result = service.CreateBooking(booking);

            Assert.Equal("Booking created successfully", result);
        }
    }
}