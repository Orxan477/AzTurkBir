using Aztobir.Business.Interfaces.About;
using Aztobir.Business.Interfaces.Account;
using Aztobir.Business.Interfaces.Home.FAQ;
using Aztobir.Business.Interfaces.Home.Feedback;
using Aztobir.Business.Interfaces.Home.News;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Business.Interfaces.Team;

namespace Aztobir.Business.Interfaces
{
    public interface IAztobirService
    {
        public IAboutService AboutService{ get;}
        public IGoalService GoalService{ get;}
        public IUniversityService UniversityService{ get;}
        public IFAQService FAQService{ get;}
        public INewsService NewsService{ get;}
        public IFeedbackService FeedbackService{ get;}
        public IAccountService AccountService{ get;}
        public ITeamService TeamService{ get;}
    }
}
