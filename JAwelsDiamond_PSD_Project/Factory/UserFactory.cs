using JAwelsDiamond_PSD_Project.Models;
<<<<<<< HEAD
=======
using JAwelsDiamond_PSD_Project.Repository;
>>>>>>> alvin
using System;

namespace JAwelsDiamond_PSD_Project.Factory
{
    public class UserFactory
    {
<<<<<<< HEAD
        public static MsUser CreateUser(string email, string username, string password, string gender, DateTime dob, string role)
=======
        private UserRepository repo = new UserRepository();
        public MsUser Create(string email, string password, string name, string role, DateTime dob)
>>>>>>> alvin
        {
            int id = repo.GetLastId();
            return new MsUser
            {
                UserID = id,
                UserEmail = email,
                UserName = username,
                UserPassword = password,
<<<<<<< HEAD
                UserGender = gender,
=======
                UserName = name,
>>>>>>> alvin
                UserDOB = dob,
                UserRole = role
            };
        }
    }
}