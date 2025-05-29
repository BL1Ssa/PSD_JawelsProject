/*using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Factory
{
	public class TransactionHeaderFactory
	{
		public TransactionHeader createTransactionHeader(int transactionId, int userId, DateTime transactionDate, string paymentMethod, string transactionStatus)
		{
			TransactionHeader th = new TransactionHeader();
			th.TransactionID = transactionId;
			th.UserID = userId;
			th.TransactionDate = transactionDate;
			th.PaymentMethod = paymentMethod;
			th.TransactionStatus = transactionStatus;

			return th;
		}

        public TransactionHeader createNewTransactionHeader(int userId, DateTime transactionDate, string paymentMethod, string transactionStatus)
        {
            int id = repo.getLastHeaderId();


            TransactionHeader th = new TransactionHeader();
            th.TransactionID = id;
            th.UserID = userId;
            th.TransactionDate = transactionDate;
            th.PaymentMethod = paymentMethod;
            th.TransactionStatus = transactionStatus;

            return th;
        }
    }
}*/