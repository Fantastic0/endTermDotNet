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
    public class OpController : Controller
    {
        private readonly DataContext _context;

        public OpController(DataContext context)
        {
            _context = context;
        }

        // GET: Op
        public async Task<IActionResult> Index()
        {
            return View(await _context.Op.ToListAsync());
        }

        // GET: Op/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var op = await _context.Op
                .FirstOrDefaultAsync(m => m.OpId == id);
            if (op == null)
            {
                return NotFound();
            }

            return View(op);
        }

        // GET: Op/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Op/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpId,Inn,OpDate")] Op op)
        {
            if (ModelState.IsValid)
            {
                _context.Add(op);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(op);
        }

        // GET: Op/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var op = await _context.Op.FindAsync(id);
            if (op == null)
            {
                return NotFound();
            }
            return View(op);
        }

        // POST: Op/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpId,Inn,OpDate")] Op op)
        {
            if (id != op.OpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(op);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpExists(op.OpId))
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
            return View(op);
        }

        // GET: Op/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var op = await _context.Op
                .FirstOrDefaultAsync(m => m.OpId == id);
            if (op == null)
            {
                return NotFound();
            }

            return View(op);
        }

        // POST: Op/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var op = await _context.Op.FindAsync(id);
            _context.Op.Remove(op);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpExists(int id)
        {
            return _context.Op.Any(e => e.OpId == id);
        }
    }
}
