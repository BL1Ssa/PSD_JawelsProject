using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jawels_project_2.Factory
{
    public class TransactionDetailFactory
    {
        public TransactionDetail createTransactionDetail(int transactionId, int jewelId, int quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = transactionId;
            td.JewelID = jewelId;
            td.Quantity = quantity;

            return td;
        }
    }
}