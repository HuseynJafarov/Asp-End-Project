using BackEnd_Project.Data;
using BackEnd_Project.Models.BlogDetail;
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

    public class BlogDetailDescController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogDetailDescController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            List<BlogDetailDesc> blogs = await _context.BlogDetailDescs
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogDetailDesc description)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                bool isExist = await _context.BlogDetailDescs.AnyAsync(m => m.Desc1.Trim() == description.Desc1.Trim()
                && m.Desc2.Trim() == description.Desc2.Trim()
                && m.Desc3.Trim() == description.Desc3.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Description", "BlogDetailDecs already exist");
                    return View();
                }

                await _context.BlogDetailDescs.AddAsync(description);

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

            BlogDetailDesc description = await _context.BlogDetailDescs.FindAsync(id);

            if (description == null) return NotFound();

            return View(description);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            BlogDetailDesc description = await _context.BlogDetailDescs.FirstOrDefaultAsync(m => m.Id == id);

            description.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                BlogDetailDesc description = await _context.BlogDetailDescs.FirstOrDefaultAsync(m => m.Id == id);

                if (description is null) return NotFound();

                return View(description);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogDetailDesc description)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(description);
                }

                BlogDetailDesc dbDescription = await _context.BlogDetailDescs.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbDescription is null) return NotFound();

                if (dbDescription.Desc1.ToLower().Trim() == description.Desc1.ToLower().Trim() &&
                    dbDescription.Desc2.ToLower().Trim() == description.Desc2.ToLower().Trim() &&
                    dbDescription.Desc3.ToLower().Trim() == description.Desc3.ToLower().Trim())
                {
                    return RedirectToAction(nameof(Index));
                }

                // dbCategory.Name = category.Name;

                _context.BlogDetailDescs.Update(description);

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
