using EmbryoFrontToBack.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models
{
    public class SliderDetail:BaseEntity
    {
        public string Subtitle { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
