using BackEnd_Project.Models.BlogPage;
using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models
{
    public class Blog:BaseEntity
    {
        public string Desc { get; set; }
        public string Image { get; set; }
    }
}
