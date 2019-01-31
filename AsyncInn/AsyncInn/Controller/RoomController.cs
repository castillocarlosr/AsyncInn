using System;
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
    public class RoomController : Controller
    {
        private readonly IRoomManager _context;

        public RoomController(IRoomManager context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetRoom());
        }

        //This is supposed to be the search from the docs
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var room = await _context.GetRoom();
            if (!String.IsNullOrEmpty(searchString))
            {
                room = room.Where(r => r.Name.Contains(searchString));
            }
            return View(room);
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var room = await _context.GetRoom(id);
                //.FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layouts")] Room room)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(room);
                //await _context.SaveChangesAsync();
                await _context.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layouts")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(room);
                    //await _context.SaveChangesAsync();
                    await _context.EditRoom(room);
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            return View(room);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var room = await _context.GetRoom(id);
                //.FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
            await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            //return _context.Rooms.Any(e => e.ID == id);
            return _context.GetRoom(id) != null;
        }
    }
}
