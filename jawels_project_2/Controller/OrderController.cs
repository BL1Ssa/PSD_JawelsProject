using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using jawels_project_2.Handler;
using jawels_project_2.Repository;
using static CartRepository;
using jawels_project_2.handler;

namespace jawels_project_2.Controller
{
    public class OrderController
    {
        private OrderHandler handler = new OrderHandler();
        private TransactionRepository _transactionRepo = new TransactionRepository();

        // Called by Admin
        public List<TransactionHeader> AllOrders => handler.GetAllOrders();

        public IEnumerable<object> PendingOrders => handler.GetPendingOrders();

        public void confirmPackage(int transactionId)
        {
            TransactionHeader th = _transactionRepo.getTransactionHeader(transactionId);
            if (th != null)
            {
                th.TransactionStatus = "Done";
                _transactionRepo.updateTransactionHeader(th);
            }
        }

        public void rejectPackage(int transactionId)
        {
            TransactionHeader th = _transactionRepo.getTransactionHeader(transactionId);
            if (th != null)
            {
                th.TransactionStatus = "Rejected";
                _transactionRepo.updateTransactionHeader(th);
            }
        }

        public List<TransactionHeader> getAllTransactions(int userid)
        {
            return _transactionRepo.getAllTransactions(userid);
        }

        public TransactionDetail getTransactionDetail(int transactionId)
        {
            return _transactionRepo.getTransactionDetail(transactionId);
        }

        public List<TransactionHeader> GetAllOrders()
        {
            return _transactionRepo.GetAllOrders();
        }

        public IEnumerable<object> GetPendingOrders()
        {
            return _transactionRepo.GetPendingOrders();
        }

        public void ChangeOrderStatus(int transactionId, string command)
        {
            TransactionHeader order = _transactionRepo.GetOrderById(transactionId);
            if (order == null) return;

            string currentStatus = order.TransactionStatus?.ToLower() ?? "";

            if (command == "ConfirmPayment" && currentStatus == "payment pending")
            {
                order.TransactionStatus = "Shipment Pending";
            }
            else if (command == "ShipPackage" && currentStatus == "shipment pending")
            {
                order.TransactionStatus = "Arrived";
            }
            _transactionRepo.updateTransactionHeader(order);
        }

        // Cart-related operations
        public List<CartDisplayDTO> GetUserCartDisplay(int userId)
        {
            return CartRepository.GetCartDisplayByUserID(userId);
        }

        public int GetTotal(int userId)
        {
            var cart = GetUserCartDisplay(userId);
            return (int)cart.Sum(c => c.Subtotal);
        }

        public void UpdateCartQuantity(int userId, int jewelId, int qty)
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                if (cartItem != null)
                {
                    cartItem.Quantity = qty;
                    db.SaveChanges();
                }
            }
        }

        public void RemoveFromCart(int userId, int jewelId)
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                if (cartItem != null)
                {
                    db.Carts.Remove(cartItem);
                    db.SaveChanges();
                }
            }
        }

        public void ClearCart(int userId)
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                var items = db.Carts.Where(c => c.UserID == userId).ToList();
                db.Carts.RemoveRange(items);
                db.SaveChanges();
            }
        }

        public void Checkout(int userId, string paymentMethod)
        {
            CartHandler.Checkout(userId, paymentMethod);
        }
    }
}
