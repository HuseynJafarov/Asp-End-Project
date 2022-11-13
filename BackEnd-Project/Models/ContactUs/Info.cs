using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models.ContactUs
{
    public class Info:BaseEntity
    {
        public string Information{ get; set; }
        public string WorkingHours { get; set; }
        public string Day { get; set; }
    }
}
