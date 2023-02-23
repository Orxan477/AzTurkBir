using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
