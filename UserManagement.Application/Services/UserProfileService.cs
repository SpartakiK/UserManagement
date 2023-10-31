using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DataModels;
using UserManagement.Domain.Entities;
using UserManagement.Domain.IRepositories;

namespace UserManagement.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserProfileDto> AddAsync(UserProfileDto userProfileDto)
        {
            UserProfile userProfile = UserProfile.CreateNew
                (
                userProfileDto.UserId,
                userProfileDto.FirstName,
                userProfileDto.LastName,
                userProfileDto.PersonalNumber
                );
            await _userProfileRepository.AddAsync(userProfile);
            await _userProfileRepository.SaveChangesAsync();
            return GetUserProfileToUserProfileDto(userProfile);
        }

        public async Task Delete(int userProfileId)
        {
            UserProfile userProfile = await _userProfileRepository.GetByIdAsync(userProfileId);
            _userProfileRepository.Delete(userProfile);
            await _userProfileRepository.SaveChangesAsync();
        }

        public async Task<UserProfileDto> GetByIdAsync(int userId)
        {
            UserProfile userProfile = await _userProfileRepository.GetByIdAsync(userId);
            return GetUserProfileToUserProfileDto(userProfile);
        }

        public async Task Update(UserProfileDto userProfileDto)
        {
            UserProfile userProfile = await _userProfileRepository.GetByIdAsync(userProfileDto.Id);
            userProfile.UpdateData(userProfileDto.FirstName,userProfile.LastName,userProfileDto.PersonalNumber);

            _userProfileRepository.Update(userProfile);
            await _userProfileRepository.SaveChangesAsync();
        }

        public UserProfileDto GetUserProfileToUserProfileDto(UserProfile useProfile)
        {
            UserProfileDto userProfileDto = new UserProfileDto
            {
                Id = useProfile.Id,
                UserId = useProfile.UserId,
                FirstName = useProfile.FirstName,
                LastName = useProfile.LastName,
                PersonalNumber = useProfile.PersonalNumber
            };
            return userProfileDto;
        }
    }
}
 