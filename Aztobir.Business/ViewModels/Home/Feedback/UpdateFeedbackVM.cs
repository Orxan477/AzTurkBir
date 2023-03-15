using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Home.Feedback
{
    public class UpdateFeedbackVM
    {
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int UniversityId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
