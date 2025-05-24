using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Handler
{
	public class userHandler
	{
		UserRepository repo = new UserRepository();
		public bool login(string email, string password)
		{
			MsUser user = repo.getUserByEmail(email);

            if (accountExist(email))
			{
				if(user.UserPassword == password)
				{
					return true;
				}
			}
			return false;
		}

		private bool accountExist(string email)
		{
            if (repo.getUserByEmail(email) != null)
            {
				return true;
            }
            return false;
        }
		public bool makeNewAccount(MsUser user)
		{
			string email = user.UserEmail;
			if (accountExist(email))
			{
				return false;
			}
			else
			{
				repo.addUser(user);
				return true;
			}
		}

		public MsUser getUserByEmail(string email)
		{
			return repo.getUserByEmail(email);
		}

		public void changePassword(string email, string newPassword)
		{
			MsUser user = getUserByEmail(email);
			user.UserPassword = newPassword;
			repo.setUser(email, user);
		}

		}

	}
}