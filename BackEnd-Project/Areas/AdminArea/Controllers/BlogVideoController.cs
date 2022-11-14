using BackEnd_Project.Data;
using BackEnd_Project.Models.BlogDetail;
using BackEnd_Project.Models.BlogPage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class BlogVideoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogVideoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            List<BlogVideo> videos = await _context.BlogVideos
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            return View(videos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogVideo blogVideo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                bool isExist = await _context.BlogVideos.AnyAsync(m => m.Name.Trim() == blogVideo.Name.Trim()
                && m.Name.Trim() == blogVideo.Video.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Name Video", "BlogVideo already exist");
                    return View();
                }

                await _context.BlogVideos.AddAsync(blogVideo);

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
            if (id == null) return BadRequest();

            BlogVideo blogVideo = await _context.BlogVideos.FindAsync(id);

            if (blogVideo == null) return NotFound();

            return View(blogVideo);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            BlogVideo blogVideo = await _context.BlogVideos.FirstOrDefaultAsync(m => m.Id == id);

            blogVideo.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                BlogVideo blogVideo = await _context.BlogVideos.FirstOrDefaultAsync(m => m.Id == id);

                if (blogVideo is null) return NotFound();

                return View(blogVideo);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogVideo blogVideo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(blogVideo);
                }

                BlogVideo dbVideo = await _context.BlogVideos.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbVideo is null) return NotFound();

                if (dbVideo.Name.ToLower().Trim() == blogVideo.Name.ToLower().Trim() &&
                    dbVideo.Video.ToLower().Trim() == blogVideo.Video.ToLower().Trim())
                {
                    return RedirectToAction(nameof(Index));
                }

                // dbCategory.Name = category.Name;

                _context.BlogVideos.Update(blogVideo);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }

}
