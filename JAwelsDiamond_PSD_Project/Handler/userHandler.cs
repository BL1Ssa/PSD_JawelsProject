using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;

namespace JAwelsDiamond_PSD_Project.Handler
{
    public class userHandler
    {
        private UserRepository repo = new UserRepository();

        public MsUser Login(string email, string password)
        {
            var user = repo.GetUserByEmail(email);
            if (user != null && user.UserPassword == password)
            {
                return user;
            }
            return null;
        }

        public MsUser GetUserById(string userId)
        {
            return repo.GetUserById(userId);
        }

        
    }
}