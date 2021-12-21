using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context { get; }
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.proCount = _context.Products
                                       .Where(p => p.IsDeleted == false)
                                       .Count();
            return View(_context.Products
                                .Where(p=>p.IsDeleted==false)
                                .OrderByDescending(p=>p.Id)
                                .Take(8)
                                .Include(p=>p.Images));
        }
        public IActionResult LoadProduct(int skip)
        {
            var model = _context.Products
                                .OrderByDescending(p => p.Id)
                                .Skip(skip)
                                .Take(8)
                                .Include(p => p.Images)
                                .ToList();
            return PartialView("_ProductPartial", model);
            //return Json(_context.Products
            //                    .OrderByDescending(p => p.Id)
            //                    .Skip(8)
            //                    .Take(8)
            //                    .ToListAsync());
        }
    }
}
