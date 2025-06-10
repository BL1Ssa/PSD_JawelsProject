using jawels_project_2.Controller;
using jawels_project_2.Factory;
using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        private OrderController _orderController = new OrderController();
        private int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            userId = (int)Session["UserID"];

            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            var cart = _orderController.GetUserCartDisplay(userId);
            gvCart.DataSource = cart;
            gvCart.DataBind();

            decimal total = _orderController.GetTotal(userId);
            lblTotal.Text = "Total: " + total.ToString("C");
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvCart.Rows[index];
            int jewelId = Convert.ToInt32(gvCart.DataKeys[index].Value);
            TextBox txtQty = (TextBox)row.FindControl("txtQty");

            if (e.CommandName == "UpdateItem")
            {
                if (int.TryParse(txtQty.Text, out int qty) && CartFactory.ValidateQuantity(qty))
                {
                    _orderController.UpdateCartQuantity(userId, jewelId, qty);
                    LoadCart();
                }
            }
            else if (e.CommandName == "RemoveItem")
            {
                _orderController.RemoveFromCart(userId, jewelId);
                LoadCart();
            }
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            _orderController.ClearCart(userId);
            LoadCart();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlPaymentMethod.SelectedValue))
            {
                lblPaymentError.Text = "Please select a payment method.";
                lblPaymentError.Visible = true;
                return;
            }

            _orderController.Checkout(userId, ddlPaymentMethod.SelectedValue);
            LoadCart();
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}
