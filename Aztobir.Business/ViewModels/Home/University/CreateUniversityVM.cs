using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.ViewModels.Home.University
{
    public class CreateUniversityVM
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public string EducationLanguage { get; set; }
        public IFormFile Photo { get; set; }
        public int StudentCount { get; set; }
        public List<int> FacultiesId { get; set; }
        public int FacultyCount { get; set; }
        public string Content { get; set; }
        public string EducationPlan { get; set; }
        public bool Status { get; set; }
    }
}
