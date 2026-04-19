# Hotel Booking API

## Overview
A simple Hotel Room Booking REST API built using ASP.NET Core Web API with Clean Architecture.

It allows users to:
- View rooms
- Create bookings
- View all bookings

## Features include:
- List all rooms
- Create booking for a room
- Get all bookings
- Prevent double booking (room availability check)
- Validate check-in and check-out dates
- Swagger API documentation

## Additional Feature
- Added Delete Booking feature to cancel a booking.
- When a booking is deleted, the room is set back to available.

# Architecture
1. Controllers
- Handle HTTP requests and responses (API endpoints)

2. Services
- Contain business logic and validation rules

3. Repository
- Handle database operations using Entity Framework Core (In-Memory DB)

4. Models
- Define the data structure of the application (include Room and Booking entities)

5. DbContext
- Manages database connection
- Defines tables using DbSet
- Uses EF Core In-Memory database

## Dependency Injection
Used built-in DI for:
- IRoomRepository → RoomRepository
- IBookingRepository → BookingRepository
- IBookingService → BookingService

## Packages (NuGet Installation)
- dotnet add package xunit
- dotnet add package xunit.runner.visualstudio
- dotnet add package Microsoft.NET.Test.Sdk
- dotnet add package Moq
- dotnet add package Microsoft.EntityFrameworkCore.InMemory

## How to Run
1. Open project in Visual Studio  
2. Run the project (F5)  
3. Open Swagger in browser: https://localhost:xxxx/swagger
4. Test API endpoints using Swagger UI

## Design Decisions
- The project is structured using Clean Architecture to clearly separate API, logic, and data layers.
- Business rules such as booking validation and room availability are handled in the Service layer instead of Controllers.
- Repository Pattern is used to centralize all database operations and keep the codebase clean.
- In-Memory database is chosen to simplify development and avoid external database setup.
- Swagger is included to make testing and understanding the API easier during development.

Testing
- xUnit is used as the unit testing framework
- Moq is used to mock dependencies
- Tests are written for service layer logic
- Microsoft.NET.Test.Sdk is required to run tests in .NET 8