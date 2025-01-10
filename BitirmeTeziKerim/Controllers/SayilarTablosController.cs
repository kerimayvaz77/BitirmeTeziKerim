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
   

    public class SayilarTablosController : Controller
    {
   
        private readonly BitirmeTeziDbContext _context;

        public SayilarTablosController(BitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: SayilarTablos

        public async Task<IActionResult> Index()
        {
            var bitirmeTeziDbContext = _context.SayilarTablos.Include(s => s.Sayilar);
            return View(await bitirmeTeziDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Index2()
        {
            var bitirmeTeziDbContext = _context.SayilarTablos.Include(s => s.Sayilar);
            return View(await bitirmeTeziDbContext.ToListAsync());
        }

        // GET: SayilarTablos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilarTablo = await _context.SayilarTablos
                .Include(s => s.Sayilar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayilarTablo == null)
            {
                return NotFound();
            }

            return View(sayilarTablo);
        }

        // GET: SayilarTablos/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["SayilarId"] = new SelectList(_context.Sayilars, "Id", "SayiTablo");
            return View();
        }

        // POST: SayilarTablos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,OgrenimDuzeyi,AkademikBirim,Kadin,Erkek,SayilarId")] SayilarTablo sayilarTablo)
        {
            if (ModelState.IsValid)
            {
                sayilarTablo.Toplam = sayilarTablo.Erkek + sayilarTablo.Kadin;
                _context.Add(sayilarTablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SayilarId"] = new SelectList(_context.Sayilars, "Id", "SayiTablo", sayilarTablo.SayilarId);
            return View(sayilarTablo);
        }

        // GET: SayilarTablos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilarTablo = await _context.SayilarTablos.FindAsync(id);
            if (sayilarTablo == null)
            {
                return NotFound();
            }
            ViewData["SayilarId"] = new SelectList(_context.Sayilars, "Id", "SayiTablo", sayilarTablo.SayilarId);
            return View(sayilarTablo);
        }

        // POST: SayilarTablos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OgrenimDuzeyi,AkademikBirim,Kadin,Erkek,SayilarId")] SayilarTablo sayilarTablo)
        {
            if (id != sayilarTablo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sayilarTablo.Toplam = sayilarTablo.Erkek + sayilarTablo.Kadin;
                    _context.Update(sayilarTablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SayilarTabloExists(sayilarTablo.Id))
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
            ViewData["SayilarId"] = new SelectList(_context.Sayilars, "Id", "SayiTablo", sayilarTablo.SayilarId);
            return View(sayilarTablo);
        }

        // GET: SayilarTablos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilarTablo = await _context.SayilarTablos
                .Include(s => s.Sayilar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayilarTablo == null)
            {
                return NotFound();
            }

            return View(sayilarTablo);
        }

        // POST: SayilarTablos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sayilarTablo = await _context.SayilarTablos.FindAsync(id);
            _context.SayilarTablos.Remove(sayilarTablo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        private bool SayilarTabloExists(int id)
        {
            return _context.SayilarTablos.Any(e => e.Id == id);
        }
    }
}
