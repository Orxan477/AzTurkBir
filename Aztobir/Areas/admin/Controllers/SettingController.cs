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
        private IAztobirService _aztobirService;

        public SettingController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
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
            return View(await _aztobirService.SettingSerivice.Setting(id));
        }
    }
}
