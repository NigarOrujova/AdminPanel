using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.Models.Home;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    [Area("AdminFiorello")]
    public class ProductController : Controller
    {
        private AppDbContext _context { get; }
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> product = await _context.Products.Include(p => p.Images).ToListAsync();
            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories =await _context.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View();
            bool IsExits = _context.Products.Where(p => p.IsDeleted == false && p.Images == null).FirstOrDefault() != null;
            if (IsExits)
            {
                ModelState.AddModelError("Name", "This Product already exist");
                return View();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product dbProduct = await _context.Products.Where(g => g.Id == id).FirstOrDefaultAsync();
            if (dbProduct == null)
            {
                return NotFound();
            }
            _context.Remove(dbProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            return View(product);
        }
    }
}
