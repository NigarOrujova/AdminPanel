using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    [Area("AdminFiorello")]
    public class SayController : Controller
    {
        private AppDbContext _context { get; }
        public SayController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Says);
        }
    }
}
