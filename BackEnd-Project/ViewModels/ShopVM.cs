using BackEnd_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class ShopVM
    {
        public ICollection<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}
