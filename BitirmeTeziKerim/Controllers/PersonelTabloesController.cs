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
   

    public class PersonelTabloesController : Controller
    {
        private readonly BitirmeTeziDbContext _context;

        public PersonelTabloesController(BitirmeTeziDbContext context)
        {
            _context = context;
        }

        // GET: PersonelTabloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonelTablos.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> Index2()
        {
            return View(await _context.PersonelTablos.ToListAsync());
        }

        // GET: PersonelTabloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelTablo = await _context.PersonelTablos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personelTablo == null)
            {
                return NotFound();
            }

            return View(personelTablo);
        }

        // GET: PersonelTabloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonelTabloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AkademikPersonel,Unvan,Sayi,IdariPersonel,Sinif,Sayi1")] PersonelTablo personelTablo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personelTablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personelTablo);
        }

        // GET: PersonelTabloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelTablo = await _context.PersonelTablos.FindAsync(id);
            if (personelTablo == null)
            {
                return NotFound();
            }
            return View(personelTablo);
        }

        // POST: PersonelTabloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AkademikPersonel,Unvan,Sayi,IdariPersonel,Sinif,Sayi1")] PersonelTablo personelTablo)
        {
            if (id != personelTablo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personelTablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelTabloExists(personelTablo.Id))
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
            return View(personelTablo);
        }

        // GET: PersonelTabloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelTablo = await _context.PersonelTablos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personelTablo == null)
            {
                return NotFound();
            }

            return View(personelTablo);
        }

        // POST: PersonelTabloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personelTablo = await _context.PersonelTablos.FindAsync(id);
            _context.PersonelTablos.Remove(personelTablo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelTabloExists(int id)
        {
            return _context.PersonelTablos.Any(e => e.Id == id);
        }
    }
}
