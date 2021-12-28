using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.Models;
using WebApplication.Utilities.File;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    [Area("AdminFiorello")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if(ModelState["Photo"].ValidationState== ModelValidationState.Invalid) return View();
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File should be image type");
                return View();
            }
            if (!slider.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "File size must be less than200kb");
                return View();
            }
            string fileName =await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");
            slider.Image = fileName;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider =await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            Helper.RemoveFile(_env.WebRootPath, "img", slider.Image);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
