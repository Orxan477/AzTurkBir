using Aztobir.Business.ViewModels.Home.FAQ;
using Aztobir.Business.ViewModels.Home.University;

namespace Aztobir.Business.ViewModels.Home
{
    public class HomeVM
    {
        public List<UniversityVM> Universities{ get; set; }
        public UniversityVM University{ get; set; }
        public List<FAQVM> FAQs{ get; set; }
    }
}
