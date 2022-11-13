using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels.ProductViewModel
{
    public class ProductCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        public string Discount { get; set; }
        [Required]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
