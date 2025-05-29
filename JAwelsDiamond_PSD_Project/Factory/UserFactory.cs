using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Factory
{
    public class UserFactory
    {
        public static MsUser Create(string email, string password, string name, string role)
        {
            return new MsUser
            {
                UserEmail = email,
                UserPassword = password,
                UserName = name,
                UserRole = role
            };
        }
    }
}