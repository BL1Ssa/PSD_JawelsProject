using System;
using System.Linq;
using System.Web.UI.WebControls;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "admin")
            {
                Response.Redirect("ErrorPage.aspx");
            }

            if (!IsPostBack)
            {
                getOrders();
            }
        }

        private void getOrders()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                var OrderBelomSlesai = db.TransactionHeaders
                    .Where(th => th.TransactionStatus.ToLower() != "done" && th.TransactionStatus.ToLower() != "rejected")
                    .Select(th => new
                    {
                        th.TransactionID,
                        th.UserID,
                        th.TransactionStatus
                    })
                    .ToList();

                gvOrders.DataSource = OrderBelomSlesai;
                gvOrders.DataBind();
            }
        }

        protected void changeOrderStatus(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int transactionId = Convert.ToInt32(gvOrders.DataKeys[row].Value);

            using (var db = new JawelsdatabaseEntities2())
            {
                var order = db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == transactionId);
                if (order == null) return;

                string status = order.TransactionStatus.ToLower();

                if (e.CommandName == "ConfirmPayment" && status == "payment pending")
                {
                    order.TransactionStatus = "shipment pending";
                    db.SaveChanges();
                }
                else if (e.CommandName == "ShipPackage" && status == "shipment pending")
                {
                    order.TransactionStatus = "arrived";
                    db.SaveChanges();
                }
            }
            getOrders();
        }
    }
}