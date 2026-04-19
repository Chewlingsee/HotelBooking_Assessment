using HotelBooking.DBContext;
using HotelBooking.Models;
using HotelBooking.Repository;
using HotelBooking.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelBookingContext>(option => option.UseInMemoryDatabase("HotelDB"));
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<HotelBookingContext>();
    if(db != null)
    {
         if (!db.Room.Any())
            {
                db.Room.AddRange(
                    new Room { Id = 1, Name = "101", Type = "Single", IsAvailable = true },
                    new Room { Id = 2, Name = "102", Type = "Single", IsAvailable = true },
                    new Room { Id = 3, Name = "103", Type = "Single", IsAvailable = true },
                    new Room { Id = 4, Name = "201", Type = "Double", IsAvailable = true },
                    new Room { Id = 5, Name = "301", Type = "Suite", IsAvailable = true }
                );
                db.SaveChanges();
            }
        }
    }
   

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
