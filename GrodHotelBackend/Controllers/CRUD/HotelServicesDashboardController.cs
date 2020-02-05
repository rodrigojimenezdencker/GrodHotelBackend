using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrodHotelBackend.Models;

namespace GrodHotelBackend.Controllers.CRUD
{
    public class HotelServicesDashboardController : Controller
    {
        private readonly Context _context;

        public HotelServicesDashboardController(Context context)
        {
            _context = context;
        }

        // GET: HotelServicesDashboard
        public async Task<IActionResult> Index()
        {
            var context = _context.HotelServices.Include(h => h.Hotels).Include(h => h.Services);
            return View(await context.ToListAsync());
        }

        // GET: HotelServicesDashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelServices = await _context.HotelServices
                .Include(h => h.Hotels)
                .Include(h => h.Services)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelServices == null)
            {
                return NotFound();
            }

            return View(hotelServices);
        }

        // GET: HotelServicesDashboard/Create
        public IActionResult Create()
        {
            ViewData["HotelsId"] = new SelectList(_context.Hotels, "Id", "Name");
            ViewData["ServicesId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: HotelServicesDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HotelsId,ServicesId,Price,Availability")] HotelServices hotelServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelsId"] = new SelectList(_context.Hotels, "Id", "Name", hotelServices.HotelsId);
            ViewData["ServicesId"] = new SelectList(_context.Services, "Id", "Name", hotelServices.ServicesId);
            return View(hotelServices);
        }

        // GET: HotelServicesDashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelServices = await _context.HotelServices.FindAsync(id);
            if (hotelServices == null)
            {
                return NotFound();
            }
            ViewData["HotelsId"] = new SelectList(_context.Hotels, "Id", "Name", hotelServices.HotelsId);
            ViewData["ServicesId"] = new SelectList(_context.Services, "Id", "Name", hotelServices.ServicesId);
            return View(hotelServices);
        }

        // POST: HotelServicesDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HotelsId,ServicesId,Price,Availability")] HotelServices hotelServices)
        {
            if (id != hotelServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelServicesExists(hotelServices.Id))
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
            ViewData["HotelsId"] = new SelectList(_context.Hotels, "Id", "Name", hotelServices.HotelsId);
            ViewData["ServicesId"] = new SelectList(_context.Services, "Id", "Name", hotelServices.ServicesId);
            return View(hotelServices);
        }

        // GET: HotelServicesDashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelServices = await _context.HotelServices
                .Include(h => h.Hotels)
                .Include(h => h.Services)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelServices == null)
            {
                return NotFound();
            }

            return View(hotelServices);
        }

        // POST: HotelServicesDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelServices = await _context.HotelServices.FindAsync(id);
            _context.HotelServices.Remove(hotelServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelServicesExists(int id)
        {
            return _context.HotelServices.Any(e => e.Id == id);
        }
    }
}
