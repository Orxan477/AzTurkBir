using Aztobir.Business.ViewModels.About;

namespace Aztobir.Business.Interfaces.About
{
    public interface IAboutService
    {
        Task<AboutVM> Get();
        Task<string> Update(AboutVM about,string env);

    }
}
