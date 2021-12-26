using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.Models.Home;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    [Area("AdminFiorello")]
    public class CategoryController : Controller
    {
        private AppDbContext _context { get; }
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.Where(c=>c.IsDeleted==false).ToList());
        }

        public IActionResult Detail(int id)
        {
            return Json(new
            {
                action = "detail",
                Id = id
            });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View();
            bool IsExist = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (IsExist)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Category category)
        {
            if (!ModelState.IsValid) return View();
            if (id != category.Id) return BadRequest();
            Category DbCategory = await _context.Categories.FindAsync(id);
            if (DbCategory == null) return NotFound();
            if(DbCategory.Name.ToLower().Trim()== category.Name.ToLower().Trim())
            {
                return RedirectToAction(nameof(Index));
            }
            bool IsExist = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if(IsExist)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View(category);
            }
            DbCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Category dbCategory = await _context.Categories
                                                .Where(c => c.IsDeleted == false && c.Id == id)
                                                .FirstOrDefaultAsync();
            if (dbCategory == null) return NotFound();
            //_context.Remove(dbCategory);
            //await _context.SaveChangesAsync();
            dbCategory.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
