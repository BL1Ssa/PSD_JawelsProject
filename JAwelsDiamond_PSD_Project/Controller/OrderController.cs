using jawelsdiamond_psd_project.handler;
using JAwelsDiamond_PSD_Project.Models;
using System.Collections.Generic;

namespace JAwelsDiamond_PSD_Project.Controller
{
	public class OrderController
	{
		orderhandler handler = new orderhandler();

		public bool confirmPackage(int id)
		{
			bool exists = handler.transactionexists(id);
			if (exists)
			{
				handler.confirmpackage(id);
				return true;
			}
			return false;
		}

        public bool rejectPackage(int id)
        {
            bool exists = handler.transactionexists(id);
            if (exists)
            {
                handler.rejectpackage(id);
                return true;
            }
            return false;
        }

		public List<TransactionHeader> getAllTransaction(int id)
		{
			return handler.getalltransactions(id);
		}

    }
}