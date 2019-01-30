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

        public void DeleteHotel(int id)
        {
            Hotel hotels = _context.Hotels.FirstOrDefault(hotel => hotel.ID == id);
            _context.Hotels.Remove(hotels);
            _context.SaveChanges();
        }

        public void EditHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
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
