using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastProject.Data;
using LastProject.Models;

namespace LastProject.Controllers
{
    public class OpEntryController : Controller
    {
        private readonly DataContext _context;

        public OpEntryController(DataContext context)
        {
            _context = context;
        }

        // GET: OpEntry
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpEntry.ToListAsync());
        }

        // GET: OpEntry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opEntry = await _context.OpEntry
                .FirstOrDefaultAsync(m => m.OpEntryId == id);
            if (opEntry == null)
            {
                return NotFound();
            }

            return View(opEntry);
        }

        // GET: OpEntry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpEntryId,Balance,OpenDate")] OpEntry opEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opEntry);
        }

        // GET: OpEntry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opEntry = await _context.OpEntry.FindAsync(id);
            if (opEntry == null)
            {
                return NotFound();
            }
            return View(opEntry);
        }

        // POST: OpEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpEntryId,Balance,OpenDate")] OpEntry opEntry)
        {
            if (id != opEntry.OpEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpEntryExists(opEntry.OpEntryId))
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
            return View(opEntry);
        }

        // GET: OpEntry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opEntry = await _context.OpEntry
                .FirstOrDefaultAsync(m => m.OpEntryId == id);
            if (opEntry == null)
            {
                return NotFound();
            }

            return View(opEntry);
        }

        // POST: OpEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opEntry = await _context.OpEntry.FindAsync(id);
            _context.OpEntry.Remove(opEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpEntryExists(int id)
        {
            return _context.OpEntry.Any(e => e.OpEntryId == id);
        }
    }
}
