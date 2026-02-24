using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhoneStore26.Models;

namespace PhoneStore26.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            Phone[] phone = new Phone[3];
            phone[0] = new Phone();
            phone[1] = new Phone();
            phone[2] = new Phone();

            phone[0].Manufacturer = "Samsung";
            phone[0].Series = "A25";
            phone[0].Price = 155;
            phone[0].Description = "low cost phone";

            phone[1].Manufacturer = "Samsung";
            phone[1].Series = "A35";
            phone[1].Price = 255;
            phone[1].Description = "cool phone";

            phone[2].Manufacturer = "iPhone";
            phone[2].Series = "15";
            phone[2].Price = 300;
            phone[2].Description = "best phone";

            return View(phone);
        }
        public IActionResult Buy(Phone phone)
        {
            return View(phone);
        }
    }
}
