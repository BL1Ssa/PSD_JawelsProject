using JAwelsDiamond_PSD_Project.Controller;
using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class MyOrdersPage : System.Web.UI.Page
    {
        OrderController controller = new OrderController();
        protected void Page_Load(object sender, EventArgs e)
        {

            checkUserSession();
            int id = int.Parse(Session["UserID"] as string);
            List<TransactionHeader> data = controller.getAllTransaction(id);

            OrdersGV.DataSource = data;
            OrdersGV.DataBind();
        }

        protected void checkUserSession()
        {
            string role = Session["UserRole"] as string;
            if (Session["UserID"] == null && role != "customer")
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                return;
            }

        }

        protected void OrdersGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = getId(e);
            if(e.CommandName == "View")
            { 
                Response.Redirect("~/View/TransactionDetailsPage.aspx?id=" + id);
            }
            else if (e.CommandName == "confirm")
            {
                controller.confirmPackage(id);
                
            }
            else if(e.CommandName == "Reject")
            {
                controller.rejectPackage(id);
            }

        }
        private int getId(GridViewCommandEventArgs e)
        {
            string argument = e.CommandArgument.ToString();
            int id = int.Parse(argument);

            return id;
        }

        protected void OrdersGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();

                Button btnConfirm = (Button)e.Row.FindControl("btnConfirm");
                Button btnReject = (Button)e.Row.FindControl("btnReject");

                if (status == "Arrived")
                {
                    if (btnConfirm != null) btnConfirm.Visible = true;
                    if (btnReject != null) btnReject.Visible = true;
                }
            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}