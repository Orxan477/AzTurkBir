using AutoMapper;
using Aztobir.Business.ViewModels.About;
using Aztobir.Business.ViewModels.Home.City;
using Aztobir.Business.ViewModels.Home.Contact;
using Aztobir.Business.ViewModels.Home.FAQ;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Business.ViewModels.Home.News;
using Aztobir.Business.ViewModels.Home.Position;
using Aztobir.Business.ViewModels.Home.University;
using Aztobir.Business.ViewModels.Setting;
using Aztobir.Business.ViewModels.Team;
using Aztobir.Business.ViewModels.University;
using Aztobir.Core.Models;

namespace Aztobir.Business.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Goal, GoalVM>();
            CreateMap<GoalCreateVM, Goal>();
            CreateMap<About, AboutVM>();
            CreateMap<University, UniversityVM>().ForMember(x=>x.City,m=>m.MapFrom(o=>o.City.Name));
            CreateMap<UniversityVM, University>().ForMember(x=>x.CityId,m=>m.MapFrom(o=>o.City));
            CreateMap<CreateUniversityVM, University>();
            CreateMap<Faculty, FacultiesVM>();
            CreateMap<CreatePositionVM, Position>();
            CreateMap<UniversityImages, UniPhotosVM>();
            CreateMap<FAQ, FAQVM>();
            CreateMap<City, CityVM>();
            CreateMap<Position, PositionVM>();
            CreateMap<CreateFAQVM, FAQ>();
            CreateMap<CityCreateVM, City>();
            CreateMap<News, NewsVM>();
            CreateMap<Setting, SettingListVM>();
            CreateMap<News, NewsVM>();
            CreateMap<CreateContactVM, Contact>();
            CreateMap<Contact, ContactVM>();
            CreateMap<UniversityFormVM, UniversityForm>();
            CreateMap<UniversityForm, UniversityViewFormVM>();
            CreateMap<NewsVM, News>();
            CreateMap<CreateNewsVM, News>();
            CreateMap<Feedback, FeedbackVM>().ForMember(x=>x.ImageView,m=>m.MapFrom(o=>o.University.Image)).ForMember(x=>x.University,m=>m.MapFrom(o=>o.University.Name));
            CreateMap<CreateFeedbackVM, Feedback    >();
            CreateMap<Team, TeamVM>().ForMember(x => x.Position, m => m.MapFrom(o => o.Position.Name));
            CreateMap<Team, TeamDetailVM>().ForMember(x => x.Position, m => m.MapFrom(o => o.Position.Name));
            CreateMap<CreateTeamVM, Team>();
        }
    }
}
