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
    public class AcctPosController : Controller
    {
        private readonly DataContext _context;

        public AcctPosController(DataContext context)
        {
            _context = context;
        }

        // GET: AcctPos
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcctPos.ToListAsync());
        }

        // GET: AcctPos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acctPos = await _context.AcctPos
                .FirstOrDefaultAsync(m => m.AcctPosId == id);
            if (acctPos == null)
            {
                return NotFound();
            }

            return View(acctPos);
        }

        // GET: AcctPos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcctPos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcctPostId,Balance,Date")] AcctPos acctPos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acctPos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acctPos);
        }

        // GET: AcctPos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acctPos = await _context.AcctPos.FindAsync(id);
            if (acctPos == null)
            {
                return NotFound();
            }
            return View(acctPos);
        }

        // POST: AcctPos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcctPostId,Balance,Date")] AcctPos acctPos)
        {
            if (id != acctPos.AcctPosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acctPos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcctPosExists(acctPos.AcctPosId))
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
            return View(acctPos);
        }

        // GET: AcctPos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acctPos = await _context.AcctPos
                .FirstOrDefaultAsync(m => m.AcctPosId == id);
            if (acctPos == null)
            {
                return NotFound();
            }

            return View(acctPos);
        }

        // POST: AcctPos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acctPos = await _context.AcctPos.FindAsync(id);
            _context.AcctPos.Remove(acctPos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcctPosExists(int id)
        {
            return _context.AcctPos.Any(e => e.AcctPosId == id);
        }
    }
}
