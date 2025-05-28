using JAwelsDiamond_PSD_Project.Models;
using System.Linq;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class UserRepository
    {
        public MsUser GetUserByEmail(string email)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsUsers.FirstOrDefault(u => u.UserEmail == email);
            }
        }

        public MsUser GetUserById(string userId)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsUsers.FirstOrDefault(u => u.UserID.ToString() == userId);
            }
        }

        public void AddUser(MsUser user)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                db.MsUsers.Add(user);
                db.SaveChanges();
            }
        }

        public bool RemoveUser(MsUser user)
        {
            using (var db = new JawelsdatabaseEntities2())
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
        }

        public bool UpdateUser(MsUser newUser)
        {
            using (var db = new JawelsdatabaseEntities2())
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
        }

        public bool FindUser(int id)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsUsers.Any(u => u.UserID == id);
            }
        }

        public int GetLastId()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                var lastUser = db.MsUsers.OrderByDescending(u => u.UserID).FirstOrDefault();
                return lastUser == null ? 1 : lastUser.UserID + 1;
            }
        }
    }
}