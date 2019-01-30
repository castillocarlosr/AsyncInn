using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomManagementServices : IRoomManager
    {
        private AsyncInnDbContext _context { get; }

        public RoomManagementServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public void DeleteRoom(int id)
        {
            Room rooms = _context.Rooms.FirstOrDefault(room => room.ID == id);
            _context.Rooms.Remove(rooms);
            _context.SaveChanges();
        }

        public void EditRoom(Room room)
        {
            _context.Rooms.Update(room);
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(room => room.ID == id);
        }

        public async Task<IEnumerable<Room>> GetRoom()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
