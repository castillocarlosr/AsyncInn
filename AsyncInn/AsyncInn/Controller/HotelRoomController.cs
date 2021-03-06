﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Constrollers
{
    public class HotelRoomController : Controller
    {
        private readonly AsyncInnDbContext _context;


        public HotelRoomController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRoom
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotels).Include(h => h.Rooms);
            return View(await asyncInnDbContext.ToListAsync());
        }
        

        // GET: HotelRoom/Details/5
        public async Task<IActionResult> Details(int HotelID, int RoomID)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var hotelRoom = await _context.HotelRooms
            
                .Include(h => h.Hotels)
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomID == RoomID);
            
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRoom/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Edit/5
        public async Task<IActionResult> Edit(int HotelID, int RoomID)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            //var hotelRoom = await _context.HotelRooms.FindAsync(id);
            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotels)
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomID == RoomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Delete/5
        public async Task<IActionResult> Delete(int HotelID, int RoomID)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var hotelRoom = await _context.HotelRooms

                .Include(h => h.Hotels)
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomID == RoomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomID)
        {
            var hotelRoom = await _context.HotelRooms

                .Include(h => h.Hotels)
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomID == RoomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
            /*
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */

        }
        
        private bool HotelRoomExists(int id)
        {
            //_context.HotelRooms.Any(e => e.HotelID == id);
            return _context.HotelRooms.Any(e => e.RoomID == id);
        }
        
    }
}
