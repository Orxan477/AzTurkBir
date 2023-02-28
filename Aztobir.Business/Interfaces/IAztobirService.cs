using Aztobir.Business.Interfaces.About;
using Aztobir.Business.Interfaces.Home.FAQ;
using Aztobir.Business.Interfaces.Home.News;
using Aztobir.Business.Interfaces.Home.University;

namespace Aztobir.Business.Interfaces
{
    public interface IAztobirService
    {
        public IAboutService AboutService{ get;}
        public IGoalService GoalService{ get;}
        public IUniversityService UniversityService{ get;}
        public IFAQService FAQService{ get;}
        public INewsService NewsService{ get;}
    }
}
