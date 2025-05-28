/*using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Handler
{
	public class OrderHandler
	{

		public bool confirmPackage(int id)
		{
			//TransactionHeader th = repo.getTransactionHeader(id);
			//th.TransactionStatus = "done";
			//bool response = repo.updateTransactionHeader(th);
			//return response;
		}

		public bool rejectPackage(int id)
		{
			*//*TransactionHeader th = repo.getTransactionHeader(id);
			th.TransactionStatus = "rejected";
			bool response = repo.updateTransactionHeader(th);
			return response;*//*
		}

		public bool transactionExists(int id)
		{
            TransactionHeader th = repo.getTransactionHeader(id);
			if(th == null)
			{
				return false;
			}
			return true;
        }

		public List<TransactionHeader> getAllTransactions(int userId)
		{
			List<TransactionHeader> allTh = repo.getAllTransactions(userId);
			return allTh;
		}
	}
}*/