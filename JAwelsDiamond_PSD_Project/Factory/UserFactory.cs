using JAwelsDiamond_PSD_Project.Models;
using System;

namespace JAwelsDiamond_PSD_Project.Factory
{
    public class UserFactory
    {
        public static MsUser CreateUser(string email, string username, string password, string gender, DateTime dob, string role)
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