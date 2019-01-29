using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext :DbContext 
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite key
            modelBuilder.Entity<RoomAmenities>().HasKey(
                ra => new { ra.AmenitiesID, ra.RoomID }
                );

            modelBuilder.Entity<HotelRoom>().HasKey(
                hr => new { hr.HotelID, hr.RoomNumber }
                );

            //Data Seeding
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Seattle Inn",
                    Address = "1 CodeFellow Dr., Seattle, WA 98121",
                    Phone = "555-999-1234",
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Springfield Inn",
                    Address = "2 Simpsons Dr., Springfield, AK 98765",
                    Phone = "222-333-1234",
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Mars Inn",
                    Address = "3 Futurama Up., New New York, NY 11238",
                    Phone = "111-222-2345",
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Game Of Throne Inn",
                    Address = "4 Dragon Ln., Westoro, FL 44556",
                    Phone = "444-555-6789",
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Pickle Rick Inn",
                    Address = "5 Morty Dr., Bellevue, WA 10001",
                    Phone = "101-001-1001",
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "SuperHero room",
                    Layouts = Room.Layout.OneBedroom,
                },
                new Room
                {
                    ID = 2,
                    Name = "OuterSpace room",
                    Layouts = Room.Layout.TwoBedroom,
                },
                new Room
                {
                    ID = 3,
                    Name = "Artist room",
                    Layouts = Room.Layout.Studio,
                },
                new Room
                {
                    ID = 4,
                    Name = "SideKick room",
                    Layouts = Room.Layout.Studio,
                },
                new Room
                {
                    ID = 5,
                    Name = "Alien room",
                    Layouts = Room.Layout.OneBedroom,
                },
                new Room
                {
                    ID = 6,
                    Name = "The Incredibles Family room",
                    Layouts = Room.Layout.TwoBedroom,
                }
                );
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker",
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Air Conditioner",
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Mini Bar",
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Egyption Satin 5000 thread Sheets",
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Gigabit Wifi Internet",
                }
                );
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Amenities> Amenity { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAmenities> RoomAmenity { get; set; }

    }


}
