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
        public async Task<IActionResult> Index(int currentHistory, int? pageNumber = 1)
        {
            int pageSize = 3;

            var deals = new Deals();
            deals.CurrentHistory = currentHistory;
            deals.BinaryOptDeal = await (PaginatedList<DealBO>.CreateAsync(
                await _context.DealBO.ToListAsync(), pageNumber ?? 1, pageSize));
            deals.ForexDeal = await( PaginatedList<DealForex>.CreateAsync(
                await _context.DealForex.ToListAsync(), pageNumber ?? 1, pageSize));

            return View(deals);
        }

        // GET: Deals/DetailsBo/5
        public async Task<IActionResult> DetailsBo(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            object? deal = await _context.DealBO
                .FirstOrDefaultAsync(m => m.Id == id);

            if (deal == null)
            {
                return View();
            }

            return View(deal);
        }

        // GET: Deals/DetailsForex/5
        public async Task<IActionResult> DetailsForex(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            object? deal = await _context.DealForex
                .FirstOrDefaultAsync(m => m.Id == id);

            if (deal == null)
            {
                return View();
            }

            return View(deal);
        }

        // GET: Deals/CreateBo
        public IActionResult CreateBo()
        {
            return View();
        }

        // GET: Deals/CreateForex
        public IActionResult CreateForex()
        {
            return View();
        }

        // POST: Deals/CreateBo
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBo([Bind("Id,OpeningDate,Expiration,ClosingDate,Price,Direction,Result")] DealBO deal)
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

        // POST: Deals/CreateForex
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForex(
            [Bind("Id,Symbol,OpeningDate,ClosingDate,Price,Type,Volume,StopLoss,TakeProfit,Profit")] DealForex deal)
        {
            if (ModelState.IsValid)
            {
                deal.Id = Guid.NewGuid();
                _context.Add(deal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deal);
        }

        // GET: Deals/EditBo/5
        public async Task<IActionResult> EditBo(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.DealBO.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            return View(deal);
        }

        // GET: Deals/EditForex/5
        public async Task<IActionResult> EditForex(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.DealForex.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            return View(deal);
        }

        // POST: Deals/EditBo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBo(Guid id,
            [Bind("Id,OpeningDate,ClosingDate,Price,Expiration,Direction,Result")] DealBO deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.DealBO.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealBoExists(deal.Id))
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

        // POST: Deals/EditForex/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditForex(Guid id,
            [Bind("Id,OpeningDate,ClosingDate,Price,Symbol,Type,Volume,StopLose,TakeProfit,Profit")] DealForex deal)
        {
            if (id != deal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.DealForex.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealForexExists(deal.Id))
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

        // GET: Deals/DeleteBo/5
        public async Task<IActionResult> DeleteBo(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.DealBO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deals/DeleteBo/5
        [HttpPost, ActionName("DeleteBo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBoConfirmed(Guid id)
        {
            var deal = await _context.DealBO.FindAsync(id);
            if (deal != null)
            {
                _context.DealBO.Remove(deal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Deals/DeleteForex/5
        public async Task<IActionResult> DeleteForex(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.DealForex
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deals/DeleteForex/5
        [HttpPost, ActionName("DeleteForex")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteForexConfirmed(Guid id)
        {
            var deal = await _context.DealForex.FindAsync(id);
            if (deal != null)
            {
                _context.DealForex.Remove(deal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealBoExists(Guid id)
        {
            return _context.DealBO.Any(e => e.Id == id);
        }

        private bool DealForexExists(Guid id)
        {
            return _context.DealBO.Any(e => e.Id == id);
        }
    }
}
