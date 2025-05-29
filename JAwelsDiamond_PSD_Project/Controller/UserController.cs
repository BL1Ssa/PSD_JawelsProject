using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Text.RegularExpressions;

namespace JAwelsDiamond_PSD_Project.Controller
{
    public class UserController
    {
        private userHandler handler = new userHandler();

        public MsUser Login(string email, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage = "Email is required.";
                return null;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password is required.";
                return null;
            }

            var user = handler.Login(email, password, out errorMessage);
            return user;
        }

        public MsUser GetUserById(string userId)
        {
            return handler.GetUserById(userId);
        }

        public (bool IsSuccess, string ErrorMessage) Register(string email, string username, string password, string gender, string dob)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "Invalid email format.");

            if (username.Length < 3 || username.Length > 25)
                return (false, "Username must be 3-25 characters.");

            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,20}$"))
                return (false, "Password must be 8-20 alphanumeric characters.");

            if (!DateTime.TryParse(dob, out DateTime parsedDob) || parsedDob >= new DateTime(2010, 1, 1))
                return (false, "Invalid date of birth.");

            var handler = new userHandler();
            return handler.RegisterUser(email, username, password, gender, parsedDob);
        }
    }
}