using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Team
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Linkedin { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Photo { get; set; }
    }
}
