using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Home.News
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public IFormFile Photo{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
