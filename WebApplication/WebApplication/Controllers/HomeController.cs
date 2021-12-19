using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            HomeViewModel homeViewModel = new HomeViewModel
            {
                SliderIntro = await _context.SliderIntro.FirstOrDefaultAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories
                .Where(c=>c.IsDeleted==false)
                .ToListAsync(),
                Products = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p=>p.Category)
                .Include(p=>p.Images)
                .OrderByDescending(p=>p.Id)
                .ToListAsync(),
                About=await _context.About.FirstOrDefaultAsync(),
                ListUnstyleds=await _context.ListUnstyled.ToListAsync(),
                OurTeams=await _context.OurTeams.ToListAsync(),

                Blogs =await _context.Blogs
                .Include(b=>b.Images)
                .OrderByDescending(b=>b.Id)
                .ToListAsync()
            };
                return View(homeViewModel);
        }
    }
}
