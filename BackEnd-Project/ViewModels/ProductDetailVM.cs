using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public Product Products { get; set; }
        public IEnumerable<Product> ShopProducts { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
    }
}
