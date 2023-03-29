using Aztobir.Core.İnterfaces;
using System.Linq.Expressions;

namespace Aztobir.Core.Interfaces.Home.Faculty
{
    public interface IFacultyUniversityGetRepository:IGetRepository<Core.Models.FacultyUniversity>
    {
        Task<List<Models.FacultyUniversity>> GetFacultiesUniversity(Expression<Func<Models.FacultyUniversity, bool>> exp = null, params string[] includes);
    }
}
