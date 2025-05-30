using JAwelsDiamond_PSD_Project.Factory;
using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;

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

    public bool RegisterUser(string email, string username, string password, string gender, DateTime dob)
    {
        if (repo.EmailExists(email)) return false;
        var user = UserFactory.CreateUser(email, username, password, gender, dob);
        repo.AddUser(user);
        return true;
    }
}