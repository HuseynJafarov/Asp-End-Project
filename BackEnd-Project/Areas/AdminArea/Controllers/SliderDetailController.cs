using BackEnd_Project.Data;
using BackEnd_Project.Helpers;
using BackEnd_Project.Models;
using BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class SliderDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderDetailController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index() => View(await _context.SliderDetails.Where(m => !m.IsDeleted).ToListAsync());

      

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderDetailVM sliderDetail)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                foreach (var photo in sliderDetail.Photo)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }
                    if (!photo.CheckFileSize(2000))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }

                }

                foreach (var photo in sliderDetail.Photo)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", fileName);

                    await SaveFile(path, photo);

                    SliderDetail newSliderDetail = new SliderDetail
                    {
                        Image = fileName,
                        Subtitle = sliderDetail.Subtitle,
                        Header = sliderDetail.Header,
                        Description = sliderDetail.Description,
                    };

                    await _context.SliderDetails.AddAsync(newSliderDetail);
                }


                bool isExist = await _context.SliderDetails.AnyAsync(m => m.Subtitle.Trim() == sliderDetail.Subtitle.Trim() &&
                m.Header.Trim() == sliderDetail.Header.Trim() &&
                m.Description.Trim() == sliderDetail.Description.Trim());
                if (isExist)
                {
                    ModelState.AddModelError("Subtitle Header Description", "Category already exist");
                    return View();
                }


                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                SliderDetail sliderDetail = await _context.SliderDetails.FirstOrDefaultAsync(m => m.Id == id);

                if (sliderDetail is null) return NotFound();

                return View(sliderDetail);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            SliderDetail sliderDetail = await GetByIdAsync(id);

            if (sliderDetail == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", sliderDetail.Image);

            Helper.DeleteFile(path);

            _context.SliderDetails.Remove(sliderDetail);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                SliderDetail sliderDetail = await _context.SliderDetails.FirstOrDefaultAsync(m => m.Id == id);

                if (sliderDetail is null) return NotFound();

                return View(sliderDetail);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SliderDetail sliderDetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(sliderDetail);
                }

                if (sliderDetail.Photo != null)
                {
                    if (!sliderDetail.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View();
                    }

                    if (!sliderDetail.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image size");
                        return View();
                    }

                    string fileName = Guid.NewGuid().ToString() + "_" + sliderDetail.Photo.FileName;

                    SliderDetail dbSliderDetail = await _context.SliderDetails.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                    if (dbSliderDetail is null) return NotFound();

                    if (dbSliderDetail.Subtitle.Trim().ToLower() == sliderDetail.Subtitle.Trim().ToLower() && dbSliderDetail.Header.Trim().ToLower() == sliderDetail.Header.Trim().ToLower()
                        && dbSliderDetail.Description.Trim().ToLower() == sliderDetail.Description.Trim().ToLower()
                        && dbSliderDetail.Photo == sliderDetail.Photo)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", fileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await sliderDetail.Photo.CopyToAsync(stream);
                    }

                    sliderDetail.Image = fileName;

                    _context.SliderDetails.Update(sliderDetail);

                    await _context.SaveChangesAsync();

                    string dbPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", dbSliderDetail.Image);

                    Helper.DeleteFile(dbPath);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        private async Task SaveFile(string path, IFormFile Singphoto)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);
            await Singphoto.CopyToAsync(stream);
        }

        private async Task<SliderDetail> GetByIdAsync(int id)
        {
            return await _context.SliderDetails.FindAsync(id);
        }

    }
}
