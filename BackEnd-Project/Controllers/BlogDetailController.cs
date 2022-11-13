using BackEnd_Project.Data;
using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogDetail;
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
    public class BlogDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;


        public BlogDetailController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            int take = int.Parse(settingDatas["BlogDetail"]);

            List<Blog> blog = await _context.Blogs.Where(m => m.IsDeleted == false).Take(take).ToListAsync();
            IEnumerable<Customer> customer = await _context.Customers
                .Where(m => !m.IsDeleted)
                .Include(m => m.Socials)
                .ToListAsync();
            IEnumerable<Tag> tags = await _context.Tags.Where(m => !m.IsDeleted).ToListAsync();
            List<BlogVideo> videos = await _context.BlogVideos.Where(m => !m.IsDeleted).ToListAsync();
            BlogDetailDesc blogDetails = await _context.BlogDetailDescs.Where(m => !m.IsDeleted).FirstOrDefaultAsync();

            BlogDetailVM blogDetailVM = new BlogDetailVM
            {
                Blog = blog,
                Date = DateTime.Now,
                Customers = customer,
                Tags = tags,
                Videos = videos,
                Description1 = blogDetails.Desc1,
                Description2 = blogDetails.Desc2,
                Description3 = blogDetails.Desc3,

            };


            

            return View(blogDetailVM);

        }
    }
}
