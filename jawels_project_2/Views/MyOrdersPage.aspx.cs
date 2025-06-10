using jawels_project_2.Controller;
using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views
{
    public partial class MyOrdersPage : System.Web.UI.Page
    {
        OrderController controller = new OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkUserSession();
                BindOrdersGrid();
            }
        }

        protected void checkUserSession()
        {
            if (Session["UserID"] == null || (Session["UserRole"] as string) != "customer")
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
        }

        private void BindOrdersGrid()
        {
            if (Session["UserID"] == null)
            {
                return;
            }

            int userId = Convert.ToInt32(Session["UserID"]);
            List<TransactionHeader> data = controller.getAllTransactions(userId);

            if (data == null || data.Count == 0)
            {
                OrdersGV.EmptyDataText = "You have no orders yet.";
                OrdersGV.DataSource = null;
            }
            else
            {
                OrdersGV.DataSource = data;
            }
            OrdersGV.DataBind();
        }

        private int getId(GridViewCommandEventArgs e)
        {
            return Convert.ToInt32(e.CommandArgument.ToString());
        }

        protected void OrdersGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            checkUserSession();
            if (Session["UserID"] == null) return;

            int transactionId = getId(e);

            if (e.CommandName == "View")
            {
                Response.Redirect($"~/Views/TransactionDetailsPage.aspx?id={transactionId}");
            }
            else if (e.CommandName == "Confirm")
            {
                controller.confirmPackage(transactionId);
                BindOrdersGrid();
            }
            else if (e.CommandName == "Reject")
            {
                controller.rejectPackage(transactionId);
                BindOrdersGrid();
            }
        }

        protected void OrdersGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus")?.ToString() ?? "";

                Button btnConfirm = (Button)e.Row.FindControl("btnConfirm");
                Button btnReject = (Button)e.Row.FindControl("btnReject");

                if (status.Equals("Arrived", StringComparison.OrdinalIgnoreCase))
                {
                    if (btnConfirm != null) btnConfirm.Visible = true;
                    if (btnReject != null) btnReject.Visible = true;
                }
                else
                {
                    if (btnConfirm != null) btnConfirm.Visible = false;
                    if (btnReject != null) btnReject.Visible = false;
                }
            }
        }

        protected void Backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}