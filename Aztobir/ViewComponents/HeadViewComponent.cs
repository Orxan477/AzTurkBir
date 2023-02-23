using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.ViewComponents
{
    public class HeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
