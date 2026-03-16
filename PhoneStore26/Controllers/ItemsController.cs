using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore26.Data;
using PhoneStore26.Models;

namespace PhoneStore26.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Завдання 5 (Read) та Завдання 6 (Фільтрація)
        public IActionResult Index(int? categoryId, string searchString)
        {
            // Передаємо дані для випадаючого списку категорій (для фільтра)
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Title", categoryId);
            ViewData["CurrentFilter"] = searchString;

            // Завантажуємо телефони разом з пов'язаними таблицями
            var phones = _context.Phones
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .AsQueryable();

            // Логіка фільтрації
            if (categoryId.HasValue)
            {
                phones = phones.Where(p => p.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                phones = phones.Where(p => p.Series.Contains(searchString) ||
                                           p.Manufacturer.Title.Contains(searchString));
            }

            return View(phones.ToList());
        }

        // Завдання 5 (Create) - GET
        public IActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturer, "Id", "Title");
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Title");
            return View();
        }

        // Завдання 5 (Create) - POST
        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            _context.Add(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Завдання 5 (Update) - GET
        public IActionResult Edit(int? id)
        {
            var phone = _context.Phones.Find(id);
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturer, "Id", "Title", phone.ManufacturerId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Title", phone.CategoryId);
            return View(phone);
        }

        // Завдання 5 (Update) - POST
        [HttpPost]
        public IActionResult Edit(int id, Phone phone)
        {
            _context.Update(phone);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Завдання 5 (Delete) - GET
        public IActionResult Delete(int? id)
        {
            var phone = _context.Phones.Find(id);
            return View(phone);
        }

        // Завдання 5 (Delete) - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var phone = _context.Phones.Find(id);
            _context.Phones.Remove(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Buy(Phone phone)
        {
            return View(phone);
        }
    }
}