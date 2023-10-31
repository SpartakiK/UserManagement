using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Core;

namespace UserManagement.Domain.IRepositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {

    }
}
