using Aztobir.Core.İnterfaces;
using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.Interfaces.About;
using Aztobir.Core.Interfaces.Home.City;
using Aztobir.Core.Interfaces.Home.Contact;
using Aztobir.Core.Interfaces.Home.FAQ;
using Aztobir.Core.İnterfaces.Home.FAQ;
using Aztobir.Core.Interfaces.Home.Feedback;
using Aztobir.Core.İnterfaces.Home.Feedback;
using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Core.Interfaces.Home.News;
using Aztobir.Core.Interfaces.Home.Position;
using Aztobir.Core.Interfaces.Home.University;
using Aztobir.Core.İnterfaces.Home.University;
using Aztobir.Core.Interfaces.Setting;
using Aztobir.Core.Interfaces.Team;
using Aztobir.Core.İnterfaces.Team;
using Aztobir.Data.DAL;
using Aztobir.Data.Implementations.About;
using Aztobir.Data.Implementations.Home.City;
using Aztobir.Data.Implementations.Home.Contact;
using Aztobir.Data.Implementations.Home.FAQ;
using Aztobir.Data.Implementations.Home.Feedback;
using Aztobir.Data.Implementations.Home.News;
using Aztobir.Data.Implementations.Home.Position;
using Aztobir.Data.Implementations.Home.University;
using Aztobir.Data.Implementations.Setting;
using Aztobir.Data.Implementations.Team;

namespace Aztobir.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private AboutGetRepository _aboutGetrepository;
        private GoalGetRepository _goalGetrepository;
        private UniversityGetRepository _universityGetRepository;
        private GetFacultiesRepository _getFacultiesRepository;
        private FAQGetRepository _faqGetRepository;
        private GetNewsRepository _getNewsRepository;
        private FeedbackGetRepository _feedbackGetRepository;
        private TeamGetRepository _teamGetRepository;
        private CRUDNewsRepository _crudNewsRepository;
        private CRUDUniversityRepository _crudUniversityRepository;
        private TeamCRUDRepository _teamCRUDRepository;
        private FaqCRUDRepository _faqCRUDRepository;
        private FeedbackCRUDRepository _feedbackCRUDRepository;
        private UniversityPhotosGetRepository _universityPhotosGetRepository;
        private GoalCRUDRepository _goalCRUDRepository;
        private AboutCRUDRepository _aboutCRUDRepository;
        private CityGetRepository _cityGetRepository;
        private CityCRUDRepository _cityCRUDRepository;
        private PositionCRUDRepository _positionCRUDRepository;
        private PositionGetRepository _positionGetRepository;
        private UniversityPhotosCRUDRepository _universityImagesCRUDRepository;
        private SettingRepository _settingRepository;
        private SettingCRUDRepository _settingCRUDRepository;
        private GetUnivertsityFormRepository _getUnivertsityFormRepository;
        private CRUDUnivertsityFormRepository _cRUDUnivertsityFormRepository;
        private ContactCRUDRepository _contactCRUDRepository;
        private ContactGetRepository _contactGetRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IAboutGetRepository AboutGetRepository => _aboutGetrepository ?? new AboutGetRepository(_context);
        public IGoalGetRepository GoalGetRepository => _goalGetrepository ?? new GoalGetRepository(_context);

        public IUniversityGetRepository UniversityGetRepository => _universityGetRepository ?? new UniversityGetRepository(_context);

        public IGetFacultiesRepository GetFacultiesRepository => _getFacultiesRepository ?? new GetFacultiesRepository(_context);

        public IFAQGetRepository FAQGetRepository => _faqGetRepository ?? new FAQGetRepository(_context);

        public IGetNewsRepository GetNewsRepository => _getNewsRepository ?? new GetNewsRepository(_context);

        public IFeedbackGetRepository FeedbackGetRepository => _feedbackGetRepository ?? new FeedbackGetRepository(_context);

        public ITeamGetRepository TeamGetRepository => _teamGetRepository ?? new TeamGetRepository(_context);

        public ICRUDNewsRepository CRUDNewsRepository =>  _crudNewsRepository ?? new CRUDNewsRepository(_context);

        public ICRUDUniversityRepository CRUDUniversityRepository => _crudUniversityRepository ?? new CRUDUniversityRepository(_context);

        public ITeamCRUDRepository TeamCRUDRepository => _teamCRUDRepository ?? new TeamCRUDRepository(_context);

        public IFaqCRUDRepository FaqCRUDRepository => _faqCRUDRepository ?? new FaqCRUDRepository(_context);

        public IFeedbackCRUDRepository FeedbackCRUDRepository => _feedbackCRUDRepository ?? new FeedbackCRUDRepository(_context);

        public IUniversityPhotosGetRepository UniversityPhotosGetRepository => _universityPhotosGetRepository ?? new UniversityPhotosGetRepository(_context);

        public IGoalCRUDRepository GoalCRUDRepository => _goalCRUDRepository ?? new GoalCRUDRepository(_context);

        public IAboutCRUDRepository AboutCRUDRepository => _aboutCRUDRepository ?? new AboutCRUDRepository(_context);

        public ICityGetRepository CityGetRepository => _cityGetRepository ?? new CityGetRepository(_context);

        public ICityCRUDRepository CityCRUDRepository => _cityCRUDRepository ?? new CityCRUDRepository(_context);

        public IPositionCRUDRepository PositionCRUDRepository => _positionCRUDRepository ?? new PositionCRUDRepository(_context);

        public IPositionGetRepository PositionGetRepository => _positionGetRepository ?? new PositionGetRepository(_context);

        public IUniversityPhotosCRUDRepository UniversityImagesCURDRepository => _universityImagesCRUDRepository ?? new UniversityPhotosCRUDRepository(_context);

        public ISettingRepository SettingRepository => _settingRepository ?? new SettingRepository(_context);

        public ISettingCRUDRepository SettingCRUDRepository => _settingCRUDRepository ?? new SettingCRUDRepository(_context);

        public IGetUniversityFormRepository GetUniversityFormRepository => _getUnivertsityFormRepository ?? new GetUnivertsityFormRepository(_context);

        public ICRUDUnivertsityFormRepository CRUDUniversityFormRepository => _cRUDUnivertsityFormRepository ?? new CRUDUnivertsityFormRepository(_context);

        public IContactGetRepository ContactGetRepositorys => _contactGetRepository ?? new ContactGetRepository(_context);

        public IContactCRUDRepository ContactCRUDRepositorys => _contactCRUDRepository ?? new ContactCRUDRepository(_context);

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
