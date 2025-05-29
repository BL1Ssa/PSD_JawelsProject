using jawelsdiamond_psd_project.handler;
using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Controller
{
	public class OrderController
	{
        orderhandler handler = new orderhandler();

		public void confirmPackage(int id)
		{
			bool exists = handler.transactionexists(id);
			if (exists)
			{
				handler.confirmPackage(id);
			}
		}

        public void rejectPackage(int id)
        {
            bool exists = handler.transactionexists(id);
            if (exists)
            {
                handler.rejectPackage(id);
            }
        }

		public List<TransactionHeader> getAllTransaction(int id)
		{
			return handler.getalltransactions(id);
		}

		public TransactionDetail getTransactionDetail(int transactionId)
		{
			return handler.getTransactionDetail(transactionId);
		}

    }
}