using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DataModels;

namespace UserManagement.Application.Services
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> AddAsync(UserProfileDto entity);
        Task<UserProfileDto> GetByIdAsync(int id);
        Task Update(UserProfileDto entity);
        Task Delete(int userProfileId);
    }
}
