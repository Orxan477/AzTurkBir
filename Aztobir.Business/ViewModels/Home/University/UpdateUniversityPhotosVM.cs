using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Home.University
{
    public class UpdateUniversityPhotosVM
    {
        public IFormFile Photo{ get; set; }
        public string Image { get; set; }
    }
}
