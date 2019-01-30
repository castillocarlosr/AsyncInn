using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelManagementServices : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        public HotelManagementServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotels = await GetHotel(id);
            _context.Hotels.Remove(hotels);
            await _context.SaveChangesAsync();
        }

        public async Task EditHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);
        }

        public async Task<IEnumerable<Hotel>> GetHotel()
        {
            return await _context.Hotels.ToListAsync();
        }
    }
}
