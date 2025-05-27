using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Handler
{
	public class OrderHandler
	{
		TransactionRepository repo = new TransactionRepository();

		public bool confirmPackage(int id)
		{
			TransactionHeader th = repo.getTransactionHeader(id);
			th.TransactionStatus = "done";
			bool response = repo.updateTransactionHeader(th);
			return response;
		}

		public bool rejectPackage(int id)
		{
			TransactionHeader th = repo.getTransactionHeader(id);
			th.TransactionStatus = "rejected";
			bool response = repo.updateTransactionHeader(th);
			return response;
		}
	}
}