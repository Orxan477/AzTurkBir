using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.About
{
    public class AboutVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
