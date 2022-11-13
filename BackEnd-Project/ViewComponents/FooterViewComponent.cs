using BackEnd_Project.Data;
using BackEnd_Project.Models;
using BackEnd_Project.Services;
using BackEnd_Project.ViewModels;
using BackEnd_Project.ViewModels.BasketViewModel;
using BackEnd_Project.ViewModels.LayoutViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewComponents
{
    public class FooterViewComponent: ViewComponent
    {
        private readonly LayoutService _layoutService;
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FooterViewComponent(LayoutService layoutService, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _layoutService = layoutService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string,string> settingDatas = await _layoutService.GetDatasFromSetting();
            List<BasketDetailVM> basketDetailList = new List<BasketDetailVM>();

            IEnumerable<FooterCategory> footerCategories = await _layoutService.GetDatasFromFooterCategory();
            if (Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketItems = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);


                foreach (var item in basketItems)
                {
                    Product product = await _context.Products
                        .Where(m => m.Id == item.Id && m.IsDeleted == false)
                        .Include(m => m.ProductImages).FirstOrDefaultAsync();

                    BasketDetailVM basketModel = new BasketDetailVM
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Image = product.ProductImages.Where(m => m.IsMain)?.FirstOrDefault().Image,
                        Price = product.Price,
                        Count = item.Count,
                        Total = product.Price * item.Count
                    };
                    basketDetailList.Add(basketModel);
                }

                FooterVM footerVM = new FooterVM
                {
                    Phone = settingDatas["Phone"],
                    Address = settingDatas["Address"],
                    Mail = settingDatas["MailUs"],
                    Categories = footerCategories,
                    BasketProducts = basketDetailList
                };
                return await Task.FromResult(View(footerVM));
            }
            else
            {
                FooterVM footerVM = new FooterVM
                {
                    Phone = settingDatas["Phone"],
                    Address = settingDatas["Address"],
                    Mail = settingDatas["MailUs"],
                    Categories = footerCategories,
                    BasketProducts = basketDetailList
                };
                return await Task.FromResult(View(footerVM));
            }
            
        }

       


    }
}
