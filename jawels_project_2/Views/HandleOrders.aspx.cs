using jawels_project_2.Controller;
using System;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views
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
            gvOrders1.DataSource = _orderController.PendingOrders;
            gvOrders1.DataBind();
            
        }

        protected void changeOrderStatus(object sender, GridViewCommandEventArgs e)
        {
            int row = Convert.ToInt32(e.CommandArgument);
            int transactionId = Convert.ToInt32(gvOrders1.DataKeys[row].Value);

            string command = e.CommandName;
            _orderController.ChangeOrderStatus(transactionId, command);

            BindOrders();
        }
    }
}