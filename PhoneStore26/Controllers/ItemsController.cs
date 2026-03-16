using Microsoft.AspNetCore.Mvc;
using PhoneStore26.Data;
using PhoneStore26.Models;

namespace PhoneStore26.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ + дуже проста фільтрація
        public IActionResult Index(string search)
        {
            var phones = _context.Phones.ToList();
            _context.Categories.ToList();
            _context.Manufacturer.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                phones = phones.Where(p => p.Series.Contains(search)).ToList();
            }

            return View(phones);
        }

        // CREATE - відображення форми
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - збереження в БД
        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // UPDATE - відображення форми з даними
        public IActionResult Edit(int id)
        {
            var phone = _context.Phones.Find(id);
            return View(phone);
        }

        // UPDATE - збереження змін
        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            _context.Phones.Update(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE - відображення сторінки підтвердження
        public IActionResult Delete(int id)
        {
            var phone = _context.Phones.Find(id);
            return View(phone);
        }

        // DELETE - фізичне видалення
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