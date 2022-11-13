using BackEnd_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels.LayoutViewModel
{
    public class HeaderVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public int Count { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<Product>  Products { get; set; }
    }
}
