using JAwelsDiamond_PSD_Project.Repository;
using JAwelsDiamond_PSD_Project.Models;

public class userHandler
{
    private UserRepository repo = new UserRepository();

    public MsUser Login(string email, string password, out string errorMessage)
    {
        return repo.Login(email, password, out errorMessage);
    }

    public MsUser GetUserById(string userId)
    {
        return repo.GetUserById(userId);
    }
}