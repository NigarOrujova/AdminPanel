using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.ViewModel;

namespace WebApplication.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterViewModel footerViewModel = new FooterViewModel
            {
                Services = await _context.Services.ToListAsync(),
                Companies=await _context.Companies.ToListAsync(),
                SocialMedias=await _context.SocialMedias.ToListAsync()
            };
            return View(footerViewModel);
        }
    }
}
