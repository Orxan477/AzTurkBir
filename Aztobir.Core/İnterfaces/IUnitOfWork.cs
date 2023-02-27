using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.İnterfaces.Home.University;

namespace Aztobir.Core.İnterfaces
{
    public interface IUnitOfWork
    {
        public IAboutGetRepository AboutGetRepository { get; }
        public IGoalGetRepository GoalGetRepository { get;  }
        public IUniversityGetRepository UniversityGetRepository { get;  }
        Task SaveChangesAsync();
    }
}
