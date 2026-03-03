using System.Diagnostics;
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

        public IActionResult Index()
        {
            Phone[] phones = _context.Phones.ToArray();
            return View(phones);
        }
        public IActionResult Buy(Phone phone)
        {
            return View(phone);
        }
    }
}
