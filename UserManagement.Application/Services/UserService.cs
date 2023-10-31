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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            User user = User.CreateNew(userDto.UserName, userDto.Password, userDto.Email, userDto.IsActive);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return GetUserToUserDto(user);  
        }

        public async Task Delete(int userId)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            return GetUserToUserDto(user);
        }

        public async Task Update(UserDto userDto)
        {
            User user = await _userRepository.GetByIdAsync(userDto.Id);
            user.UpdateData(userDto.UserName,userDto.Password,userDto.Email,userDto.IsActive);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public UserDto GetUserToUserDto(User user) 
        {
            var userDto = new UserDto 
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive
            };
            return userDto;
        }
    }
}
