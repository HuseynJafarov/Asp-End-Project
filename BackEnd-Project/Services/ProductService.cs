using BackEnd_Project.Data;
using BackEnd_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll(int take)
        {
            return await _context.Products.Where(m => !m.IsDeleted).Include(m => m.Category).Include(m => m.ProductImages).Take(take).OrderBy(m => m.Id).ToListAsync();
        }
    }
}
