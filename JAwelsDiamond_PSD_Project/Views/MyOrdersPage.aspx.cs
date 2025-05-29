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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void checkUserSession()
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                return;
            }
        }
    }
}