using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesManagementServices : IAmenitiesManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenitiesManagementServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenities(Amenities amenities)
        {
            _context.Amenity.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenities(int id)
        {
            Amenities amenities = await GetAmenities(id);
            _context.Amenity.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task EditAmenities(Amenities amenities)
        {
            _context.Amenity.Update(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenities(int id)
        {
            return await _context.Amenity.FirstOrDefaultAsync(amenity => amenity.ID == id);
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenity.ToListAsync();
        }
    }
}
