using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.ViewComponents
{
    public class UniversityViewComponent:ViewComponent
    {
        private IAztobirService _aztobirService;
        public UniversityViewComponent(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM universityView = new HomeVM()
            {
                Universities = await _aztobirService.UniversityService.GetAll(),
            };
            return View(universityView);
        }
    }
}
