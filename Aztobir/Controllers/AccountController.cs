using Aztobir.Business.Interfaces;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.Account;
using Aztobir.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aztobir.UI.Controllers
{
    public class AccountController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;
        private IAztobirService _aztobirService;


        public AccountController(RoleManager<IdentityRole> roleManager,
                                 UserManager<AppUser> userManager,
                                 IAztobirService aztobirService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _aztobirService = aztobirService;
        }
        #region Register
        //public async Task<IActionResult> Register()
        //{
        //    AppUser user = new AppUser()
        //    {
        //        Email = "orxan_qanbarov@mail.ru",
        //        UserName = "Orxan477",
        //    };
        //    IdentityResult identityResult = await _userManager.CreateAsync(user, "Aztobir123@");
        //    if (identityResult.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
        //    }
        //    return Json("hazir");
        //}
        #endregion

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            string error = await _aztobirService.AccountService.Login(user, login.Password);
            if (error == "ok")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, error);
                return View(login);
            }
        }
        public async Task<IActionResult> LogOut(string? ReturnUrl)
        {
            await _aztobirService.AccountService.LogOut();
            if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            return RedirectToAction("Index", "Home");
        }

        #region CreateRole
        //public async Task CreateRole()
        //{
        //    foreach (var item in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(item.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
        //        }
        //    }
        //}
        #endregion
    }
}
