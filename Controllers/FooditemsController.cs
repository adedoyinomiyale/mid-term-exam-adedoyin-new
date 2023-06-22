using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class FooditemsController : Controller
    {
        private readonly RestuarantContext _context;

        public FooditemsController(RestuarantContext context)
        {
            _context = context;
        }

        // GET: Fooditems
        public async Task<IActionResult> Index()
        {
              return _context.Fooditems != null ? 
                          View(await _context.Fooditems.ToListAsync()) :
                          Problem("Entity set 'RestuarantContext.Fooditems'  is null.");
        }

        // GET: Fooditems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fooditems == null)
            {
                return NotFound();
            }

            var fooditem = await _context.Fooditems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fooditem == null)
            {
                return NotFound();
            }

            return View(fooditem);
        }

        // GET: Fooditems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fooditems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,Price")] Fooditem fooditem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fooditem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fooditem);
        }

        // GET: Fooditems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fooditems == null)
            {
                return NotFound();
            }

            var fooditem = await _context.Fooditems.FindAsync(id);
            if (fooditem == null)
            {
                return NotFound();
            }
            return View(fooditem);
        }

        // POST: Fooditems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image,Price")] Fooditem fooditem)
        {
            if (id != fooditem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fooditem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooditemExists(fooditem.Id))
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
            return View(fooditem);
        }

        // GET: Fooditems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fooditems == null)
            {
                return NotFound();
            }

            var fooditem = await _context.Fooditems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fooditem == null)
            {
                return NotFound();
            }

            return View(fooditem);
        }

        // POST: Fooditems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fooditems == null)
            {
                return Problem("Entity set 'RestuarantContext.Fooditems'  is null.");
            }
            var fooditem = await _context.Fooditems.FindAsync(id);
            if (fooditem != null)
            {
                _context.Fooditems.Remove(fooditem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooditemExists(int id)
        {
          return (_context.Fooditems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
