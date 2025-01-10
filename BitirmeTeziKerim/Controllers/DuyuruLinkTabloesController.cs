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
{[Authorize]
    public class DuyuruLinkTabloesController : Controller
    {
        private readonly BitirmeTeziDbContext _context;

        public DuyuruLinkTabloesController(BitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: DuyuruLinkTabloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DuyuruLinks.ToListAsync());
        }

        // GET: DuyuruLinkTabloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuruLinkTablo = await _context.DuyuruLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyuruLinkTablo == null)
            {
                return NotFound();
            }

            return View(duyuruLinkTablo);
        }

        // GET: DuyuruLinkTabloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuyuruLinkTabloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KoyulacakLink,KoyulacakLink2")] DuyuruLinkTablo duyuruLinkTablo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duyuruLinkTablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duyuruLinkTablo);
        }

        // GET: DuyuruLinkTabloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuruLinkTablo = await _context.DuyuruLinks.FindAsync(id);
            if (duyuruLinkTablo == null)
            {
                return NotFound();
            }
            return View(duyuruLinkTablo);
        }

        // POST: DuyuruLinkTabloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KoyulacakLink,KoyulacakLink2")] DuyuruLinkTablo duyuruLinkTablo)
        {
            if (id != duyuruLinkTablo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duyuruLinkTablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuyuruLinkTabloExists(duyuruLinkTablo.Id))
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
            return View(duyuruLinkTablo);
        }

        // GET: DuyuruLinkTabloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuruLinkTablo = await _context.DuyuruLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyuruLinkTablo == null)
            {
                return NotFound();
            }

            return View(duyuruLinkTablo);
        }

        // POST: DuyuruLinkTabloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duyuruLinkTablo = await _context.DuyuruLinks.FindAsync(id);
            _context.DuyuruLinks.Remove(duyuruLinkTablo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuyuruLinkTabloExists(int id)
        {
            return _context.DuyuruLinks.Any(e => e.Id == id);
        }
    }
}
