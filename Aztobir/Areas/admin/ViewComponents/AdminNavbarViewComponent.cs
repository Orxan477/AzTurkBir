using Aztobir.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.ViewComponents
{
    public class AdminNavbarViewComponent:ViewComponent
    {
        private IAztobirService _aztobirService;
        public AdminNavbarViewComponent(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Logo = _aztobirService.SettingSerivice.GetSetting("Header-Logo");
            return View();
        }
    }
}
