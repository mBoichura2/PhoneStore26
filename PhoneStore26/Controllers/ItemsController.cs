using BusinessLogic.Services;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index(string search)
        {
            var phones = await _phoneService.GetAll(search);
            return View(phones);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            await _phoneService.Create(phone);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var phone = await _phoneService.GetPhone(id);
            return View(phone);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            await _phoneService.Update(phone);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var phone = await _phoneService.GetPhone(id);
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _phoneService.Delete(id);
            return RedirectToAction("Index");
        }
        
        [Authorize]
        public IActionResult Buy(Phone phone)
        {
            return View(phone);
        }
    }
}