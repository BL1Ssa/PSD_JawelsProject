using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class HandleOrders : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "admin")
            {
                Response.Redirect("ErrorPage.aspx");
            }

            if (!IsPostBack)
            {
                BindOrders();
            }
        }

        private void BindOrders()
        {
            var controller = new OrderController();
            var dt = controller.GetUnfinishedOrders(); 
            gvOrders.DataSource = dt;
            gvOrders.DataBind();
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();
                var transactionId = DataBinder.Eval(e.Row.DataItem, "TransactionId").ToString();
                var phActions = (PlaceHolder)e.Row.FindControl("phActions");

                if (status == "Payment Pending")
                {
                    var btn = new Button { Text = "Confirm Payment", CommandName = "ConfirmPayment", CommandArgument = transactionId, CssClass = "action-btn" };
                    phActions.Controls.Add(btn);
                }
                else if (status == "Shipment Pending")
                {
                    var btn = new Button { Text = "Ship Package", CommandName = "ShipPackage", CommandArgument = transactionId, CssClass = "action-btn" };
                    phActions.Controls.Add(btn);
                }
                else if (status == "Arrived")
                {
                    phActions.Controls.Add(new Literal { Text = "Waiting user confirmation..." });
                }
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var controller = new OrderController();
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ConfirmPayment")
            {
                controller.UpdateStatus(transactionId, "Shipment Pending");
            }
            else if (e.CommandName == "ShipPackage")
            {
                controller.UpdateStatus(transactionId, "Arrived");
            }
            BindOrders();
        }
    }
}