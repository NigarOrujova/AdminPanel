using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.Models.Home;
using WebApplication.ViewModel;

namespace WebApplication.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketViewModel> basket;
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketViewModel>>(Request.Cookies["basket"]);
                ViewBag.BasketItemCount = basket.Count();
            }
            else
            {
                ViewBag.BasketItemCount = 0;
            }
            var setting = _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
            return View(await Task.FromResult(setting));
        }
    }
}
