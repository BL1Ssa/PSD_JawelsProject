using jawels_project_2.Factory;
using System.Linq;
using System.Data.Entity.Core.Common.CommandTrees;
using jawels_project_2.Models;

namespace jawels_project_2.Repository
{
    public class UserRepository
    {
        JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3();
        public MsUser Login(string email, string password, out string errorMessage)
        {

            var user = db.MsUsers.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
            if (user != null)
            {
                errorMessage = null;
                return user;
            }
            errorMessage = "Invalid email or password.";
            return null;

        }

        public MsUser GetUserByEmail(string email)
        {


            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email);

        }

        public MsUser GetUserById(string userId)
        {

            int id;
            if (int.TryParse(userId, out id))
            {
                return db.MsUsers.FirstOrDefault(u => u.UserID == id);
            }
            return null;

        }
        public bool RemoveUser(MsUser user)
        {

            var existingUser = db.MsUsers.Find(user.UserID);
            if (existingUser != null)
            {
                db.MsUsers.Remove(existingUser);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool UpdateUser(MsUser newUser)
        {

            var existingUser = db.MsUsers.Find(newUser.UserID);
            if (existingUser == null)
            {
                return false;
            }
            else
            {
                existingUser.UserRole = newUser.UserRole;
                existingUser.UserGender = newUser.UserGender;
                existingUser.UserDOB = newUser.UserDOB;
                existingUser.UserPassword = newUser.UserPassword;
                existingUser.UserEmail = newUser.UserEmail;
                existingUser.UserName = newUser.UserName;

                db.SaveChanges();
                return true;
            }

        }

        public void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public bool FindUser(int id)
        {

            return db.MsUsers.Any(u => u.UserID == id);

        }

        public int GetLastId()
        {

            var lastUser = db.MsUsers.OrderByDescending(u => u.UserID).FirstOrDefault();
            return lastUser == null ? 1 : lastUser.UserID + 1;

        }

        public bool EmailExists(string email)
        {

            return db.MsUsers.Any(u => u.UserEmail == email);

        }

        public void UpdateUserPassword(int userId, string newPassword)
        {

            var user = db.MsUsers.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                user.UserPassword = newPassword;
                db.SaveChanges();
            }

        }
    }
}