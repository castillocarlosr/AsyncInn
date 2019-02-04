using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;


namespace AsyncTDD
{
    public class UnitTest1
    {
        /// <summary>
        /// Get/Set and CRUD test for Ammenities
        /// </summary>
        [Fact]
        public void CanGetNameOfAmenities()
        {
            Amenities amenities = new Amenities();
            amenities.Name = "XboxOne";

            Assert.Equal("XboxOne", amenities.Name);
        }

        [Fact]
        public void SetAmenitiesName()
        {
            Amenities amenities = new Amenities();
            amenities.Name = "Playstation";
            amenities.Name = "Nintendo";

            Assert.Equal("Nintendo", amenities.Name);
        }

        [Fact]
        public async void CrudAmenitiesInDb()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetAmenitiesName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange  (CREATE)
                Amenities amenities = new Amenities();
                amenities.Name = "Gameboy";

                context.Amenity.Add(amenities);
                context.SaveChanges();

                //Act (READ)
                var amenityName = await context.Amenity.FirstOrDefaultAsync(x => x.Name == amenities.Name);
                //Assert
                Assert.Equal("Gameboy", amenityName.Name);

                //UPDATE
                amenityName.Name = "Atari";
                context.Update(amenityName);
                context.SaveChanges();
                var updateAmenity = await context.Amenity.FirstOrDefaultAsync(x => x.Name == amenityName.Name);
                Assert.Equal("Atari", updateAmenity.Name);

                //DELETE
                context.Amenity.Remove(updateAmenity);
                context.SaveChanges();
                var deleteAmenity = await context.Amenity.FirstOrDefaultAsync(x => x.Name == updateAmenity.Name);
                Assert.True(deleteAmenity == null);
            }
        }

        /// <summary>
        /// Get/Set and CRUD test for Hotel
        /// </summary>
        [Fact]
        public void CanGetHotelInformation()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Best Hotel";
            hotel.Address = "123 Avenue";
            hotel.Phone = "555-444-1234";

            Assert.Equal("Best Hotel", hotel.Name);
            Assert.Equal("123 Avenue", hotel.Address);
            Assert.Equal("555-444-1234", hotel.Phone);
        }

        [Fact]
        public void SetHotelInformation()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Universal Hotel";
            hotel.Address = "123 Avenue";
            hotel.Phone = "555-444-1234";

            hotel.Name = "DisneyLand Hotel";
            hotel.Address = "555 Highway, Racoon City, NJ";
            hotel.Phone = "010-110-0101";

            Assert.Equal("DisneyLand Hotel", hotel.Name);
            Assert.Equal("555 Highway, Racoon City, NJ", hotel.Address);
            Assert.Equal("010-110-0101", hotel.Phone);
        }

        [Fact]
        public async void CrudHotelnDb()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange  (CREATE)
                Hotel hotel = new Hotel();
                hotel.Name = "Star Trek Hotel";

                context.Hotels.Add(hotel);
                context.SaveChanges();

                //Act (READ)
                var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);
                //Assert
                Assert.Equal("Star Trek Hotel", hotelName.Name);

                //UPDATE
                hotelName.Name = "Star Wars Inn";
                context.Update(hotelName);
                context.SaveChanges();
                var updateHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotelName.Name);
                Assert.Equal("Star Wars Inn", updateHotel.Name);

                //DELETE
                context.Hotels.Remove(updateHotel);
                context.SaveChanges();
                var deleteAmenity = await context.Hotels.FirstOrDefaultAsync(x => x.Name == updateHotel.Name);
                Assert.True(deleteAmenity == null);
            }
        }

        /// <summary>
        /// Get/Set and CRUD test for Room
        /// </summary>
        [Fact]
        public void CanGetRoomInformation()
        {
            Room room = new Room();
            room.Name = "popcorn room";
            room.Layouts = Room.Layout.OneBedroom;

            Assert.Equal("popcorn room", room.Name);
            Assert.Equal(Room.Layout.OneBedroom, room.Layouts);
        }

        [Fact]
        public void SetRoomInformation()
        {
            Room room = new Room();
            room.Name = "popcorn room";
            room.Layouts = Room.Layout.TwoBedroom;

            room.Name = "Chocolate Room";
            room.Layouts = Room.Layout.Studio;

            Assert.Equal("Chocolate Room", room.Name);
            Assert.Equal(Room.Layout.Studio, room.Layouts);
        }

        [Fact]
        public async void CrudRoomInDb()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange  (CREATE)
                Room room = new Room();
                room.Name = "LARGE bedroom";

                context.Rooms.Add(room);
                context.SaveChanges();

                //Act (READ)
                var roomName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);
                //Assert
                Assert.Equal("LARGE bedroom", roomName.Name);

                //UPDATE
                roomName.Name = "4 bedrooms";
                context.Update(roomName);
                context.SaveChanges();
                var updateRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == roomName.Name);
                Assert.Equal("4 bedrooms", updateRoom.Name);

                //DELETE
                context.Rooms.Remove(updateRoom);
                context.SaveChanges();
                var deleteRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == updateRoom.Name);
                Assert.True(deleteRoom == null);
            }
        }

        /// <summary>
        /// Get/Set and CRUD test for Hotel-Room
        /// </summary>
        [Fact]
        public void CanGetHotelRoom()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 9;
            hotelRoom.RoomNumber = 888;
            hotelRoom.RoomID = 7;
            hotelRoom.Rate = 170;
            hotelRoom.PetFriendly = true;

            Assert.Equal(9, hotelRoom.HotelID);
            Assert.Equal(7, hotelRoom.RoomID);
            Assert.Equal(888, hotelRoom.RoomNumber);
            Assert.Equal(170, hotelRoom.Rate);
            Assert.True(hotelRoom.PetFriendly);
        }

        [Fact]
        public void SetHotelRoom()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 9;
            hotelRoom.RoomNumber = 888;
            hotelRoom.RoomID = 7;
            hotelRoom.Rate = 170;
            hotelRoom.PetFriendly = true;

            hotelRoom.HotelID = 11;
            hotelRoom.RoomNumber = 555;
            hotelRoom.RoomID = 8;
            hotelRoom.Rate = 199;
            hotelRoom.PetFriendly = false;

            Assert.Equal(11, hotelRoom.HotelID);
            Assert.Equal(8, hotelRoom.RoomID);
            Assert.Equal(555, hotelRoom.RoomNumber);
            Assert.Equal(199, hotelRoom.Rate);
            Assert.False(hotelRoom.PetFriendly);
        }

        [Fact]
        public async void CrudHotelRoomInDb()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetHotelRoomName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange  (CREATE)
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.HotelID = 1;
                hotelRoom.RoomID = 2;

                context.Add(hotelRoom);
                context.SaveChanges();

                //Act (READ)
                var hotelRoomIDs = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelRoom.HotelID && x.RoomID == hotelRoom.RoomID);
                //Assert
                Assert.Equal(1, hotelRoom.HotelID);
                Assert.Equal(2, hotelRoom.RoomID);

                //UPDATE
                /* Can Not Update A composite key.  Has To delete first, then create new rather than update.
                hotelRoomIDs.HotelID = 6;
                hotelRoomIDs.RoomID = 7;
                context.Update(hotelRoomIDs);
                context.SaveChanges();
                var updateHotelRooms = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelRoom.HotelID && x.RoomID == hotelRoom.RoomID);
                Assert.Equal(6, updateHotelRooms.HotelID);
                Assert.Equal(7, updateHotelRooms.RoomID);
                */

                //DELETE
                context.HotelRooms.Remove(hotelRoomIDs);
                context.SaveChanges();
                var deleteRoom = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelRoom.HotelID && x.RoomID == hotelRoom.RoomID);
                Assert.True(deleteRoom == null);
            }
        }

        /// <summary>
        /// Get/Set and CRUD test for Room-Amenities
        /// </summary>
        [Fact]
        public void CanGetRoomAmenities()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 12;
            roomAmenities.RoomID = 13;

            Assert.Equal(12, roomAmenities.AmenitiesID);
            Assert.Equal(13, roomAmenities.RoomID);
        }

        [Fact]
        public void SetRoomAmenities()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 8;
            roomAmenities.RoomID = 11;

            Assert.Equal(8, roomAmenities.AmenitiesID);
            Assert.Equal(11, roomAmenities.RoomID);
        }

        [Fact]
        public async void CrudRoomAmenitiesInDb()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetRoomAmenities")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange  (CREATE)
                RoomAmenities roomAmenities = new RoomAmenities();
                roomAmenities.AmenitiesID = 7;
                roomAmenities.RoomID = 8;

                context.Add(roomAmenities);
                context.SaveChanges();

                //Act (READ)
                var roomAmenitiesIDs = await context.RoomAmenity.FirstOrDefaultAsync(x => x.AmenitiesID == roomAmenities.AmenitiesID && x.RoomID == roomAmenities.RoomID);
                //Assert
                Assert.Equal(7, roomAmenities.AmenitiesID);
                Assert.Equal(8, roomAmenities.RoomID);

                //UPDATE
                /*  Can Not Update A composite key.  Has To delete first, then create new rather than update.
                roomAmenitiesIDs.AmenitiesID = 12;
                roomAmenitiesIDs.RoomID = 13;
                context.Update(roomAmenitiesIDs);
                context.SaveChanges();
                var updateHotelRooms = await context.RoomAmenity.FirstOrDefaultAsync(x => x.AmenitiesID == roomAmenities.AmenitiesID && x.RoomID == roomAmenities.RoomID);
                Assert.Equal(12, updateHotelRooms.AmenitiesID);
                Assert.Equal(13, updateHotelRooms.RoomID);
                */

                //DELETE
                context.RoomAmenity.Remove(roomAmenitiesIDs);
                context.SaveChanges();
                var deleteRoomAmenities = await context.RoomAmenity.FirstOrDefaultAsync(x => x.AmenitiesID == roomAmenities.AmenitiesID && x.RoomID == roomAmenities.RoomID);
                Assert.True(deleteRoomAmenities == null);
            }
        }
    }
}
