using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home.University;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityFormController : Controller
    {
        private IAztobirService _aztobirService;
        public UniversityFormController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/university/form/index")]
        public async Task<IActionResult> Index()
        {
            UniversityViewVM uni = new UniversityViewVM()
            {
                UniversityForms = await _aztobirService.UniversityFormService.GetAll(),
            };
            return View(uni);
        }
        [Route("/admin/university/form/detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                UniversityViewVM uni = new UniversityViewVM()
                {
                    UniversityFormOdd = await _aztobirService.UniversityFormService.Get(id),
                };
                return View(uni);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [Route("/admin/university/form/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.UniversityFormService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
    }
}
