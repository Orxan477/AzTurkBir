using Aztobir.Business.ViewModels.Home.City;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.Position;

namespace Aztobir.Business.ViewModels.Home.University
{
    public class UniversityViewVM
    {
        public UniversityVM University { get; set; }
        public List<UniversityVM> Universities { get; set; }
        public List<FacultiesVM> Faculties { get; set; }
        public List<UniPhotosVM> Photos { get; set; }
        public List<FeedbackVM> Feedbacks { get; set; }
        public List<CityVM> Cities{ get; set; }
        public CityVM City{ get; set; }
        public List<PositionVM> Positions{ get; set; }
    }
}