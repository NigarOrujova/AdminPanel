using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    [Area("AdminFiorello")]
    public class TeamController : Controller
    {
        private AppDbContext _context { get; }
        public TeamController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.OurTeams);
        }
    }
}
