using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jawels_project_2.Factory
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

    }
}