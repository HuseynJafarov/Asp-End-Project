using BackEnd_Project.Data;
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

    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _context.Tags
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                bool isExist = await _context.Tags.AnyAsync(m => m.TagName.Trim() == tag.TagName.Trim());


                if (isExist)
                {
                    ModelState.AddModelError("TagName", "Tag already exist");
                    return View();
                }

                await _context.Tags.AddAsync(tag);

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

            Tag tag = await _context.Tags.FindAsync(id);

            if (tag == null) return NotFound();

            return View(tag);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(m => m.Id == id);

            tag.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                Tag tag = await _context.Tags.FirstOrDefaultAsync(m => m.Id == id);

                if (tag is null) return NotFound();

                return View(tag);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tag tag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tag);
                }

                Tag dbTag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbTag is null) return NotFound();

                if (dbTag.TagName.ToLower().Trim() == tag.TagName.ToLower().Trim())
              
                {
                    return RedirectToAction(nameof(Index));
                }

                // dbCategory.Name = category.Name;

                _context.Tags.Update(tag);

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
