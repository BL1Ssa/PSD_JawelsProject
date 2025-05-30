using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        private OrderController _orderController = new OrderController();

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
            gvOrders.DataSource = _orderController.GetPendingOrders();
            gvOrders.DataBind();
        }

        protected void changeOrderStatus(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int transactionId = Convert.ToInt32(gvOrders.DataKeys[row].Value);

            string command = e.CommandName;
            _orderController.ChangeOrderStatus(transactionId, command);

            BindOrders();
        }
    }
}