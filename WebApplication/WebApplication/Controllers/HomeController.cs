using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.ViewModel;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            HttpContext.Session.SetString("say", "Welcome");
            Response.Cookies.Append("say", "hello",
            new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) });

            HomeViewModel homeViewModel = new HomeViewModel
            {
                SliderIntro = await _context.SliderIntro.FirstOrDefaultAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories
                .Where(c => c.IsDeleted == false)
                .ToListAsync(),
                
                About = await _context.About.FirstOrDefaultAsync(),
                ListUnstyleds = await _context.ListUnstyled.ToListAsync(),
                OurTeams = await _context.OurTeams.ToListAsync(),
                Blogs = await _context.Blogs
                .Include(b => b.BlogImages)
                .OrderByDescending(b => b.Id)
                .ToListAsync(),
                Says = await _context.Says.ToListAsync()
            };
            return View(homeViewModel);
        }
            //public IActionResult Test()
            //{
            //var session = HttpContext.Session.GetString("say");
            //var cookie = Request.Cookies["say"];
            //return Json(session+"  "+cookie);
            //}
        
    }
}
