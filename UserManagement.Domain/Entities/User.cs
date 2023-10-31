using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {
        public User(string userName, string password, string email, bool isActive) 
        {
            UserName = userName;
            Password = password;
            Email = email;
            IsActive = isActive;
            DateOfCreation= DateTime.Now;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public static User CreateNew(string userName, string password, string email, bool isActive)
        {
            User user = new User(userName,password,email,isActive);
            return user;
        }

        public void UpdateData(string userName, string password, string email, bool isActive)
        {
            UserName = userName;
            Password = password;
            Email = email;
            IsActive = isActive;
        }
    }
}
