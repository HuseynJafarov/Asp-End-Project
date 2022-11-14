using BackEnd_Project.Data;
using BackEnd_Project.Helpers;
using BackEnd_Project.Models;
using BackEnd_Project.Services;
using BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductService _productService;
        private readonly LayoutService _layoutService;

        public ShopController(AppDbContext context, ProductService productService, LayoutService layoutService)
        {
            _context = context;
            _productService = productService;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
      

            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            int take = int.Parse(settingDatas["ProductTake"]);

            List<Product> products = await _context.Products.Where(m => !m.IsDeleted)
                .Include(m => m.Category).Include(m => m.ProductImages)
                .Skip((page * take) - take).Take(take).OrderBy(m => m.Id).ToListAsync();
            IEnumerable<Category> categories = await _context.Categories.Where(m => m.IsDeleted == false).Include(m => m.Products).ToListAsync();

            int count = await GetPageCount(take);

            List<ShopVM> shopList = new List<ShopVM>();

            ShopVM model = new ShopVM
            {
                Products = products.ToList(),
                Categories = categories.ToList()

            };


            shopList.Add(model);

            Paginate<ShopVM> result = new Paginate<ShopVM>(shopList, page, count);

            return View(result);
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

        [HttpPost]
        public async Task<IActionResult> PostComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = comment.ProductsId });
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

        private async Task<int> GetPageCount(int take)
        {
            int productCount = await _context.Products.Where(m => !m.IsDeleted).CountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
    }
}
