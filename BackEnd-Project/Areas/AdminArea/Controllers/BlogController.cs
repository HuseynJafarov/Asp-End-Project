using BackEnd_Project.Data;
using BackEnd_Project.Helpers;
using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogPage;
using BackEnd_Project.ViewModels;
using BackEnd_Project.ViewModels.BlogViewModel;
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

    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            BlogVM blogVM = new BlogVM
            {
               Blogs = blogs,
               Date = DateTime.Today,
            };

            return View(blogVM);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            List<Blog> dbBlog = await GetByIdToLIstAsync((int)id);

            if (dbBlog == null) return NotFound();

            BlogVM blogVM = new BlogVM
            {
              Blogs = dbBlog,
              Date = DateTime.Today,
            };

            return View(blogVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = await _context.Blogs
                .Where(m => !m.IsDeleted && m.Id == id)
                .FirstOrDefaultAsync();

            if (blog == null) return NotFound();

            blog.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Blog dbBlog = await GetByIdAsync((int)id);

            if (dbBlog == null) return NotFound();

            BlogUpdateVM blogUpdateVM = new BlogUpdateVM
            {
                Id = dbBlog.Id,
                Description = dbBlog.Desc,
                Photo = dbBlog.Image,

            };

            return View(blogUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogUpdateVM blogUpdateVM)
        {
            if (!ModelState.IsValid) return View(blogUpdateVM);

            Blog dbBlog = await GetByIdAsync(id);

            if (blogUpdateVM.Image != null)
            {
                if (!blogUpdateVM.Image.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View(blogUpdateVM);
                }

                if (!blogUpdateVM.Image.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image size");
                    return View(blogUpdateVM);
                }

                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", dbBlog.Image);
                Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + blogUpdateVM.Image.FileName;

                string pathh = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                await Helper.SaveFile(pathh, blogUpdateVM.Image);

                Blog dbImages = new Blog
                {
                    Image = fileName
                };

                _context.Blogs.Update(dbImages);

            }
            
            dbBlog.Desc = blogUpdateVM.Description;

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blogCreateVM)
        {
            if (!ModelState.IsValid) return View(blogCreateVM);

            if (blogCreateVM.Image != null)
            {
                if (!blogCreateVM.Image.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image type");
                    return View(blogCreateVM);
                }

                if (!blogCreateVM.Image.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "Please choose correct image size");
                    return View(blogCreateVM);
                }

                string fileName = Guid.NewGuid().ToString() + "_" + blogCreateVM.Image.FileName;

                string pathh = Helper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                await Helper.SaveFile(pathh, blogCreateVM.Image);

                Blog blog = new Blog
                {
                    Image = fileName,
                    Desc = blogCreateVM.Description,
                };

                await _context.Blogs.AddAsync(blog);

            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


        private async Task<List<Blog>> GetByIdToLIstAsync(int id)
        {
            return await _context.Blogs.Where(m => !m.IsDeleted && m.Id == id).ToListAsync();
        }

        private async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.Where(m => !m.IsDeleted && m.Id == id).FirstOrDefaultAsync();
        }


    }
}
