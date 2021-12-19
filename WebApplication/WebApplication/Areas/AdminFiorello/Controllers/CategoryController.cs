using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
