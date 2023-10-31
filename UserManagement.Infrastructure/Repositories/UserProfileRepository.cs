using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.IRepositories;
using UserManagement.Infrastructure.DbConnection;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        private readonly DbConnect _db;
        public UserProfileRepository(DbConnect db) : base(db)
        {
            _db = db;
        }
    }
}
