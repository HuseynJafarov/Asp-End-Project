using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels.BlogViewModel
{
    public class BlogCreateVM
    {
        public string Photo { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
