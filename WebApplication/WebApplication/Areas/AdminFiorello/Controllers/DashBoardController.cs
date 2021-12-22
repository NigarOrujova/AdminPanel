using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("AdminFiorello")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
