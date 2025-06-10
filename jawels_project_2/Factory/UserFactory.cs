using jawels_project_2.Models;
using System;

namespace jawels_project_2.Factory
{
    public class UserFactory
    {
        public MsUser CreateUser(int userId, string email, string username, string password, string gender, DateTime dob, string role)
        {
            return new MsUser
            {
                UserID = userId,
                UserEmail = email,
                UserName = username,
                UserPassword = password,
                UserGender = gender,
                UserDOB = dob,
                UserRole = role
            };
        }
    }
}