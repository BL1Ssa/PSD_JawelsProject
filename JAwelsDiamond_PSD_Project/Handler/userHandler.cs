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

    public (bool IsSuccess, string ErrorMessage) RegisterUser(string email, string username, string password, string gender, DateTime dob)
    {
        var repo = new UserRepository();
        if (repo.IsEmailExists(email))
            return (false, "Email already registered.");

        var user = UserFactory.CreateUser(email, username, password, gender, dob, "customer");
        repo.AddUser(user);
        return (true, null);
    }
}