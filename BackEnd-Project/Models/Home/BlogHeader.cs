using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models
{
    public class BlogHeader:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
  
    }
}
