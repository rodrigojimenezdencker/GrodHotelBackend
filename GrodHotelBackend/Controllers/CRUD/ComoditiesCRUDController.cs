using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Controllers.CRUD
{
    public class ComoditiesCRUDController : Controller
    {
        private readonly Context _context;

        public ComoditiesCRUDController(Context context)
        {
            _context = context;
        }

        // GET: ComoditiesDashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comodities.ToListAsync());
        }

        // GET: ComoditiesDashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comodities = await _context.Comodities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comodities == null)
            {
                return NotFound();
            }

            return View(comodities);
        }

        // GET: ComoditiesDashboard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComoditiesDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Comodities comodities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comodities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comodities);
        }

        // GET: ComoditiesDashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comodities = await _context.Comodities.FindAsync(id);
            if (comodities == null)
            {
                return NotFound();
            }
            return View(comodities);
        }

        // POST: ComoditiesDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Comodities comodities)
        {
            if (id != comodities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comodities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComoditiesExists(comodities.Id))
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
            return View(comodities);
        }

        // GET: ComoditiesDashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comodities = await _context.Comodities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comodities == null)
            {
                return NotFound();
            }

            return View(comodities);
        }

        // POST: ComoditiesDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comodities = await _context.Comodities.FindAsync(id);
            _context.Comodities.Remove(comodities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComoditiesExists(int id)
        {
            return _context.Comodities.Any(e => e.Id == id);
        }
    }
}