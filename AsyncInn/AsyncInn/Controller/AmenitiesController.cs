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
    public class AmenitiesController : Controller
    {
        private readonly IAmenitiesManager _context;

        public AmenitiesController(IAmenitiesManager context)
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAmenities());
            //return View(await _context.Amenities.ToListAsync());
        }

        //This is supposed to be the search from the docs
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var amenity = await _context.GetAmenities();
            if (!String.IsNullOrEmpty(searchString))
            {
                amenity = amenity.Where(a => a.Name.Contains(searchString));
            }
            return View(amenity);
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var amenities = await _context.GetAmenities(id);
                //.FirstOrDefaultAsync(m => m.ID == id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                //_context.CreateAmenities(amenities);
                await _context.CreateAmenities(amenities);

                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var amenities = await _context.GetAmenities(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.EditAmenities(amenities);
                    //_context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.ID))
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
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var amenities = await _context.GetAmenities(id);
               //.FirstOrDefaultAsync(m => m.ID == id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*
            var amenities = await _context.Amenity.FindAsync(id);
            _context.Amenity.Remove(amenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
            await _context.DeleteAmenities(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenitiesExists(int id)
        {
            //return _context.Amenity.Any(e => e.ID == id);
            return _context.GetAmenities(id) != null;
        }
    }
}
