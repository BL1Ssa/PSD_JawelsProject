using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Controller
{
	public class OrderController
	{
		OrderHandler handler = new OrderHandler();

		public bool confirmPackage(int id)
		{
			bool exists = handler.transactionExists(id);
			if (exists)
			{
				handler.confirmPackage(id);
				return true;
			}
			return false;
		}

        public bool rejectPackage(int id)
        {
            bool exists = handler.transactionExists(id);
            if (exists)
            {
                handler.rejectPackage(id);
                return true;
            }
            return false;
        }

		public List<TransactionHeader> getAllTransaction(int id)
		{
			return handler.getAllTransactions(id);
		}

    }
}