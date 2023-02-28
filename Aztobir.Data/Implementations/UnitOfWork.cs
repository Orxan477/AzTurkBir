﻿using Aztobir.Core.İnterfaces;
using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.İnterfaces.Home.FAQ;
using Aztobir.Core.İnterfaces.Home.Feedback;
using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Core.İnterfaces.Home.University;
using Aztobir.Data.DAL;
using Aztobir.Data.Implementations.About;
using Aztobir.Data.Implementations.Home.FAQ;
using Aztobir.Data.Implementations.Home.Feedback;
using Aztobir.Data.Implementations.Home.News;
using Aztobir.Data.Implementations.Home.University;

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

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
