using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.Contact;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class ContactController : Controller
    {
        private IAztobirService _aztobirService;

        public ContactController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public IActionResult Index()
        {
            ViewBag.Phone1 = _aztobirService.SettingSerivice.GetSetting("Phone1");
            ViewBag.Phone2 = _aztobirService.SettingSerivice.GetSetting("Phone2");
            ViewBag.Adress = _aztobirService.SettingSerivice.GetSetting("Adress");
            ViewBag.Email1 = _aztobirService.SettingSerivice.GetSetting("Email1");
            ViewBag.Email2 = _aztobirService.SettingSerivice.GetSetting("Email2");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> SendContact(CreateContactVM createContact)
        {
            await _aztobirService.ContactService.Create(createContact);
            return RedirectToAction(nameof(Index));
        }
    }
}
