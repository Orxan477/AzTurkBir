using Aztobir.Business.Interfaces;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private string _errorMessage;
        private IAztobirService _aztobirService;
        private IWebHostEnvironment _env;

        public AboutController(IAztobirService aztobirService, IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
        }
        [Route("/admin/about/index/")]
        public async Task<IActionResult> Index()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aztobirService.AboutService.Get(),
            };
            return View(about);
        }
        [Route("/admin/about/detail/")]
        public async Task<IActionResult> Detail()
        {
            AboutViewVM about = new AboutViewVM()
            {
                About = await _aztobirService.AboutService.Get(),
            };
            return View(about);
        }
        [Route("/admin/about/update/")]
        public async Task<IActionResult> Update()
        {
            //return Json(id);
            var about = await _aztobirService.AboutService.Get();
            if (about is null) return NotFound();
            return View(about);
        }
        [Route("/admin/about/update/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutVM about)
        {
            try
            {
                //return Json(about.Photo.ContentType);
                if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(about);
                //int size = int.Parse(GetSetting("PhotoSize"));
                var db = await _aztobirService.AboutService.Update(about, _env.WebRootPath);
                if (db != "ok")
                {
                    ModelState.AddModelError(string.Empty, db);
                }
                return RedirectToAction("detail");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
        private bool CheckImageValid(IFormFile file, string type, int size)
        {
            if (!Extension.CheckType(file, type))
            {
                _errorMessage = "The type is not correct";
                return false;
            }
            if (!Extension.CheckSize(file, size))
            {
                _errorMessage = $"The size of this photo is {size}";
                return false;
            }
            return true;
        }
    }
}
