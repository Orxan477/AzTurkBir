using Aztobir.Business.ViewModels.Home.University;

namespace Aztobir.Business.Interfaces.Home.University
{
    public interface IUniversityPhotoService
    {
        Task<string> Create(int id,CreateUniPhotosVM photos, string env);
        Task<string> Update(int id, UpdateUniversityPhotosVM photos, string env);
        Task Delete(int id);
        Task<UpdateUniversityPhotosVM> GetPhoto(int id);
    }
}
