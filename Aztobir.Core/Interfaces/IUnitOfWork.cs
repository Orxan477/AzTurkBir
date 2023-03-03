﻿using Aztobir.Core.İnterfaces.About;
using Aztobir.Core.İnterfaces.Home.FAQ;
using Aztobir.Core.İnterfaces.Home.Feedback;
using Aztobir.Core.İnterfaces.Home.News;
using Aztobir.Core.Interfaces.Home.News;
using Aztobir.Core.İnterfaces.Home.University;
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
        Task SaveChangesAsync();
    }
}
