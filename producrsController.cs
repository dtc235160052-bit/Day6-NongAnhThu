using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day6_NongAnhThu.Data;
using Day6_NongAnhThu.Models;

namespace Day6_NongAnhThu.Controllers
{
    public class producrsController : Controller
    {
        private readonly Day6_NongAnhThuContext _context;

        public producrsController(Day6_NongAnhThuContext context)
        {
            _context = context;
        }

        // GET: producrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.producr.ToListAsync());
        }

        // GET: producrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producr = await _context.producr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producr == null)
            {
                return NotFound();
            }

            return View(producr);
        }

        // GET: producrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: producrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description")] producr producr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producr);
        }

        // GET: producrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producr = await _context.producr.FindAsync(id);
            if (producr == null)
            {
                return NotFound();
            }
            return View(producr);
        }

        // POST: producrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description")] producr producr)
        {
            if (id != producr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!producrExists(producr.Id))
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
            return View(producr);
        }

        // GET: producrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producr = await _context.producr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producr == null)
            {
                return NotFound();
            }

            return View(producr);
        }

        // POST: producrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producr = await _context.producr.FindAsync(id);
            if (producr != null)
            {
                _context.producr.Remove(producr);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool producrExists(int id)
        {
            return _context.producr.Any(e => e.Id == id);
        }
    }
}
