using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class UserRepository
    {
        JawelsDatabaseEntities db = new JawelsDatabaseEntities();
        public MsUser getUserByEmail(string email)
        {
            MsUser user = (from u in db.MsUsers where u.UserEmail == email select u).FirstOrDefault();
            return user;
        }
        public MsUser getUserById(int UserId)
        {
            MsUser user = (from u in db.MsUsers where u.UserID == UserId select u).FirstOrDefault();
            return user;
        }
        public void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public bool removeUser(MsUser user) 
        {
            if (findUser(user.UserID))
            {
                db.MsUsers.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool updateUser(MsUser newUser)
        {
            MsUser existingUser = db.MsUsers.Find(newUser.UserID);
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
        public bool findUser(int id)
        {
            MsUser existingUser = (from u in db.MsUsers where u.UserID == id select u).FirstOrDefault();
            if(existingUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getLastId()
        {
            MsUser lastUser = (from u in db.MsUsers select u).LastOrDefault();
            if(lastUser == null)
            {
                return 1;
            }
            else
            {
                return lastUser.UserID + 1;
            }
        }
    }
}