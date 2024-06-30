using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradersDiary.Data;
using TradersDiary.Models;

namespace TradersDiary.Controllers
{
    public class DealsController : Controller
    {
        private readonly TradersDiaryContext _context;

        public DealsController(TradersDiaryContext context)
        {
            _context = context;
        }

        // GET: Deals
        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            var deals = await _context.Deal.ToListAsync();

            int pageSize = 12;
            return View(await PaginatedList<Deal>.CreateAsync(deals, pageNumber ?? 1, pageSize));
        }

        // GET: Deals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET: Deals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OpeningDate,Expiration,ClosingDate,Price,Direction,Result")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                deal.Id = Guid.NewGuid();
                deal.ClosingDate = deal.OpeningDate.AddMinutes(deal.Expiration);
                _context.Add(deal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deal);
        }

        // GET: Deals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deal.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            return View(deal);
        }

        // POST: Deals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OpeningDate,Price,Direction,Result")] Deal deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(deal.Id))
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
            return View(deal);
        }

        // GET: Deals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deal = await _context.Deal.FindAsync(id);
            if (deal != null)
            {
                _context.Deal.Remove(deal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(Guid id)
        {
            return _context.Deal.Any(e => e.Id == id);
        }
    }
}
