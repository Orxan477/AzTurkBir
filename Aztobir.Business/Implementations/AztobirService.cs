﻿using AutoMapper;
using Aztobir.Business.Implementations.About;
using Aztobir.Business.Implementations.Account;
using Aztobir.Business.Implementations.Home.FAQ;
using Aztobir.Business.Implementations.Home.Feedback;
using Aztobir.Business.Implementations.Home.News;
using Aztobir.Business.Implementations.Home.University;
using Aztobir.Business.Interfaces;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.Interfaces.Account;
using Aztobir.Business.Interfaces.Home.FAQ;
using Aztobir.Business.Interfaces.Home.Feedback;
using Aztobir.Business.Interfaces.Home.News;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Core.İnterfaces;
using Aztobir.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Aztobir.Business.Implementations
{
    public class AztobirService : IAztobirService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private SignInManager<AppUser> _signInManager;
        private AboutService _aboutService;
        private GoalService _goalService;
        private UniversityService _universityService;
        private FAQService _faqService;
        private NewsService _newsService;
        private FeedbackService _feedbackService;
        private AccountService _accountService;
        public AztobirService(IUnitOfWork unitOfWork,IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public IAboutService AboutService => _aboutService ?? new AboutService(_unitOfWork, _mapper);

        public IGoalService GoalService => _goalService ?? new GoalService(_unitOfWork, _mapper);

        public IUniversityService UniversityService => _universityService ?? new UniversityService(_unitOfWork, _mapper);

        public IFAQService FAQService => _faqService ?? new FAQService(_unitOfWork, _mapper);

        public INewsService NewsService => _newsService ?? new NewsService(_unitOfWork, _mapper);

        public IFeedbackService FeedbackService => _feedbackService ?? new FeedbackService(_unitOfWork, _mapper);

        public IAccountService AccountService => _accountService ?? new AccountService(_signInManager);
    }
}
