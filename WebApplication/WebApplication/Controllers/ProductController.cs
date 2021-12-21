using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private int _productCount;
        private int _productTake;
        public ProductController(AppDbContext context)
        {
            _context = context;
            _productCount = _context.Products
                                       .Where(p => p.IsDeleted == false)
                                       .Count();
            _productTake = _context.Settings.Where(n => n.Key == "Pro_take_count").Select(n => n.Value).FirstOrDefault();
        }
        public IActionResult Index()
        {

            ViewBag.proCount = _productCount;
            return View(_context.Products
                                .Where(p=>p.IsDeleted==false)
                                .OrderByDescending(p=>p.Id)
                                .Take(_productTake)
                                .Include(p=>p.Images));
        }
        public IActionResult LoadProduct(int skip)
        {
            if (_productCount == skip)
            {
                return Json(new
                {
                    button="Load More"
                });
            }
            var model = _context.Products
                                .OrderByDescending(p => p.Id)
                                .Skip(skip)
                                .Take(_productTake)
                                .Include(p => p.Images)
                                .ToList();
            return PartialView("_ProductPartial", model);
        }
    }
}
