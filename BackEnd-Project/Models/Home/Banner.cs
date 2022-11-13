using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models.Home
{
    public class Banner:BaseEntity
    {
        public string Name { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
