using Aztobir.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private IAztobirService _aztobirService;
        public FooterViewComponent(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Logo = _aztobirService.SettingSerivice.GetSetting("Logo");
            ViewBag.Facebook = _aztobirService.SettingSerivice.GetSetting("Facebook");
            ViewBag.Twitter = _aztobirService.SettingSerivice.GetSetting("Twitter");
            ViewBag.Instagram = _aztobirService.SettingSerivice.GetSetting("Instagram");
            ViewBag.Linkedin = _aztobirService.SettingSerivice.GetSetting("Linkedin");
            return View();
        }
    }
}
