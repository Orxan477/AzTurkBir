using AutoMapper;
using Aztobir.Business.Interfaces.Team;
using Aztobir.Business.Utilities;
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
        public TeamService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Create(CreateTeamVM team, string env)
        {
            var newTeam = _mapper.Map<Core.Models.Team>(team);
            if (!CheckImageValid(team.Photo, "image/", 200))
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
        public async Task<string> Update(int id, TeamVM team, string env)
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.Get(x => !x.IsDeleted && x.Id == id, "Position");
            if (dbTeam is null) throw new Exception("NotFound");
            if (dbTeam.FullName.ToLower().Trim() != dbTeam.FullName.ToLower().Trim())
            {
                dbTeam.FullName = dbTeam.FullName;
            }
            if (dbTeam.Content.ToLower().Trim() != dbTeam.Content.ToLower().Trim())
            {
                dbTeam.Content = dbTeam.Content;
            }
            if (dbTeam.Email.ToLower().Trim() != dbTeam.Email.ToLower().Trim())
            {
                dbTeam.Email = dbTeam.Email;
            }
            if (dbTeam.Phone.ToLower().Trim() != dbTeam.Phone.ToLower().Trim())
            {
                dbTeam.Phone = dbTeam.Phone;
            }
            if (dbTeam.PositionId!= dbTeam.PositionId)
            {
                dbTeam.PositionId = dbTeam.PositionId;
            }
            if (dbTeam.Facebook.ToLower().Trim() != dbTeam.Facebook.ToLower().Trim())
            {
                dbTeam.Facebook = dbTeam.Facebook;
            }
            if (dbTeam.Twitter.ToLower().Trim() != dbTeam.Twitter.ToLower().Trim())
            {
                dbTeam.Twitter = dbTeam.Twitter;
            }
            if (dbTeam.Linkedin.ToLower().Trim() != dbTeam.Linkedin.ToLower().Trim())
            {
                dbTeam.Linkedin = dbTeam.Linkedin;
            }
            if (team.Photo != null)
            {
                if (!CheckImageValid(team.Photo, "image/", 200))
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

        public async Task<List<TeamVM>> GetAll()
        {
            var dbTeam = await _unitOfWork.TeamGetRepository.GetAll(x => !x.IsDeleted,"Position");
            List<TeamVM> teams = _mapper.Map<List<TeamVM>>(dbTeam);
            return teams;
        }

       
    }
}
