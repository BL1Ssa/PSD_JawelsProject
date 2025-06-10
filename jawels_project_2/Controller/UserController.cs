using jawels_project_2.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace jawels_project_2.Controller
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

        public string Register(string email, string username, string password, string confrimPass, string gender, DateTime dob)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.com$";

            if (email == "")
            {
                return "email must not be empty";
            }
            else if (username == "")
            {
                return "username must not be empty";
            }
            else if (handler.userExists(email))
            {
                return "user with the same email already exist";
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {
                return "email must be in the format of ...@<ProviderName>.com";
            }
            else if (username.Length < 3 || username.Length > 25)
            {
                return "username length must be between 3 - 25 characters long";
            }
            else if (!isAlphaNumeric(password))
            {
                return "password must be alphanumeric";
            }
            else if (password.Length < 8 || password.Length > 20)
            {
                return "password must be 8 - 20 characters long";
            }
            else if (confrimPass != password)
            {
                return "confirmed password must be the same as password";
            }
            else if (gender == "")
            {
                return "gender must be selected";
            }
            else if (dob == DateTime.MinValue)
            {
                return "date of birth must be picked";
            }
            else if (dob <= new DateTime(2001, 1, 1))
            {
                return "date of birth must be after 01/01/2001";
            }
            else
            {
                handler.register(email, username, password, dob, gender);
                return "register success";
            }

        }


        private bool isAlphaNumeric(string str)
        {
            bool alphabet = false;
            bool number = false;
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    alphabet = true;
                }
                if (char.IsNumber(c))
                {
                    number = true;
                }
            }

            return alphabet && number;
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

        //public bool Register(string email, string username, string password, string gender, string dobStr)
        //{
        //    if (!ValidateEmail(email) || !ValidateUsername(username) || !ValidatePassword(password) || !ValidateDOB(dobStr, out DateTime dob))
        //        return false;
        //    return handler.RegisterUser(email, username, password, gender, dob);
        //}

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