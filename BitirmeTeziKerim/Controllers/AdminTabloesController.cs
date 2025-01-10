using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitirmeTeziKerim.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace BitirmeTeziKerim.Controllers
{
    [Authorize]
    public class AdminTabloesController : Controller
    {
        private readonly BitirmeTeziDbContext _context;

        public AdminTabloesController(BitirmeTeziDbContext context)
        {
            _context = context;
        }
        // GET: AdminTabloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminTablos.ToListAsync());
        }
        // GET: AdminTabloes/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminTablo = await _context.AdminTablos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminTablo == null)
            {
                return NotFound();
            }

            return View(adminTablo);
        }

        // GET: AdminTabloes/Create
       
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminTabloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Sifre")] AdminTablo adminTablo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminTablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminTablo);
        }

        // GET: AdminTabloes/Edit/5
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminTablo = await _context.AdminTablos.FindAsync(id);
            if (adminTablo == null)
            {
                return NotFound();
            }
            return View(adminTablo);
        }

        // POST: AdminTabloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Sifre")] AdminTablo adminTablo)
        {
            if (id != adminTablo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminTablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminTabloExists(adminTablo.Id))
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
            return View(adminTablo);
        }

        // GET: AdminTabloes/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminTablo = await _context.AdminTablos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminTablo == null)
            {
                return NotFound();
            }

            return View(adminTablo);
        }

        // POST: AdminTabloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminTablo = await _context.AdminTablos.FindAsync(id);
            _context.AdminTablos.Remove(adminTablo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        private bool AdminTabloExists(int id)
        {
            return _context.AdminTablos.Any(e => e.Id == id);
        }
    }
}
