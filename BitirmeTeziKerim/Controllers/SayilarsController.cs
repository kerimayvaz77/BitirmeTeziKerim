using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitirmeTeziKerim.Models;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeTeziKerim.Controllers
{
    
    public class SayilarsController : Controller
    {
        private readonly BitirmeTeziDbContext _context;

        public SayilarsController(BitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: Sayilars
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sayilars.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Sayilars.ToListAsync());
        }

        // GET: Sayilars/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilar = await _context.Sayilars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayilar == null)
            {
                return NotFound();
            }

            return View(sayilar);
        }

        // GET: Sayilars/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sayilars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,SayiTablo")] Sayilar sayilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sayilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sayilar);
        }

        // GET: Sayilars/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilar = await _context.Sayilars.FindAsync(id);
            if (sayilar == null)
            {
                return NotFound();
            }
            return View(sayilar);
        }

        // POST: Sayilars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SayiTablo")] Sayilar sayilar)
        {
            if (id != sayilar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sayilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SayilarExists(sayilar.Id))
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
            return View(sayilar);
        }

        // GET: Sayilars/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilar = await _context.Sayilars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayilar == null)
            {
                return NotFound();
            }

            return View(sayilar);
        }

        // POST: Sayilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sayilar = await _context.Sayilars.FindAsync(id);
            _context.Sayilars.Remove(sayilar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        private bool SayilarExists(int id)
        {
            return _context.Sayilars.Any(e => e.Id == id);
        }
    }
}
