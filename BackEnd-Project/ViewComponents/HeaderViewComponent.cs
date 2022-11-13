using BackEnd_Project.Models;
using BackEnd_Project.Services;
using BackEnd_Project.ViewModels;
using BackEnd_Project.ViewModels.LayoutViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;
        private readonly ProductService _productService;

        public HeaderViewComponent(LayoutService layoutService, ProductService productService)
        {
            _productService = productService;
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = 0;

            if (Request.Cookies["basket"] != null)
            {
                List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                //count = basket.Count();

                //foreach (var item in basket)
                //{
                //    count += item.Count;
                //}

                count = basket.Sum(m => m.Count);

            }
            else
            {
                count = 0;
            }

            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();
            IEnumerable<Language> languages = await _layoutService.GEtDatasFromLanguage();
            IEnumerable<Currency> currencies = await _layoutService.GEtDatasFromCurrency();

         

            HeaderVM headerVM = new HeaderVM
            {
                Count = count,
                Settings = settingDatas,
                Languages = languages,
                Currencies = currencies,
                
            };


            return await Task.FromResult(View(headerVM));
        }

    }
}
