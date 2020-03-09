using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Controllers.CRUD
{
    public class HotelsCRUDController : Controller
    {
        private readonly Context _context;

        public HotelsCRUDController(Context context)
        {
            _context = context;
        }

        // GET: HotelsCRUD
        public async Task<IActionResult> Index()
        {
            var context = _context.Hotels.Include(h => h.Cities).Include(h => h.HotelsChain);
            return View(await context.ToListAsync());
        }

        // GET: HotelsCRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels
                .Include(h => h.Cities)
                .Include(h => h.HotelsChain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotels == null)
            {
                return NotFound();
            }

            return View(hotels);
        }

        // GET: HotelsCRUD/Create
        public IActionResult Create()
        {
            ViewData["CitiesId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["HotelsChainId"] = new SelectList(_context.HotelsChain, "Id", "Name");
            return View();
        }

        // POST: HotelsCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HotelsChainId,CitiesId,Name,Description,Trending,Availability,Image,SmallImage,Slug")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitiesId"] = new SelectList(_context.Cities, "Id", "Name", hotels.CitiesId);
            ViewData["HotelsChainId"] = new SelectList(_context.HotelsChain, "Id", "Name", hotels.HotelsChainId);
            return View(hotels);
        }

        // GET: HotelsCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }
            ViewData["CitiesId"] = new SelectList(_context.Cities, "Id", "Name", hotels.CitiesId);
            ViewData["HotelsChainId"] = new SelectList(_context.HotelsChain, "Id", "Name", hotels.HotelsChainId);
            return View(hotels);
        }

        // POST: HotelsCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HotelsChainId,CitiesId,Name,Description,Trending,Availability,Image,SmallImage,Slug")] Hotels hotels)
        {
            if (id != hotels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelsExists(hotels.Id))
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
            ViewData["CitiesId"] = new SelectList(_context.Cities, "Id", "Name", hotels.CitiesId);
            ViewData["HotelsChainId"] = new SelectList(_context.HotelsChain, "Id", "Name", hotels.HotelsChainId);
            return View(hotels);
        }

        // GET: HotelsCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.Hotels
                .Include(h => h.Cities)
                .Include(h => h.HotelsChain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotels == null)
            {
                return NotFound();
            }

            return View(hotels);
        }

        // POST: HotelsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotels = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelsExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}