using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class ContactFormController : Controller
    {
        private IAztobirService _aztobirService;
        public ContactFormController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/contact/index")]
        public async Task<IActionResult> Index()
        {
            var contacts = await _aztobirService.ContactService.GetAll();
            return View(contacts);
        }
        [Route("/admin/contact/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var contact = await _aztobirService.ContactService.Get(id);
                return View(contact);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [Route("/admin/contact/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.ContactService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
        [Route("/admin/contact/sendmessage/{id}")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [Route("/admin/contact/sendmessage/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(int id, SendMessageVM message)
        {
            if (!ModelState.IsValid)
            {
                return View(message);
            }
            try
            {
                var model = await _aztobirService.ContactService.SendMessage(id, message);
                if (model != "ok")
                {
                    return RedirectToAction("CustomBadRequest", "Error", new { area = "null" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
    }
}
