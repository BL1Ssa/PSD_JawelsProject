using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;

namespace JAwelsDiamond_PSD_Project.Factory
{
    public class UserFactory
    {
        public MsUser Create(int userId, string email, string password, string name, string role, DateTime dob)
        {
            return new MsUser
            {
                UserID = userId,
                UserEmail = email,
                UserPassword = password,
                UserName = name,
                UserDOB = dob,
                UserRole = role
            };
        }
    }
}