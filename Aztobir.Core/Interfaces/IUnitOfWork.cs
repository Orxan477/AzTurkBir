using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.Interfaces.About;
using Aztobir.Core.Interfaces.Home.City;
using Aztobir.Core.Interfaces.Home.Contact;
using Aztobir.Core.Interfaces.Home.Faculty;
using Aztobir.Core.Interfaces.Home.FAQ;
using Aztobir.Core.İnterfaces.Home.FAQ;
using Aztobir.Core.İnterfaces.Home.Feedback;
using Aztobir.Core.Interfaces.Home.Feedback;
using Aztobir.Core.Interfaces.Home.News;
using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Core.Interfaces.Home.Position;
using Aztobir.Core.İnterfaces.Home.University;
using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Core.Interfaces.Setting;
using Aztobir.Core.Interfaces.Team;
using Aztobir.Core.İnterfaces.Team;

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
        public IFeedbackGetRepository FeedbackGetRepository { get;  }
        public ITeamGetRepository TeamGetRepository { get;  }
        public ICRUDNewsRepository CRUDNewsRepository { get;  }
        public ICRUDUniversityRepository CRUDUniversityRepository { get;  }
        public ITeamCRUDRepository TeamCRUDRepository { get;  }
        public IFaqCRUDRepository FaqCRUDRepository { get;  }
        public IFeedbackCRUDRepository FeedbackCRUDRepository { get;  }
        public IUniversityPhotosGetRepository UniversityPhotosGetRepository { get;  }
        public IGoalCRUDRepository GoalCRUDRepository { get;  }
        public IAboutCRUDRepository AboutCRUDRepository { get;  }
        public ICityGetRepository CityGetRepository{ get;  }
        public ICityCRUDRepository CityCRUDRepository { get;  }
        public IPositionCRUDRepository PositionCRUDRepository { get;  }
        public IPositionGetRepository PositionGetRepository { get;  }
        public IUniversityPhotosCRUDRepository UniversityImagesCURDRepository { get;  }
        public ISettingRepository SettingRepository { get;  }
        public ISettingCRUDRepository SettingCRUDRepository { get;  }
        public IGetUniversityFormRepository GetUniversityFormRepository { get;  }
        public ICRUDUnivertsityFormRepository CRUDUniversityFormRepository { get;  }
        public IContactGetRepository ContactGetRepositorys { get;  }
        public IContactCRUDRepository ContactCRUDRepositorys { get;  }
        public IFacultyCRUDRepository FacultyCRUDRepository { get;  }
        public IFacultyGetRepository FacultyGetRepository { get;  }
        Task SaveChangesAsync();
    }
}
