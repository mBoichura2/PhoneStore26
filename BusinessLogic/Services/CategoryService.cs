using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BusinessLogic.Services
{
    public class CategoryService
    {
        private PhoneStoreDbContext _context;

        public CategoryService(PhoneStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll(string search)
        {
            var categories = await _context.Categories.ToListAsync();
            await _context.Categories.ToListAsync();
            await _context.Manufacturer.ToListAsync();

            //if (!string.IsNullOrEmpty(search))
            //{
            //    categories = categories.Where(p => p.Series.Contains(search)).ToList();
            //}

            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
