using BitirmeTeziKerim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
namespace BitirmeTeziKerim.Controllers
{
  

    public class HomeController : Controller
    {
        
        private readonly BitirmeTeziDbContext _context;

        public HomeController(BitirmeTeziDbContext context)
        {
            _context = context;
        }

       


        public  IActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.duyurulist = getDuyurus();
            dy.duyurulinktablolist = getDuyuruLinkTabloes();

            return View(dy);
        }
        public List<Duyuru> getDuyurus()
        {
            List<Duyuru> LDuyuru = _context.Duyurues.ToList();
            return LDuyuru;
        }
        public List<DuyuruLinkTablo> getDuyuruLinkTabloes()
        {
            List<DuyuruLinkTablo> LDuyuruLink = _context.DuyuruLinks.ToList();
            return LDuyuruLink;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
