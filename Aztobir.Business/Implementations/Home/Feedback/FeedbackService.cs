using AutoMapper;
using Aztobir.Business.Interfaces.Home.Feedback;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Core.İnterfaces;

namespace Aztobir.Business.Implementations.Home.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public FeedbackService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<FeedbackVM>> GetAll()
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.GetAll(x => !x.IsDeleted, "University");
            List<FeedbackVM> feedbacks = _mapper.Map<List<FeedbackVM>>(dbFeedback);
            return feedbacks;
        }
    }
}
