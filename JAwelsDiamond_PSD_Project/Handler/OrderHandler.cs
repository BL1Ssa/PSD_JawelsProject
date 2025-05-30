using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System.Collections.Generic;

namespace jawelsdiamond_psd_project.handler
{
	public class OrderHandler
	{
		TransactionRepository repo = new TransactionRepository();
        public void confirmPackage(int id)
        {
            TransactionHeader th = repo.getTransactionHeader(id);
            th.TransactionStatus = "done";
            bool response = repo.updateTransactionHeader(th);
        }

        public void rejectPackage(int id)
        {
            TransactionHeader th = repo.getTransactionHeader(id);
            th.TransactionStatus = "rejected";
            bool response = repo.updateTransactionHeader(th);
        }

        public bool transactionExists(int id)
        {
            TransactionHeader th = repo.getTransactionHeader(id);
            if (th == null)
            {
                return false;
            }
            return true;
        }

        public List<TransactionHeader> getAllTransactions(int userid)
        {
            List<TransactionHeader> allth = repo.getAllTransactions(userid);
            return allth;
        }

        public TransactionDetail getTransactionDetail(int transactionId)
        {
            TransactionDetail transactionDetail = repo.getTransactionDetail(transactionId);
            return transactionDetail;
        }


        // Stip Punya Handle Orders Methods
        public IEnumerable<object> GetPendingOrders()
        {
            return repo.GetPendingOrders();
        }

        public void ChangeOrderStatus(int transactionId, string command)
        {
            var order = repo.GetOrderById(transactionId);
            if (order == null) return;

            string status = order.TransactionStatus.ToLower();

            if (command == "ConfirmPayment" && status == "payment pending")
            {
                order.TransactionStatus = "shipment pending";
                repo.UpdateOrder(order);
            }
            else if (command == "ShipPackage" && status == "shipment pending")
            {
                order.TransactionStatus = "arrived";
                repo.UpdateOrder(order);
            }
        }
    }
}