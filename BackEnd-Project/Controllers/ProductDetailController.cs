using BackEnd_Project.Data;
using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogDetail;
using BackEnd_Project.Models.BlogPage;
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
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductService _productService;
        private readonly LayoutService _layoutService;

        public ProductDetailController(AppDbContext context, ProductService productService, LayoutService layoutService)
        {
            _context = context;
            _productService = productService;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            int take = int.Parse(settingDatas["ProductDetailTake"]);

            Product products = await _context.Products.Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.ProductImages).FirstOrDefaultAsync();

            IEnumerable<Customer> customer = await _context.Customers
               .Where(m => !m.IsDeleted)
               .Include(m => m.Socials)
               .ToListAsync();

            IEnumerable<Product> shopProducts = await _productService.GetAll(take);
            BlogDetailDesc blogDetails = await _context.BlogDetailDescs.Where(m => !m.IsDeleted).FirstOrDefaultAsync();

            ProductDetailVM model = new ProductDetailVM
            {
                Products = products,
                ShopProducts = shopProducts,
                Description1 = blogDetails.Desc1,
                Description2 = blogDetails.Desc2,
                Description3 = blogDetails.Desc3,
                Customers = customer,

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
