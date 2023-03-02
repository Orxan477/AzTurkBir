using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {
        private IAztobirService _aztobirService;

        public TeamController(IAztobirService aztobirService)
        {
            _aztobirService = aztobirService;
        }
        [Route("/admin/team/index")]
        public async Task<IActionResult> Index()
        {
            TeamViewVM team = new TeamViewVM()
            {
                Teams = await _aztobirService.TeamService.GetAll(),
            };
            return View(team);
        }
        [Route("/admin/team/create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
