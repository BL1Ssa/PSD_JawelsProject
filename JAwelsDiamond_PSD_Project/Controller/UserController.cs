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

        public bool ValidateEmail(string email) =>
            !string.IsNullOrWhiteSpace(email) && email.Contains("@");

        public bool ValidateUsername(string username) =>
            username.Length >= 3 && username.Length <= 25;

        public bool ValidatePassword(string password) =>
            Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,20}$");

        public bool ValidateDOB(string dobStr, out DateTime dob)
        {
            return DateTime.TryParse(dobStr, out dob) && dob < new DateTime(2010, 1, 1);
        }

        public bool Register(string email, string username, string password, string gender, string dobStr)
        {
            if (!ValidateEmail(email) || !ValidateUsername(username) || !ValidatePassword(password) || !ValidateDOB(dobStr, out DateTime dob))
                return false;
            return handler.RegisterUser(email, username, password, gender, dob);
        }

        public MsUser GetProfile(string userId)
        {
            return handler.GetUserById(userId);
        }

        public bool ValidateOldPassword(string userId, string oldPassword)
        {
            return handler.ValidateOldPassword(userId, oldPassword);
        }

        public bool ValidateNewPassword(string newPassword)
        {
            return Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]{8,25}$");
        }

        public void ChangePassword(int userId, string newPassword)
        {
            handler.ChangePassword(userId, newPassword);
        }
    }
}