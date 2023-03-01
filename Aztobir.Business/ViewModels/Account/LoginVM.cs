using System.ComponentModel.DataAnnotations;

namespace Aztobir.Business.ViewModels.Account
{
    public class LoginVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
