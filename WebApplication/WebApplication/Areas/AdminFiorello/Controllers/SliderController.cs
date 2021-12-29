using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using WebApplication.ViewModel.Slider;

namespace WebApplication.Areas.AdminFiorello.Controllers
{
    [Area("AdminFiorello")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private string _errorMessage;
        public int count { get; set; }
        private Dictionary<string, string> ImageSize { get; set; }

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            ImageSize = _context.Settings.AsEnumerable().ToDictionary(s => s.Key,s=>s.Value);
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
        public async Task<IActionResult> Create(MultipleSliderVM sliderVM)
        {
            #region FileUpload
            //if(ModelState["Photo"].ValidationState== ModelValidationState.Invalid) return View();
            //if (!slider.Photo.CheckFileType("image/"))
            //{
            //    ModelState.AddModelError("Photo", "File should be image type");
            //    return View();
            //}
            //if (!slider.Photo.CheckFileSize(int.Parse(ImageSize["File_Size"])))
            //{
            //    ModelState.AddModelError("Photo", "File size must be less than200kb");
            //    return View();
            //}
            //string fileName =await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");
            //slider.Image = fileName;
            //await _context.Sliders.AddAsync(slider);
            //await _context.SaveChangesAsync();
            #endregion
            count = 1;
            if (ModelState["Photos"].ValidationState == ModelValidationState.Invalid) return View();
            if (!CheckImageValid(sliderVM.Photos))
            {
                ModelState.AddModelError("Photos", _errorMessage);
                return View();
            }
            foreach (var photo in sliderVM.Photos)
            {
                if (count<5)
                {
                    string fileName = await photo.SaveFileAsync(_env.WebRootPath, "img");
                    Slider slider = new Slider
                    {
                        Image = fileName
                    };
                    await _context.Sliders.AddAsync(slider);
                }
                else
                {
                    ModelState.AddModelError("Photos", "You just choose 5 file"); return View();
                }
                count++;
               
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CheckImageValid(List<IFormFile> photos)
        {
            foreach (var photo in photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    _errorMessage= $"{photo.FileName} should be image type";
                    return false;
                }
                if (!photo.CheckFileSize(int.Parse(ImageSize["File_Size"])))
                {
                    _errorMessage= $"{photo.FileName}-file size must be less than200kb";
                    return false;
                }
            }
            return true;
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
        public async Task<IActionResult> Update(int id)
        {
           Slider slider =await  _context.Sliders.FindAsync(id);
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Slider slider)
        {
            if (id != slider.Id) return BadRequest();
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return RedirectToAction(nameof(Index));
            Slider dbSlider = await _context.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File should be image type");
                return View();
            }
            if (!slider.Photo.CheckFileSize(int.Parse(ImageSize["File_Size"])))
            {
                ModelState.AddModelError("Photo", "File size must be less than200kb");
                return View();
            }
            Helper.RemoveFile(_env.WebRootPath, "img", dbSlider.Image);
            string newFileName = await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");
            dbSlider.Image = newFileName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
