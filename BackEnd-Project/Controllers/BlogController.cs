using BackEnd_Project.Data;
using BackEnd_Project.Helpers;
using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogPage;
using BackEnd_Project.Services;
using BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;

        public BlogController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
           
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            int take = int.Parse(settingDatas["Blog"]);

            List<Blog> blogs = await _context.Blogs.Where(m=> m.IsDeleted== false).Skip((page * take) - take).Take(take).ToListAsync();
            IEnumerable<Customer> customer = await _context.Customers
              .Where(m => !m.IsDeleted)
              .Include(m => m.Socials)
              .ToListAsync();
            IEnumerable<Tag> tags = await _context.Tags.Where(m => !m.IsDeleted).ToListAsync();
            List<BlogVideo> videos = await _context.BlogVideos.Where(m => !m.IsDeleted).ToListAsync();


            int count = await GetPageCount(take);


            List<BlogVM> blogList = new List<BlogVM>();

            BlogVM model = new BlogVM
            {
                Blogs = blogs.ToList(),
                Date = DateTime.Now,
                Customers = customer,
                Tags = tags,
                Videos = videos,
            };

            blogList.Add(model);

            Paginate<BlogVM> result = new Paginate<BlogVM>(blogList, page, count);

            return View(result);
        }



        private async Task<int> GetPageCount(int take)
        {
            int blogCount = await _context.Blogs.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)blogCount / take);
        }

    }
}
