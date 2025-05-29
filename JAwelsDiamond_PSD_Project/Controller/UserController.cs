using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Models;
using System;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> alvin
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

<<<<<<< HEAD
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
=======
        public string Register(string email, string username, string password, string confrimPass, string gender, DateTime dob)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (handler.userExists(email))
            {
                return "user with the same email already exist";
            }
            else if (Regex.IsMatch(email, emailPattern))
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
>>>>>>> alvin
        }
    }
}

