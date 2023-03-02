using AutoMapper;
using Aztobir.Business.ViewModels.About;
using Aztobir.Business.ViewModels.Home.FAQ;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.Team;
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
            CreateMap<FAQ, FAQVM>();
            CreateMap<News, NewsVM>();
            CreateMap<Feedback, FeedbackVM>().ForMember(x=>x.Image,m=>m.MapFrom(o=>o.University.Image));
            CreateMap<Team, TeamVM>().ForMember(x => x.Position, m => m.MapFrom(o => o.Position.Name));
            CreateMap<Team, TeamDetailVM>().ForMember(x => x.Position, m => m.MapFrom(o => o.Position.Name));
        }
    }
}
