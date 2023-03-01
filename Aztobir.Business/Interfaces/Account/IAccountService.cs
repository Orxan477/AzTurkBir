using Aztobir.Business.ViewModels.Account;
using Aztobir.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Business.Interfaces.Account
{
    public interface IAccountService
    {
        Task<string> Login(AppUser user, string password);
        Task LogOut();
    }
}
