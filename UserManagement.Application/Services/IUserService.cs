using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DataModels;
using UserManagement.Domain.Entities;
using UserManagement.Domain.IRepositories;
using UserManagement.Domain.Core;

namespace UserManagement.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserDto entity);
        Task<UserDto> GetByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task Update(UserDto entity);    
        Task Delete(int userId);
    }
}
