using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;

namespace JAwelsDiamond_PSD_Project.Factory
{
    public class UserFactory
    {
        private UserRepository repo = new UserRepository();
        public MsUser Create(string email, string password, string name, string role, DateTime dob)
        {
            int id = repo.GetLastId();
            return new MsUser
            {
                UserID = id,
                UserEmail = email,
                UserPassword = password,
                UserName = name,
                UserDOB = dob,
                UserRole = role
            };
        }
    }
}