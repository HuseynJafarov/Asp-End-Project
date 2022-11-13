using BackEnd_Project.Models;
using BackEnd_Project.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<SliderDetail> SliderDetails { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Servic> Servics { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<BlogHeader> BlogHeaders { get; set; }
        public IEnumerable<BrendLogo> BrendLogos { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public OurProduct OurProducts { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public TopSeller TopSellers { get; set; }

    }
}
