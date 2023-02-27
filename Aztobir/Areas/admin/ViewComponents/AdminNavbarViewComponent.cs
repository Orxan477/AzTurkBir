using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.ViewComponents
{
    public class AdminNavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
