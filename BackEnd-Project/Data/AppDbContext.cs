using BackEnd_Project.Models;
using BackEnd_Project.Models.ContactUs;
using BackEnd_Project.Models.Home;
using BackEnd_Project.Models.BlogPage;
using BackEnd_Project.Models.BlogDetail;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogVideo> BlogVideos { get; set; }
        public DbSet<BlogDetailDesc> BlogDetailDescs { get; set; }
        public DbSet<BlogHeader> BlogHeaders { get; set; }
        public DbSet<BrendLogo> BrendLogos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<FooterCategory> FooterCategories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Servic> Servics { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SliderDetail> SliderDetails { get; set; }
        public DbSet<TopSeller> TopSellers { get; set; }
        public DbSet<OurProduct> OurProducts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<TellUs> TellUs { get; set; }
    


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}


