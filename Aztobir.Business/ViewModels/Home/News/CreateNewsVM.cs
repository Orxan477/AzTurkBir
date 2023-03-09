using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Home.News
{
    public class CreateNewsVM
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public IFormFile Photo { get; set; }
    }
}
