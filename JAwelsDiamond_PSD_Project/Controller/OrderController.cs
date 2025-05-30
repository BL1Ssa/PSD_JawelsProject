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
        private orderhandler _handler = new orderhandler();

        public IEnumerable<object> GetPendingOrders()
        {
            return _handler.GetPendingOrders();
        }

        public void ChangeOrderStatus(int transactionId, string command)
        {
            _handler.ChangeOrderStatus(transactionId, command);
        }
    public class OrderController
    {
        private orderhandler _handler = new orderhandler();

        public IEnumerable<object> GetPendingOrders()
        {
            return _handler.GetPendingOrders();
        }

        public void ChangeOrderStatus(int transactionId, string command)
        {
            _handler.ChangeOrderStatus(transactionId, command);
        }
    }
	public class OrderController
	{
        OrderHandler handler = new OrderHandler();

		public void confirmPackage(int id)
		{
			bool exists = handler.transactionExists(id);
			if (exists)
			{
				handler.confirmPackage(id);
			}
		}

        public void rejectPackage(int id)
        {
            bool exists = handler.transactionExists(id);
            if (exists)
            {
                handler.rejectPackage(id);
            }
        }

		public List<TransactionHeader> getAllTransaction(int id)
		{
			return handler.getAllTransactions(id);
		}

		public TransactionDetail getTransactionDetail(int transactionId)
		{
			return handler.getTransactionDetail(transactionId);
		}

    }
}