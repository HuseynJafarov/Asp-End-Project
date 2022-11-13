using BackEnd_Project.Models;
using BackEnd_Project.ViewModels.BasketViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels.LayoutViewModel
{
    public class FooterVM
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public IEnumerable<FooterCategory> Categories { get; set; }
        public List<BasketDetailVM> BasketProducts { get; set; }
       
        
    }
}
