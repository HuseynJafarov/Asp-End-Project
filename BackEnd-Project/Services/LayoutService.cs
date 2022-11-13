using BackEnd_Project.Data;
using BackEnd_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetDatasFromSetting()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }

        public async Task<IEnumerable<Language>> GEtDatasFromLanguage()
        {
            return await _context.Languages.Where(m => !m.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Currency>> GEtDatasFromCurrency()
        {
            return await _context.Currencies.Where(m => !m.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<FooterCategory>> GetDatasFromFooterCategory()
        {
            return await _context.FooterCategories.Where(m => !m.IsDeleted).ToListAsync();
        }
    }
}
