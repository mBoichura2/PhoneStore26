using DataAccess;
using DataAccess.Entities;
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

        public List<Category> GetAll(string search)
        {
            var categories = _context.Categories.ToList();
            _context.Categories.ToList();
            _context.Manufacturer.ToList();

            //if (!string.IsNullOrEmpty(search))
            //{
            //    categories = categories.Where(p => p.Series.Contains(search)).ToList();
            //}

            return categories;
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
