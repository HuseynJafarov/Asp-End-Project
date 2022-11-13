using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models.BlogPage
{
    public class Social : BaseEntity
    {
        public string Image { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
