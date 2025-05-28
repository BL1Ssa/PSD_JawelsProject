using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Controller
{
    public class UserController
    {
        private userHandler handler = new userHandler();

        public MsUser Login(string email, string password, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "Email is required.";
                return null;
            }
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password is required.";
                return null;
            }

            var user = handler.Login(email, password);
            if (user == null)
            {
                errorMessage = "Incorrect email or password.";
            }
            return user;
        }

        public MsUser GetUserById(string userId)
        {
            return handler.GetUserById(userId);
        }
    }
}