using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels.BasketViewModel
{
    public class BasketDetailVM
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int Count { get; set; }
    }
}
