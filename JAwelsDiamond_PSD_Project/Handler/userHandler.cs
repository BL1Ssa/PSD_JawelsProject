using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 * ini user handler
 * fungsi: layer yang menjalankan logika bisnis mengenai user
 * alur: view -> controller -> *handler -> repository
 * 
 * functions
 * - Login: validasi email dan password
 * - Register: menambahkan user baru jika email belum terpakai
 * - Get user by email
 * - Ganti password
 */
namespace JAwelsDiamond_PSD_Project.Handler
{
	public class userHandler
	{
		UserRepository repo = new UserRepository();
		public bool login(string email, string password)
		{
			/*
			 * Fungsi: Melakukan proses login user.
			 * Input: email (string), password (string)
			 * Return: true jika akun ditemukan dan password cocok, false jika tidak cocok atau tidak ada akun
			 */
			MsUser user = getUserByEmail(email);
            if (user != null)
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
			repo.updateUser(user);
		}



	}
}