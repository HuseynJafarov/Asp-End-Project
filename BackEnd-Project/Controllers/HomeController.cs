
using BackEnd_Project.Data;
using BackEnd_Project.Models;
using BackEnd_Project.Models.Home;
using BackEnd_Project.Services;
using BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Controllers
{
    public class HomeController : Controller
    {
            private readonly AppDbContext _context;
            private readonly LayoutService _layoutService;
            public HomeController(AppDbContext context, LayoutService layoutService)
            {
                _context = context;
                _layoutService = layoutService;
            }

            public async Task<IActionResult> Index()
            {
                Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

                int take = int.Parse(settingDatas["HomeTakeProduct"]);

                IEnumerable<Servic> servics = await _context.Servics.ToListAsync();
                IEnumerable<Banner> banners = await _context.Banners.ToListAsync();
                OurProduct ourProducts = await _context.OurProducts.FirstOrDefaultAsync();
                TopSeller topSellers = await _context.TopSellers.FirstOrDefaultAsync();
                IEnumerable<Blog> blogs = await _context.Blogs.ToListAsync();
                IEnumerable<BlogHeader> blogHeaders = await _context.BlogHeaders.ToListAsync();
                IEnumerable<BrendLogo> brendLogos = await _context.BrendLogos.ToListAsync();
                IEnumerable<SliderDetail> sliderDetail = await _context.SliderDetails.ToListAsync();
                IEnumerable<Category> categories = await _context.Categories.Where(m => m.IsDeleted == false).ToListAsync();
                IEnumerable<Product> products = await _context.Products
                    .Where(m => m.IsDeleted == false)
                    .Include(m => m.Category)
                    .Include(m => m.ProductImages).Take(take).ToListAsync();

                HomeVM model = new HomeVM
                {
                    SliderDetails = sliderDetail,
                    Categories = categories,
                    Products = products,
                    Servics = servics,
                    Blogs = blogs,
                    BlogHeaders = blogHeaders,
                    BrendLogos = brendLogos,
                    Banners = banners,
                    OurProducts = ourProducts,
                    TopSellers = topSellers,

                };

                return View(model);
            }


            [HttpPost]
            public async Task<IActionResult> AddBasket(int? id)
            {
                if (id is null) return BadRequest();

                var dbProduct = await GetProductById(id);

                if (dbProduct == null) return NotFound();

                List<BasketVM> basket = GetBasket();

                UpdateBasket(basket, dbProduct.Id);

                Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

                return RedirectToAction("Index");
            }


            private void UpdateBasket(List<BasketVM> basket, int id)
            {
                BasketVM existProduct = basket.FirstOrDefault(m => m.Id == id);

                if (existProduct == null)
                {
                    basket.Add(new BasketVM
                    {
                        Id = id,
                        Count = 1
                    });
                }
                else
                {
                    existProduct.Count++;
                }
            }

            private async Task<Product> GetProductById(int? id)
            {
                return await _context.Products.FindAsync(id);
            }

            private List<BasketVM> GetBasket()
            {
                List<BasketVM> basket;

                if (Request.Cookies["basket"] != null)
                {
                    basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                }
                else
                {
                    basket = new List<BasketVM>();
                }

                return basket;
            }
    }
}
