using AutoMapper;
using Aztobir.Business.ViewModels.About;
using Aztobir.Core.Models;

namespace Aztobir.Business.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Goal, GoalVM>();
            CreateMap<About, AboutVM>();
        }
    }
}
