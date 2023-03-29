using Aztobir.Business.ViewModels.Home.City;
using Aztobir.Business.ViewModels.Home.Faculty;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.Position;
using Aztobir.Business.ViewModels.University;

namespace Aztobir.Business.ViewModels.Home.University
{
    public class UniversityViewVM
    {
        public UniversityVM University { get; set; }
        //public Paginate<UniversityVM> Universities { get; set; }
        public List<UniversityVM> Universities { get; set; }
        public List<FacultyVM> Faculties { get; set; }
        public List<UniPhotosVM> Photos { get; set; }
        public List<FeedbackVM> Feedbacks { get; set; }
        public List<CityVM> Cities{ get; set; }
        public CityVM City{ get; set; }
        public UniversityFormVM UniversityForm { get; set; }
        public List<UniversityViewFormVM> UniversityForms { get; set; }
        public UniversityViewFormVM UniversityFormOdd { get; set; }
        public List<PositionVM> Positions{ get; set; }
        public int UniversityId { get; set; }
        public int FacultiesId { get; set; }
    }
}