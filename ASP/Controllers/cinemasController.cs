using ASP.Areas.Identity.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Controllers
{
    public class cinemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public cinemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cinemas
        public async Task<IActionResult> Index()
        {
            return View(await _context.cinemas.ToListAsync());
        }

        // GET: cinemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.cinemas
                .FirstOrDefaultAsync(m => m.id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // GET: cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cinemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name")] cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: cinemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.cinemas.FindAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }

        // POST: cinemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name")] cinema cinema)
        {
            if (id != cinema.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cinemaExists(cinema.id))
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
            return View(cinema);
        }

        // GET: cinemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.cinemas
                .FirstOrDefaultAsync(m => m.id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // POST: cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cinemas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cinemas'  is null.");
            }
            var cinema = await _context.cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.cinemas.Remove(cinema);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cinemaExists(int id)
        {
            return _context.cinemas.Any(e => e.id == id);
        }
    }
}
