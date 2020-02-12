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
    public class HotelsChainCRUDController : Controller
    {
        private readonly Context _context;

        public HotelsChainCRUDController(Context context)
        {
            _context = context;
        }

        // GET: HotelsChainDashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelsChain.ToListAsync());
        }

        // GET: HotelsChainDashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelsChain = await _context.HotelsChain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelsChain == null)
            {
                return NotFound();
            }

            return View(hotelsChain);
        }

        // GET: HotelsChainDashboard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelsChainDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Availability")] HotelsChain hotelsChain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelsChain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelsChain);
        }

        // GET: HotelsChainDashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelsChain = await _context.HotelsChain.FindAsync(id);
            if (hotelsChain == null)
            {
                return NotFound();
            }
            return View(hotelsChain);
        }

        // POST: HotelsChainDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Availability")] HotelsChain hotelsChain)
        {
            if (id != hotelsChain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelsChain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelsChainExists(hotelsChain.Id))
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
            return View(hotelsChain);
        }

        // GET: HotelsChainDashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelsChain = await _context.HotelsChain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelsChain == null)
            {
                return NotFound();
            }

            return View(hotelsChain);
        }

        // POST: HotelsChainDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelsChain = await _context.HotelsChain.FindAsync(id);
            _context.HotelsChain.Remove(hotelsChain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelsChainExists(int id)
        {
            return _context.HotelsChain.Any(e => e.Id == id);
        }
    }
}
