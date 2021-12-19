using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
