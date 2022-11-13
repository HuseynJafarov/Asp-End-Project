using BackEnd_Project.Data;
using BackEnd_Project.Models;
using BackEnd_Project.ViewModels.BlogViewModel;
using Microsoft.AspNetCore.Authorization;
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

    public class BlogDetailController : Controller
    {
        private readonly AppDbContext _context;
        public BlogDetailController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogHeader> blogHeader = await _context.BlogHeaders.Where(m => !m.IsDeleted)
                .ToListAsync();

            List<BlogHeaderVM> mapDatas = GetMapDatas(blogHeader);

            return View(mapDatas);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            BlogHeader blog = await _context.BlogHeaders
                .Where(m => !m.IsDeleted && m.Id == id)
                .FirstOrDefaultAsync();

            if (blog == null) return NotFound();

            blog.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogHeaderVM blogHeaderVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(blogHeaderVM);
                }


                bool isExist = await _context.BlogHeaders.AnyAsync(m => m.Title.Trim() == blogHeaderVM.Title.Trim() && m.Description.Trim() == blogHeaderVM.Description.Trim());

                if (isExist)
                {
                    ModelState.AddModelError("Desription Or Title", "BlogHeader already exist");
                    return View();
                }


                BlogHeader blog = new BlogHeader
                {
                    Description = blogHeaderVM.Description,
                    Title = blogHeaderVM.Title,
                };

                await _context.BlogHeaders.AddAsync(blog);

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
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id is null) return BadRequest();

                BlogHeader blogHeader = await _context.BlogHeaders.Where(m=> m.IsDeleted == false).FirstOrDefaultAsync(m => m.Id == id);


                if (blogHeader is null) return NotFound();

                BlogHeaderVM blog = new BlogHeaderVM
                {
                    Description = blogHeader.Description,
                    Title = blogHeader.Title,
                };

                return View(blog);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogHeaderVM blogHeaderVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(blogHeaderVM);
                }

                BlogHeader blogHeader = await _context.BlogHeaders.AsNoTracking().Where(m => m.IsDeleted == false).FirstOrDefaultAsync(m => m.Id == id);

                if (blogHeader is null) return NotFound();

                if (blogHeader.Title.ToLower().Trim() == blogHeaderVM.Title.ToLower().Trim() && blogHeader.Description.ToLower().Trim() == blogHeaderVM.Description.ToLower().Trim())
                {
                    return RedirectToAction(nameof(Index));
                }

                BlogHeader blog = new BlogHeader
                {
                    Description = blogHeaderVM.Description,
                    Title = blogHeaderVM.Title,
                };

                _context.BlogHeaders.Update(blog);

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

                BlogHeader blogHeader = await _context.BlogHeaders.Where(m => m.IsDeleted == false).FirstOrDefaultAsync(m => m.Id == id);

                if (blogHeader is null) return NotFound();

                return View(blogHeader);

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }


        private List<BlogHeaderVM> GetMapDatas(List<BlogHeader> blogHeaders)
        {
            List<BlogHeaderVM> blogHeaderVM = new List<BlogHeaderVM>();

            foreach (var blogHeader in blogHeaders)
            {
                BlogHeaderVM newHeaderBlog = new BlogHeaderVM
                {
                    Id = blogHeader.Id,
                    Title = blogHeader.Title,
                    Description = blogHeader.Description,
                };

                blogHeaderVM.Add(newHeaderBlog);
            }

            return blogHeaderVM;
        }

        private async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.Where(m => !m.IsDeleted && m.Id == id).FirstOrDefaultAsync();
        }





    }
}
