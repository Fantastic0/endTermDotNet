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
    public class CustController : Controller
    {
        private readonly DataContext _context;

        public CustController(DataContext context)
        {
            _context = context;
        }

        // GET: Cust
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cust.ToListAsync());
        }

        // GET: Cust/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Cust
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // GET: Cust/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cust/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustId,Name,ShortName,Bin")] Cust cust)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cust);
        }

        // GET: Cust/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Cust.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        // POST: Cust/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustId,Name,ShortName,Bin")] Cust cust)
        {
            if (id != cust.CustId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustExists(cust.CustId))
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
            return View(cust);
        }

        // GET: Cust/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Cust
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // POST: Cust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cust = await _context.Cust.FindAsync(id);
            _context.Cust.Remove(cust);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustExists(int id)
        {
            return _context.Cust.Any(e => e.CustId == id);
        }
    }
}
