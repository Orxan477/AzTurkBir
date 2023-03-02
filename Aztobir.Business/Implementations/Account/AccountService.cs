using Aztobir.Business.Interfaces.Account;
using Aztobir.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Aztobir.Business.Implementations.Account
{
    public class AccountService : IAccountService
    {
        private SignInManager<AppUser> _signInManager;

        public AccountService(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<string> Login(AppUser user,string password)
        {
            if (user is null)
            {
                return "Username and Password is Wrong";
            }
            var result = await _signInManager.PasswordSignInAsync(user, password, false, true);
            if (result.IsLockedOut)
            {
                return "Your Account is locked. 3 minutes leter is unlocked";
            }

            if (!result.Succeeded)
            {
                return "Username and Password is Wrong";
            }
            else
            {
                return "ok";
            }
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
