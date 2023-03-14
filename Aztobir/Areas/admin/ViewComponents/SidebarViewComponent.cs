using Aztobir.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        private IAztobirService _aztobirService;

        public SidebarViewComponent(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = await _aztobirService.GoalService.GetAll();
            return View(models.Count());
        }
    }
}
