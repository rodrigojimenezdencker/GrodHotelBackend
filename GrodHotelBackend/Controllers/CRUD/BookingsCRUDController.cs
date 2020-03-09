using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrodHotelBackend.Controllers.CRUD
{
    public class BookingsCRUDController : Controller
    {
        private readonly Context _context;

        public BookingsCRUDController(Context context)
        {
            _context = context;
        }

        // GET: BookingsDashboard
        public async Task<IActionResult> Index()
        {
            var context = _context.Bookings.Include(b => b.Clients).Include(b => b.Rooms);
            return View(await context.ToListAsync());
        }

        // GET: BookingsDashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Clients)
                .Include(b => b.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: BookingsDashboard/Create
        public IActionResult Create()
        {
            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "Dni");
            ViewData["RoomsId"] = new SelectList(_context.Rooms, "Id", "Id");
            return View();
        }

        // POST: BookingsDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientsId,RoomsId,EntryDate,LeavingDate,TotalPrice,AdultNumbers,MinorNumbers,ConfirmationDate")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "Dni", bookings.ClientsId);
            ViewData["RoomsId"] = new SelectList(_context.Rooms, "Id", "Id", bookings.RoomsId);
            return View(bookings);
        }

        // GET: BookingsDashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "Dni", bookings.ClientsId);
            ViewData["RoomsId"] = new SelectList(_context.Rooms, "Id", "Id", bookings.RoomsId);
            return View(bookings);
        }

        // POST: BookingsDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientsId,RoomsId,EntryDate,LeavingDate,TotalPrice,AdultNumbers,MinorNumbers,ConfirmationDate")] Bookings bookings)
        {
            if (id != bookings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.Id))
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
            ViewData["ClientsId"] = new SelectList(_context.Clients, "Id", "Dni", bookings.ClientsId);
            ViewData["RoomsId"] = new SelectList(_context.Rooms, "Id", "Id", bookings.RoomsId);
            return View(bookings);
        }

        // GET: BookingsDashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Clients)
                .Include(b => b.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // POST: BookingsDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(bookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}