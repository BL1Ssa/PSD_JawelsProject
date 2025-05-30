using JAwelsDiamond_PSD_Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class ShowDetails : System.Web.UI.Page
    {
        private JewelHandler _jewelHandler = new JewelHandler();
        private int _jewelId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get jewel ID from URL
                string jewelIdStr = Request.QueryString["JewelID"];
                if (string.IsNullOrEmpty(jewelIdStr))
                {
                    ShowNotFound();
                    return;
                }

                int jewelId;
                if (!int.TryParse(jewelIdStr, out jewelId))
                {
                    ShowNotFound();
                    return;
                }

                // Load jewel details
                LoadJewelDetails(jewelId);
            }
        }

        private void LoadJewelDetails(int jewelId)
        {
            JewelHandler handler = new JewelHandler();
            var jewel = handler.GetJewelDetails(jewelId);

            if (jewel == null)
            {
                ShowNotFound();
                return;
            }

            // Display details
            lblName.Text = jewel.JewelName;
            lblCategory.Text = jewel.MsCategory?.CategoryName ?? "-";
            lblBrand.Text = jewel.MsBrand?.BrandName ?? "-";
            lblCountry.Text = jewel.MsBrand?.BrandCountry ?? "-";
            lblClass.Text = jewel.MsBrand?.BrandClass ?? "-";
            lblPrice.Text = jewel.JewelPrice.ToString();
            lblReleaseYear.Text = jewel.JewelReleaseYear.ToString();

            // Show appropriate buttons based on user role
            if (Session["role"] != null)
            {
                string role = Session["role"].ToString();
                /*customerActions.Visible = (role == "customer");*/
                adminActions.Visible = (role == "admin");
            }
        }

        private void ShowNotFound()
        {
            jewelDetails.Visible = false;
            notFoundMessage.Visible = true;
        }

        //protected void btnAddToCart_Click(object sender, EventArgs e)
        //{
        //    int jewelId = int.Parse(Request.QueryString["id"]);
        //    int userId = int.Parse(Session["userid"].ToString());

        //    CartHandler cartHandler = new CartHandler();
        //    cartHandler.AddToCart(userId, jewelId, 1);

        //    Response.Redirect("Cart.aspx");
        //}

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int jewelId = int.Parse(Request.QueryString["JawelID"]);
            Response.Redirect($"UpdateJewel.aspx?id={jewelId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int jewelId = int.Parse(Request.QueryString["JawelID"]);
            JewelHandler handler = new JewelHandler();
            handler.DeleteJewel(jewelId);

            Response.Redirect("HomePage.aspx");
        }
    }
}