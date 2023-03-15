using Aztobir.Business.Interfaces;
using Aztobir.Business.ViewModels.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aztobir.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {
        private IAztobirService _aztobirService;
        private IWebHostEnvironment _env;

        public TeamController(IAztobirService aztobirService,IWebHostEnvironment env)
        {
            _aztobirService = aztobirService;
            _env = env;
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
        [Route("/admin/team/Detail/{id}")]
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
                return RedirectToAction("Index", "Team", new { area = "admin" });
            }
        }
        [Route("/admin/team/create/")]
        public async Task<IActionResult> Create()
        {
            await GetSelectedItemAsync();
            return View();
        }
        [Route("/admin/team/create/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTeamVM team)
        {
            if (!ModelState.IsValid) return View(team);
            var saveNews = await _aztobirService.TeamService.Create(team, _env.WebRootPath,PhotoSize());
            if (saveNews == "ok")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, saveNews);
                await GetSelectedItemAsync();
                return View(team);
            }
        }
        [Route("/admin/team/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var model = await _aztobirService.TeamService.GetUpdate(id);
                await GetSelectedItemAsync();
                return View(model);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
        [Route("/admin/team/update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateTeamVM team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            //if (ModelState["Photo"].ValidationState == ModelValidationState.Valid) 
            try
            {
                var model = await _aztobirService.TeamService.Update(id, team, _env.WebRootPath,PhotoSize());
                if (model != "ok")
                {
                    ModelState.AddModelError(string.Empty, model);
                    await GetSelectedItemAsync();
                    return View(team);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Route("/admin/team/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aztobirService.TeamService.Delete(id);
                return RedirectToAction("Index", "Team", new { area = "admin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Team", new { area = "admin" });
            }

        }
        private async Task GetSelectedItemAsync()
        {
            ViewBag.position = new SelectList(await _aztobirService.PositionService.GetAll(), "Id", "Name");
        }
        private int PhotoSize()
        {
            string photosize = _aztobirService.SettingSerivice.GetSetting("PhotoSize");
            return Convert.ToInt32(photosize);
        }
    }
}
