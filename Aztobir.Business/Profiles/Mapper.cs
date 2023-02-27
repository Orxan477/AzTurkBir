using AutoMapper;
using Aztobir.Business.ViewModels.About;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Core.Models;

namespace Aztobir.Business.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Goal, GoalVM>();
            CreateMap<About, AboutVM>();
            CreateMap<University, UniversityVM>().ForMember(x=>x.City,m=>m.MapFrom(o=>o.City.Name));
            CreateMap<Faculty, FacultiesVM>();
        }
    }
}
