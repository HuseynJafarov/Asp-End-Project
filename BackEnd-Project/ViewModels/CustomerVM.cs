using BackEnd_Project.Models.BlogPage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string BlogAuthor { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public List<Social> Social { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        public List<IFormFile> Photo { get; set; }
    }
}
