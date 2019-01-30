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

        public void DeleteAmenities(int id)
        {
            Amenities amenities = _context.Amenity.FirstOrDefault(amenity => amenity.ID == id);
            _context.Amenity.Remove(amenities);
            _context.SaveChanges();
        }

        public void EditAmenities(Amenities amenities)
        {
            _context.Amenity.Update(amenities);
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
