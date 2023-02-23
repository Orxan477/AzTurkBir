using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.ViewComponents
{
    public class ScriptViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
