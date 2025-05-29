using JAwelsDiamond_PSD_Project.Factory;
using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;
using System.EnterpriseServices;

public class userHandler
{
    private UserRepository repo = new UserRepository();
    private UserFactory userFactory = new UserFactory();

    public MsUser Login(string email, string password, out string errorMessage)
    {
        return repo.Login(email, password, out errorMessage);
    }

    public MsUser GetUserById(string userId)
    {
        return repo.GetUserById(userId);
    }

    public void register(string email, string username, string password, DateTime dob, string gender)
    {
        int userId = repo.GetLastId();
        MsUser user = userFactory.Create(userId, email, password, username, "customer", dob);
        repo.AddUser(user);
    }

    public bool userExists(string email)
    {
        if(repo.GetUserByEmail(email) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 
}