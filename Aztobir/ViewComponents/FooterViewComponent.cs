using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
