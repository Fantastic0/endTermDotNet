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
    public class AcctController : Controller
    {
        private readonly DataContext _context;

        public AcctController(DataContext context)
        {
            _context = context;
        }

        // GET: Acct
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acct.ToListAsync());
        }

        // GET: Acct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acct = await _context.Acct
                .FirstOrDefaultAsync(m => m.AcctId == id);
            if (acct == null)
            {
                return NotFound();
            }

            return View(acct);
        }

        // GET: Acct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcctId,CustId,CustCat,AcctCat,OpenDate")] Acct acct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acct);
        }

        // GET: Acct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acct = await _context.Acct.FindAsync(id);
            if (acct == null)
            {
                return NotFound();
            }
            return View(acct);
        }

        // POST: Acct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcctId,CustId,CustCat,AcctCat,OpenDate")] Acct acct)
        {
            if (id != acct.AcctId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcctExists(acct.AcctId))
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
            return View(acct);
        }

        // GET: Acct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acct = await _context.Acct
                .FirstOrDefaultAsync(m => m.AcctId == id);
            if (acct == null)
            {
                return NotFound();
            }

            return View(acct);
        }

        // POST: Acct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acct = await _context.Acct.FindAsync(id);
            _context.Acct.Remove(acct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcctExists(int id)
        {
            return _context.Acct.Any(e => e.AcctId == id);
        }
    }
}
