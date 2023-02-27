using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.ViewComponents
{
    public class AdminHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
