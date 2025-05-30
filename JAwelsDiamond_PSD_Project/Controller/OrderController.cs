using jawelsdiamond_psd_project.handler;
using JAwelsDiamond_PSD_Project.Handler;
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
    }
}