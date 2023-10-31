using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core;

namespace UserManagement.Domain.Entities
{
    public class UserProfile : Entity
    {
        public UserProfile(int userId, string firstName, string lastName, string personalNumber)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            DateOfCreation = DateTime.Now;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        public static UserProfile CreateNew(int userId, string firstName, string lastName, string personalNumber)
        {
            UserProfile userProfile = new UserProfile(userId, firstName, lastName, personalNumber);
            return userProfile;
        }
        public void UpdateData(string firstName, string lastName, string personalNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
        }
    }
}
