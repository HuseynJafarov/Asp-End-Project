using EmbryoFrontToBack.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models.BlogPage
{
    public class Customer : BaseEntity
    {
        public string Image { get; set; }
        public string BlogAuthor { get; set; }
        public string Position { get; set; }
        public List<Social> Socials { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
