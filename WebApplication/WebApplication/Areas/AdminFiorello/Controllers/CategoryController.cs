using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;

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
        public IActionResult Create(int id)
        {
            return Json(new
            {
                action = "create",
                Id = id
            });
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
