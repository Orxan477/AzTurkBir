using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.İnterfaces.Home.FAQ;
using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Core.İnterfaces.Home.University;

namespace Aztobir.Core.İnterfaces
{
    public interface IUnitOfWork
    {
        public IAboutGetRepository AboutGetRepository { get; }
        public IGoalGetRepository GoalGetRepository { get;  }
        public IUniversityGetRepository UniversityGetRepository { get;  }
        public IGetFacultiesRepository GetFacultiesRepository { get;  }
        public IFAQGetRepository FAQGetRepository { get;  }
        public IGetNewsRepository GetNewsRepository { get;  }
        Task SaveChangesAsync();
    }
}
