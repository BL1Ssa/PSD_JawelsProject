using jawels_project_2.Factory;
using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static CartRepository;

namespace jawels_project_2.Repository
{
    public class TransactionRepository
    {
        private readonly JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3();
        private readonly TransactionHeaderFactory thFactory = new TransactionHeaderFactory();
        private readonly TransactionDetailFactory tdFactory = new TransactionDetailFactory();

        // =================== CREATE ===================

        public void addNewTransactionHeader(int userId, DateTime transactionDate, string paymentMethod, string transactionStatus)
        {
            int transactionId = getLastHeaderId();
            TransactionHeader th = thFactory.createTransactionHeader(transactionId, userId, transactionDate, paymentMethod, transactionStatus);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public void addNewTransactionDetail(int transactionId, int jewelId, int quantity)
        {
            TransactionDetail td = tdFactory.createTransactionDetail(transactionId, jewelId, quantity);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public static void InsertTransaction(int userId, string paymentMethod, List<CartRepository.CartDisplayDTO> cartItems)
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                var header = new TransactionHeader
                {
                    UserID = userId,
                    PaymentMethod = paymentMethod,
                    TransactionDate = DateTime.Now,
                    TransactionStatus = "Payment Pending"
                };

                db.TransactionHeaders.Add(header);
                db.SaveChanges();

                if (cartItems != null && cartItems.Any())
                {
                    foreach (var item in cartItems)
                    {
                        var detail = new TransactionDetail
                        {
                            TransactionID = header.TransactionID,
                            JewelID = item.JewelID,
                            Quantity = item.Quantity
                        };
                        db.TransactionDetails.Add(detail);
                    }
                    db.SaveChanges();
                }
            }
        }

        // =================== READ ===================

        public List<TransactionHeader> getAllTransactions(int? userId = null)
        {
            if (userId != null)
            {
                return db.TransactionHeaders.Where(t => t.UserID == userId).ToList();
            }
            return db.TransactionHeaders.ToList();
        }

        public List<TransactionHeader> GetAllOrders()
        {
            return db.TransactionHeaders.ToList();
        }

        public TransactionHeader getTransactionHeader(int id)
        {
            return db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == id);
        }

        public TransactionDetail getTransactionDetail(int id)
        {
            return db.TransactionDetails.FirstOrDefault(t => t.TransactionID == id);
        }

        public TransactionHeader GetOrderById(int transactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == transactionId);
        }

        public TransactionHeader GetTransactionById(int transactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == transactionId);
        }

        public IEnumerable<object> GetPendingOrders()
        {
            return db.TransactionHeaders
                .Where(th => th.TransactionStatus.ToLower() != "done" && th.TransactionStatus.ToLower() != "rejected")
                .Select(th => new
                {
                    th.TransactionID,
                    th.UserID,
                    th.TransactionStatus
                })
                .ToList();
        }

        // =================== UPDATE ===================

        public bool updateTransactionHeader(TransactionHeader th)
        {
            TransactionHeader oldTh = db.TransactionHeaders.Find(th.TransactionID);
            if (oldTh != null)
            {
                oldTh.UserID = th.UserID;
                oldTh.TransactionDate = th.TransactionDate;
                oldTh.PaymentMethod = th.PaymentMethod;
                oldTh.TransactionStatus = th.TransactionStatus;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool updateTransactionDetail(TransactionDetail td)
        {
            TransactionDetail oldTd = db.TransactionDetails.Find(td.TransactionID);
            if (oldTd != null)
            {
                oldTd.JewelID = td.JewelID;
                oldTd.Quantity = td.Quantity;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateOrder(TransactionHeader order)
        {
            var existing = db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == order.TransactionID);
            if (existing != null)
            {
                existing.TransactionStatus = order.TransactionStatus;
                db.SaveChanges();
            }
        }

        public void UpdateTransaction(TransactionHeader transaction)
        {
            // Only SaveChanges is needed here since `transaction` should be tracked already
            db.SaveChanges();
        }

        // =================== DELETE ===================

        public bool deleteTransactionHeader(int id)
        {
            var header = db.TransactionHeaders.Find(id);
            var detail = db.TransactionDetails.FirstOrDefault(td => td.TransactionID == id);

            if (header != null)
            {
                if (detail != null)
                {
                    db.TransactionDetails.Remove(detail);
                }
                db.TransactionHeaders.Remove(header);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool deleteTransactionDetail(int id)
        {
            var detail = db.TransactionDetails.FirstOrDefault(td => td.TransactionID == id);
            if (detail != null)
            {
                db.TransactionDetails.Remove(detail);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        // =================== HELPERS ===================

        public int getLastHeaderId()
        {
            var last = db.TransactionHeaders.OrderByDescending(th => th.TransactionID).FirstOrDefault();
            return last != null ? last.TransactionID + 1 : 1;
        }

        public int getLastDetailId()
        {
            var last = db.TransactionDetails.OrderByDescending(td => td.TransactionID).FirstOrDefault();
            return last != null ? last.TransactionID + 1 : 1;
        }
    }
}
