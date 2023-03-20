using AutoMapper;
using Aztobir.Business.Interfaces.Team;
using Aztobir.Business.Utilities;
using Aztobir.Business.ViewModels;
using Aztobir.Business.ViewModels.Team;
using Aztobir.Core.İnterfaces;
using Microsoft.AspNetCore.Http;

namespace Aztobir.Business.Implementations.Team
{
    public class TeamService : ITeamService
    {
        private string _errorMessage;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Create(CreateTeamVM team, string env, int size)
        {
            var newTeam = _mapper.Map<Core.Models.Team>(team);
            if (!CheckImageValid(team.Photo, "image/", size))
            {
                return _errorMessage;
            }
            string image = await Extension.SaveFileAsync(team.Photo, env, "assets/img");
            newTeam.Image = image;
            newTeam.CreatedAt = DateTime.Now;
            await _unitOfWork.TeamCRUDRepository.CreateAsync(newTeam);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        public async Task<string> Update(int id, UpdateTeamVM team, string env, int size)
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.Get(x => !x.IsDeleted && x.Id == id, "Position");
            if (dbTeam is null) throw new Exception("NotFound");
            if (team.FullName != null)
            {
                if (dbTeam.FullName.ToLower().Trim() != team.FullName.ToLower().Trim())
                {
                    dbTeam.FullName = team.FullName;
                }
            }
            if (team.Content != null)
            {
                if (dbTeam.Content.ToLower().Trim() != team.Content.ToLower().Trim())
                {
                    dbTeam.Content = team.Content;
                }
            }
            if (team.Email != null)
            {

                if (dbTeam.Email.ToLower().Trim() != team.Email.ToLower().Trim())
                {
                    dbTeam.Email = team.Email;
                }
            }
            if (team.Phone != null)
            {

                if (dbTeam.Phone.ToLower().Trim() != team.Phone.ToLower().Trim())
                {
                    dbTeam.Phone = team.Phone;
                }
            }
            if (dbTeam.PositionId != team.PositionId)
            {
                dbTeam.PositionId = team.PositionId;
            }
            if (team.Facebook != null)
            {
                if (dbTeam.Facebook.ToLower().Trim() != team.Facebook.ToLower().Trim())
                {
                    dbTeam.Facebook = team.Facebook;
                }
            }
            if (team.Twitter != null)
            {
                if (dbTeam.Twitter.ToLower().Trim() != team.Twitter.ToLower().Trim())
                {
                    dbTeam.Twitter = team.Twitter;
                }
            }
            if (team.Linkedin != null)
            {
                if (dbTeam.Linkedin.ToLower().Trim() != team.Linkedin.ToLower().Trim())
                {
                    dbTeam.Linkedin = team.Linkedin;
                }
            }
            if (team.Photo != null)
            {
                if (!CheckImageValid(team.Photo, "image/", size))
                {
                    return _errorMessage;
                }
                else
                {
                    string image = await Extension.SaveFileAsync(team.Photo, env, "assets/img");
                    dbTeam.Image = image;
                }
            }
            dbTeam.UpdatedAt = DateTime.Now;
            _unitOfWork.TeamCRUDRepository.UpdateAsync(dbTeam);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
        public async Task Delete(int id)
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.Get(x => !x.IsDeleted && x.Id == id, "Position");
            if (dbTeam is null) throw new Exception("Not Found");
            dbTeam.IsDeleted = true;
            _unitOfWork.TeamCRUDRepository.DeleteAsync(dbTeam);
            await _unitOfWork.SaveChangesAsync();
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
        public async Task<TeamDetailVM> Get(int id)
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.Get(x => !x.IsDeleted && x.Id == id, "Position");
            if (dbTeam is null) throw new Exception("NotFound");
            TeamDetailVM teams = _mapper.Map<TeamDetailVM>(dbTeam);
            return teams;
        }
        public async Task<UpdateTeamVM> GetUpdate(int id)
        {
            var dbCity = await _unitOfWork.TeamGetRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (dbCity is null) throw new Exception("Not Found");
            var city = _mapper.Map<UpdateTeamVM>(dbCity);
            return city;
        }
        public async Task<List<TeamVM>> GetAll()
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.GetAll(x => !x.IsDeleted, x => x.Id, "Position");
            List<TeamVM> teams = _mapper.Map<List<TeamVM>>(dbTeam);
            return teams;
        }

        public async Task<Paginate<TeamVM>> GetPaginete(int page, int take)
        {
            var model = await _unitOfWork.TeamGetRepository.GetPaginateProducts(x => !x.IsDeleted, x => x.Id, page, take);

            var productsVM = GetProductList(model);
            var dbForm = await _unitOfWork.TeamGetRepository.GetAll(x => !x.IsDeleted, x => x.Id);
            int pageCount = GetPageCount(take, dbForm);
            return new Paginate<TeamVM>(productsVM, page, pageCount);
        }
        private int GetPageCount(int take, List<Core.Models.Team> contacts)
        {
            var prodCount = contacts.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<TeamVM> GetProductList(List<Core.Models.Team> contact)
        {
            List<TeamVM> model = new List<TeamVM>();
            foreach (var item in contact)
            {
                TeamVM feedback = _mapper.Map<TeamVM>(item);
                model.Add(feedback);
            }
            return model;
        }
    }
}
