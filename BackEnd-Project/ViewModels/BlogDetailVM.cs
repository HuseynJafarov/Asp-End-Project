using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogDetail;
using BackEnd_Project.Models.BlogPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class BlogDetailVM
    {
        public IEnumerable<Blog> Blog { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<BlogVideo> Videos { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }

    }
}
