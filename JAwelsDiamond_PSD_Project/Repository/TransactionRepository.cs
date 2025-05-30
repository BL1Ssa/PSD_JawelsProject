using JAwelsDiamond_PSD_Project.Factory;
using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Repository
{
	public class TransactionRepository
	{
		JawelsdatabaseEntities2 db = new JawelsdatabaseEntities2();
		TransactionHeaderFactory thFactory = new TransactionHeaderFactory();
		TransactionDetailFactory tdFactory = new TransactionDetailFactory();

		//create
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

        //read
        public List<TransactionHeader> getAllTransactions(int? userId = null)
		{
			if (userId != null)
			{
				return (from t in db.TransactionHeaders where t.UserID == userId select t).ToList();
			}
			return db.TransactionHeaders.ToList();
		}
		public TransactionHeader getTransactionHeader(int id)
		{
			TransactionHeader th = (from t in db.TransactionHeaders where t.TransactionID == id select t).FirstOrDefault();
			return th;
		}
        public TransactionDetail getTransactionDetail(int id)
        {
            TransactionDetail td = (from t in db.TransactionDetails where t.TransactionID == id select t).FirstOrDefault();
            return td;
        }


		//update
		public bool updateTransactionHeader(TransactionHeader th)
		{
			TransactionHeader oldTh = db.TransactionHeaders.Find(th.TransactionID);
			if(oldTh != null)
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
        //delete
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




        //helper
        public int getLastHeaderId()
        {
            TransactionHeader last = (from th in db.TransactionHeaders select th).Last();
            return last.TransactionID;
        }

        public int getLastDetailId()
        {
            TransactionDetail last = (from td in db.TransactionDetails select td).LastOrDefault();
            return last.TransactionID;
        }




        // order handler methods Stip Punya
        public IEnumerable<object> GetPendingOrders()
        {
            using (var db = new JawelsdatabaseEntities2())
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
        }

        public TransactionHeader GetOrderById(int transactionId)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == transactionId);
            }
        }

        public void UpdateOrder(TransactionHeader order)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                var existing = db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == order.TransactionID);
                if (existing != null)
                {
                    existing.TransactionStatus = order.TransactionStatus;
                    db.SaveChanges();
                }
            }
        }
    }
}