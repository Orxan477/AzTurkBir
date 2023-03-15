using AutoMapper;
using Aztobir.Business.Interfaces.Home.Feedback;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels.Home.Feedback;
using Aztobir.Core.İnterfaces;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.Home.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public FeedbackService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        public async Task<string> Create(CreateFeedbackVM feedback,string env,int size)
        {
            var newFeedback = _mapper.Map<Core.Models.Feedback>(feedback);
            if (!CheckImageValid(feedback.Photo, "image/", size))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(feedback.Photo, env, "assets/img");
            newFeedback.Image = image;
            newFeedback.CreatedAt = DateTime.Now;
            await _unitOfWork.FeedbackCRUDRepository.CreateAsync(newFeedback);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        public async Task<string> Update(int id, UpdateFeedbackVM feedback, string env,int size)
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.Get(x => !x.IsDeleted && x.Id == id);
            if (dbFeedback is null) throw new Exception("Not Found");
            if (feedback.FullName != null)
            {
                if (dbFeedback.FullName.ToLower().Trim() != feedback.FullName.ToLower().Trim())
                {
                    dbFeedback.FullName = feedback.FullName;
                }
            }
            if (feedback.Comment != null)
            {
                if (dbFeedback.Comment.ToLower().Trim() != feedback.Comment.ToLower().Trim())
                {
                    dbFeedback.Comment = feedback.Comment;
                }
            }
            if (feedback.Photo != null)
            {
                if (!CheckImageValid(feedback.Photo, "image/", size))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(feedback.Photo, env, "assets/img");
                    dbFeedback.Image = image;
                }
            }
            dbFeedback.UpdatedAt = DateTime.Now;
            _unitOfWork.FeedbackCRUDRepository.UpdateAsync(dbFeedback);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        private bool CheckImageValid(IFormFile file, string type, int size)
        {
            if (!Extension.CheckType(file, type))
            {
                _errorMessage = "The type is not correct";
                return false;
            }
            if (!Extension.CheckSize(file, size))
            {
                _errorMessage = $"The size of this photo is {size}";
                return false;
            }
            return true;
        }
        public async Task Delete(int id)
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.Get(x => !x.IsDeleted && x.Id == id, "University");
            if (dbFeedback is null) throw new Exception("Not Found");
            dbFeedback.IsDeleted = true;
            _unitOfWork.FeedbackCRUDRepository.DeleteAsync(dbFeedback);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<FeedbackVM> Get(int id)
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.Get(x => !x.IsDeleted && x.Id==id, "University");
            if (dbFeedback is null) throw new Exception("Not Found");
            FeedbackVM feedback = _mapper.Map<FeedbackVM>(dbFeedback);
            return feedback;
        }

        public async Task<List<FeedbackVM>> GetAll()
        {
            var dbFeedback = await _unitOfWork.FeedbackGetRepository.GetAll(x => !x.IsDeleted, "University");
            List<FeedbackVM> feedbacks = _mapper.Map<List<FeedbackVM>>(dbFeedback);
            return feedbacks;
        }

        
    }
}
