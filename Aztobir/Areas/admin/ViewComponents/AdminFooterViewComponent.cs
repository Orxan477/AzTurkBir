using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.ViewComponents
{
    public class AdminFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
