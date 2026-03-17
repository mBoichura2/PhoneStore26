using BusinessLogic.Services;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ItemsController : Controller
    {
        private PhoneService _phoneService;

        public ItemsController(PhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public IActionResult Index(string search)
        {
            var phones = _phoneService.GetAll(search);
            return View(phones);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            _phoneService.Create(phone);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var phone = _phoneService.GetPhone(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            _phoneService.Update(phone);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var phone = _phoneService.GetPhone(id);
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _phoneService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Buy(Phone phone)
        {
            return View(phone);
        }
    }
}