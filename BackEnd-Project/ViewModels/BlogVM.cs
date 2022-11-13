using BackEnd_Project.Models;
using BackEnd_Project.Models.BlogPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.ViewModels
{
    public class BlogVM
    {
        public List<Blog> Blogs { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<BlogVideo> Videos { get; set; }
    }
}
