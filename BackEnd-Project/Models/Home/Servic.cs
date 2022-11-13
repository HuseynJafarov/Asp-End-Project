using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models
{
    public class Servic:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
    }
}
