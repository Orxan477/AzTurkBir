﻿using AutoMapper;
using Aztobir.Business.Implementations.About;
using Aztobir.Business.Implementations.Home.University;
using Aztobir.Business.Interfaces;
using Aztobir.Business.Interfaces.About;
using Aztobir.Business.Interfaces.Home.University;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations
{
    public class AztobirService : IAztobirService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public AboutService _aboutService;
        public GoalService _goalService;
        public UniversityService _universityService;
        public AztobirService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IAboutService AboutService => _aboutService ?? new AboutService(_unitOfWork, _mapper);

        public IGoalService GoalService => _goalService ?? new GoalService(_unitOfWork, _mapper);

        public IUniversityService UniversityService => _universityService ?? new UniversityService(_unitOfWork, _mapper);
    }
}
