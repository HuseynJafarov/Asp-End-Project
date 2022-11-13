using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models.BlogPage
{
    public class BlogVideo: BaseEntity
    {
        public string Video { get; set; }
        public string Name { get; set; }
    }
}
