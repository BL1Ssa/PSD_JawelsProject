/*using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Factory
{
    public class UserFactory
    {
        public MsUser createUser(string name, string password, string email, DateTime dob, string gender, string role )
        {
            int id = repo.getLastId();
            MsUser user = new MsUser();
            user.UserID = id;
            user.UserName = name;
            user.UserGender = gender;
            user.UserDOB = dob;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserRole = role;

            return user;
        }

    }
}*/