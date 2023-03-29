using Aztobir.Business.ViewModels.Home.FAQ;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Business.ViewModels.Home.University;

namespace Aztobir.Business.ViewModels.Home
{
    public class HomeVM
    {
        public List<UniversityVM> Universities{ get; set; }
        public UniversityVM University{ get; set; }
        public List<FAQVM> FAQs{ get; set; }
        public FAQVM FAQ{ get; set; }
        public List<NewsVM> News{ get; set; }
        public List<FeedbackVM> Feedbacks{ get; set; }
        public FeedbackVM Feedback{ get; set; }
        public int FacultyCount { get; set; }
    }
}
