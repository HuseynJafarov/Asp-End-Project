using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class SliderDetailVM
    {
        public int Id { get; set; }
        public string Subtitle { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        public List<IFormFile> Photo { get; set; }
    }
}
