using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.Models.Home;
using WebApplication.ViewModel;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context { get; }
        private int _productCount;
        private int _productTake;
        public ProductController(AppDbContext context)
        {
            _context = context;
            _productCount = _context.Products
                                       .Where(p => p.IsDeleted == false)
                                       .Count();
            _productTake = _context.Settings.Where(n => n.Key == "Pro_take_count").FirstOrDefault().Value;
        }
        public IActionResult Index()
        {

            ViewBag.proCount = _productCount;
            return View(_context.Products
                                .Where(p => p.IsDeleted == false)
                                .OrderByDescending(p => p.Id)
                                .Take(_productTake)
                                .Include(p => p.Images));
        }
        public IActionResult LoadProduct(int skip)
        {
            if (_productCount == skip)
            {
                return Json(new
                {
                    button = "Load More"
                });
            }
            var model = _context.Products
                                .OrderByDescending(p => p.Id)
                                .Skip(skip)
                                .Take(_productTake)
                                .Include(p => p.Images)
                                .ToList();
            return PartialView("_ProductPartial", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return BadRequest();
            List<BasketViewModel> basket = GetBasket();
            UpdateBasket((int)id, basket);
            return RedirectToAction("Index", "Home");
        }
        public void UpdateBasket(int id, List<BasketViewModel> basket)
        {
            BasketViewModel BasketProduct = basket.Find(p => p.Id == id);
            if (BasketProduct == null)
            {
                basket.Add(new BasketViewModel
                {
                    Id = id,
                    Count = 1
                });
            }
            else
            {
                BasketProduct.Count += 1;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
        }
        public List<BasketViewModel> GetBasket()
        {
            List<BasketViewModel> basket;
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketViewModel>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketViewModel>();
            }
            return basket;
        }
        public IActionResult Basket()
        {
            return Json(JsonConvert.DeserializeObject<List<BasketViewModel>>(Request.Cookies["basket"]));
        }
    }
}
