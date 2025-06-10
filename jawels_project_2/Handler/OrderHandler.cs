using jawels_project_2.Models;
using jawels_project_2.Repository;
using System.Collections.Generic;
using System.Linq;

namespace jawels_project_2.handler
{
    public class OrderHandler
    {
        TransactionRepository repo = new TransactionRepository();

        // Confirm a completed package delivery
        public void confirmPackage(int id)
        {
            TransactionHeader th = repo.getTransactionHeader(id);
            if (th != null)
            {
                th.TransactionStatus = "done";
                repo.updateTransactionHeader(th);
            }
        }

        // Reject a package
        public void rejectPackage(int id)
        {
            TransactionHeader th = repo.getTransactionHeader(id);
            if (th != null)
            {
                th.TransactionStatus = "rejected";
                repo.updateTransactionHeader(th);
            }
        }

        // Check if a transaction exists
        public bool transactionExists(int id)
        {
            TransactionHeader th = repo.getTransactionHeader(id);
            return th != null;
        }

        // Get all transactions for a specific user
        public List<TransactionHeader> getAllTransactions(int userid)
        {
            return repo.getAllTransactions(userid);
        }

        // Get transaction detail for a given transaction ID
        public TransactionDetail getTransactionDetail(int transactionId)
        {
            return repo.getTransactionDetail(transactionId);
        }

        // Admin Panel - Get all transactions (for admin viewing)
        public List<TransactionHeader> GetAllOrders()
        {
            return repo.GetAllOrders(); // You must have this method in your repository
        }

        // Admin Panel - Get only orders with status "Pending"
        public IEnumerable<object> GetPendingOrders()
        {
            return repo.GetPendingOrders(); // You already have this in your current handler
        }

        // Admin Panel - Change status: ConfirmPayment or ShipPackage
        public void ChangeOrderStatus(int transactionId, string command)
        {
            TransactionHeader order = repo.GetOrderById(transactionId);
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
