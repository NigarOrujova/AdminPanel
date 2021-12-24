using Microsoft.AspNetCore.Mvc;
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
            return View(_context.Categories);
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
            return Json(new
            {
                action = "update",
                Id = id
            });
        }
        public IActionResult Delete(int id)
        {
            return Json(new
            {
                action = "delete",
                Id = id
            });
        }
    }
}
