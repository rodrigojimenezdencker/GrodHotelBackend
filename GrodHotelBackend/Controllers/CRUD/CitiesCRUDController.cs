using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Controllers.CRUD
{
    public class CitiesCRUDController : Controller
    {
        private readonly Context _context;

        public CitiesCRUDController(Context context)
        {
            _context = context;
        }

        // GET: CitiesDashboard
        public async Task<IActionResult> Index()
        {
            var context = _context.Cities.Include(c => c.Countries);
            return View(await context.ToListAsync());
        }

        // GET: CitiesDashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cities = await _context.Cities
                .Include(c => c.Countries)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cities == null)
            {
                return NotFound();
            }

            return View(cities);
        }

        // GET: CitiesDashboard/Create
        public IActionResult Create()
        {
            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: CitiesDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountriesId,Name")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Name", cities.CountriesId);
            return View(cities);
        }

        // GET: CitiesDashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cities = await _context.Cities.FindAsync(id);
            if (cities == null)
            {
                return NotFound();
            }
            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Name", cities.CountriesId);
            return View(cities);
        }

        // POST: CitiesDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountriesId,Name")] Cities cities)
        {
            if (id != cities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitiesExists(cities.Id))
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
            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Name", cities.CountriesId);
            return View(cities);
        }

        // GET: CitiesDashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cities = await _context.Cities
                .Include(c => c.Countries)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cities == null)
            {
                return NotFound();
            }

            return View(cities);
        }

        // POST: CitiesDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cities = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(cities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitiesExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}