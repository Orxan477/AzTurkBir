using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class TeamController : Controller
    {
        private IAztobirService _aztobirService;
        public TeamController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        public async Task<IActionResult> Index()
        {
            TeamViewVM team = new TeamViewVM()
            {
                Teams = await _aztobirService.TeamService.GetAll(),
            };
            return View(team);
        }
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                TeamViewVM team = new TeamViewVM()
                {
                    Team = await _aztobirService.TeamService.Get(id),
                };
                return View(team);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomNotFound", "Error", new { area = "null" });
            }
        }
    }
}
