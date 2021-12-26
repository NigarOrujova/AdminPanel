using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.ViewModel;

namespace WebApplication.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take,int skip=0)
        {
            var model = await _context.Products
                                    .Where(p => p.IsDeleted == false)
                                    .Include(p => p.Category)
                                    .Include(p => p.Images)
                                    .OrderByDescending(p => p.Id)
                                    .Skip(skip)
                                    .Take(take)
                                    .ToListAsync();
            return View(model);
        }
    }
}
