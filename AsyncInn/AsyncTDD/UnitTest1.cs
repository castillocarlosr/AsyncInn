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
        /// Started xUnit Testing
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
        public async void SaveAmenitiesInDb()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseInMemoryDatabase("GetAmenitiesName")
                .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Amenities amenities = new Amenities();
                amenities.Name = "Gameboy";

                context.Amenity.Add(amenities);
                context.SaveChanges();

                //Act
                var amenityName = await context.Amenity.FirstOrDefaultAsync(x => x.Name == amenities.Name);

                //Assert
                Assert.Equal("Gameboy", amenityName.Name);
            }
        }
    }
}
