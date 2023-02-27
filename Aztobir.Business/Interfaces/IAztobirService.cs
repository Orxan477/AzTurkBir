using Aztobir.Business.Interfaces.About;

namespace Aztobir.Business.Interfaces
{
    public interface IAztobirService
    {
        public IAboutService AboutService{ get;}
        public IGoalService GoalService{ get;}
    }
}
