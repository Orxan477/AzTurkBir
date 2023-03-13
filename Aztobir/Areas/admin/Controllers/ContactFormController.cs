using Aztobir.Business.Interfaces;
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

                return Json(ex.Message);
            }
        }
    }
}
