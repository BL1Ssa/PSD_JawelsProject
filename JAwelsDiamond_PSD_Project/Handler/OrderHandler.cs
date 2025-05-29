using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System.Collections.Generic;

namespace jawelsdiamond_psd_project.handler
{
	public class orderhandler
	{
		TransactionRepository repo = new TransactionRepository();
		public bool confirmpackage(int id)
		{
			TransactionHeader th = repo.getTransactionHeader(id);
			th.TransactionStatus = "done";
			bool response = repo.updateTransactionHeader(th);
			return response;
		}

		public bool rejectpackage(int id)
		{
			TransactionHeader th = repo.getTransactionHeader(id);
			th.TransactionStatus = "rejected";
			bool response = repo.updateTransactionHeader(th);
			return response;
		}

		public bool transactionexists(int id)
		{
            TransactionHeader th = repo.getTransactionHeader(id);
			if(th == null)
			{
				return false;
			}
			return true;
        }

		public List<TransactionHeader> getalltransactions(int userid)
		{
			List<TransactionHeader> allth = repo.getAllTransactions(userid);
			return allth;
		}
	}
}