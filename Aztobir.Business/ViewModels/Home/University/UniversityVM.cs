using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Home.University
{
    public class UniversityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string EducationLanguage { get; set; }
        public int StudentCount { get; set; }
        public int FacultyCount { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public IFormFile Photo { get; set; }
    }
}
