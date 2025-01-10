using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitirmeTeziKerim.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BitirmeTeziKerim.Controllers
{
    [Authorize]

    public class DuyurusController : Controller
    {
        private readonly BitirmeTeziDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _environment;

        [Obsolete]
        public DuyurusController(BitirmeTeziDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Duyurus
      
        public async Task<IActionResult> Index()
        {
            return View(await _context.Duyurues.ToListAsync());
        }

        // GET: Duyurus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuru = await _context.Duyurues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyuru == null)
            {
                return NotFound();
            }

            return View(duyuru);
        }

        // GET: Duyurus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duyurus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create([Bind("Id,Url,Image,Aciklama")] Duyuru duyuru, IFormFile Image)
        {
            
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "DuyuruFoto", Image.FileName);
                    var filePath = Path.Combine(uploads);
                    var indexPath = Path.Combine("/DuyuruFoto/", Image.FileName);
                    duyuru.Url = "/DuyuruFoto/" + Image.FileName;

                    if (Image.Length > 0)
                    {
                        Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        duyuru.Image = filePath;
                        _context.Add(duyuru);
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction(nameof(Index));
                }
               
                
                
            }
            return View(duyuru);
        }

        // GET: Duyurus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuru = await _context.Duyurues.FindAsync(id);
            if (duyuru == null)
            {
                return NotFound();
            }
            return View(duyuru);
        }

        // POST: Duyurus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,Image,Aciklama")] Duyuru duyuru)
        {
            if (id != duyuru.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duyuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuyuruExists(duyuru.Id))
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
            return View(duyuru);
        }

        // GET: Duyurus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyuru = await _context.Duyurues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duyuru == null)
            {
                return NotFound();
            }

            return View(duyuru);
        }

        // POST: Duyurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duyuru = await _context.Duyurues.FindAsync(id);
            _context.Duyurues.Remove(duyuru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuyuruExists(int id)
        {
            return _context.Duyurues.Any(e => e.Id == id);
        }
    }
}
