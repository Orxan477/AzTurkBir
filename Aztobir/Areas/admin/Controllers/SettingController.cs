using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Setting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private IWebHostEnvironment _env;
        private IAztobirService _aztobirService;

        public SettingController(IAztobirService aztobirService, IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
        }
        [Route("/admin/setting/index/")]
        public async Task<IActionResult> Index()
        {
            
            return View(await _aztobirService.SettingSerivice.SettingList());
        }
        [Route("/admin/setting/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {

            return View(await _aztobirService.SettingSerivice.Setting(id));
        }
        [Route("/admin/setting/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,SettingListVM setting)
        {
            await _aztobirService.SettingSerivice.Update(id, setting,_env.WebRootPath, PhotoSize());
            return RedirectToAction("Index");
        }
        private int PhotoSize()
        {
            string photosize = _aztobirService.SettingSerivice.GetSetting("PhotoSize");
            return Convert.ToInt32(photosize);
        }
    }
}
