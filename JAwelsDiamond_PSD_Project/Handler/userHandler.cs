using JAwelsDiamond_PSD_Project.Factory;
using JAwelsDiamond_PSD_Project.Models;
<<<<<<< HEAD
using JAwelsDiamond_PSD_Project.Repository;
using System;
=======
using System;
using JAwelsDiamond_PSD_Project.Factory;
>>>>>>> alvin

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

<<<<<<< HEAD
    public (bool IsSuccess, string ErrorMessage) RegisterUser(string email, string username, string password, string gender, DateTime dob)
    {
        var repo = new UserRepository();
        if (repo.IsEmailExists(email))
            return (false, "Email already registered.");

        var user = UserFactory.CreateUser(email, username, password, gender, dob, "customer");
        repo.AddUser(user);
        return (true, null);
    }
=======
    public void register(string email, string username, string password, DateTime dob, string gender)
    {
        MsUser user = userFactory.Create(email, password, username, "customer", dob);
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
>>>>>>> alvin
}