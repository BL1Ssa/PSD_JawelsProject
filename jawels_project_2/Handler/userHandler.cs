using jawels_project_2.Models;
using jawels_project_2.Factory;
using jawels_project_2.Repository;
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

    //public bool RegisterUser(string email, string username, string password, string gender, DateTime dob)
    //{
    //    if (repo.EmailExists(email)) return false;
    //    var user = UserFactory.CreateUser(email, username, password, gender, dob);
    //    repo.AddUser(user);
    //    return true;
    //}

    public bool ValidateOldPassword(string userId, string oldPassword)
    {
        var user = repo.GetUserById(userId);
        return user != null && user.UserPassword == oldPassword;
    }

    public void ChangePassword(int userId, string newPassword)
    {
        repo.UpdateUserPassword(userId, newPassword);
    }



    public void register(string email, string username, string password, DateTime dob, string gender)
    {
        int userId = repo.GetLastId();
        MsUser user = userFactory.CreateUser(userId, email, username, password, gender, dob, "customer");

        repo.addUser(user);
    }

    public bool userExists(string email)
    {
        if (repo.GetUserByEmail(email) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}