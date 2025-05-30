using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Controller;
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
        private JewelController controller = new JewelController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get jewel ID from URL
                string jewelIdStr = Request.QueryString["JewelID"];
                if (string.IsNullOrEmpty(jewelIdStr) || !int.TryParse(jewelIdStr, out int jewelId))
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
            
            var jewel = controller.GetJewelDetails(jewelId);

            if (jewel == null)
            {
                ShowNotFound();
                return;
            }

            
            lblName.Text = jewel.JewelName;
            lblCategory.Text = jewel.MsJewelCategory?.CategoryName ?? "-";
            lblBrand.Text = jewel.MsBrand?.BrandName ?? "-";
            lblCountry.Text = jewel.MsBrand?.Country ?? "-";
            lblClass.Text = jewel.MsBrand?.Class ?? "-";
            lblPrice.Text = jewel.JewelPrice.ToString();
            lblReleaseYear.Text = jewel.JewelReleaseYear.ToString();


            if (Session["role"] != null)
            {
                string role = Session["role"].ToString();
                if (role == "admin")
                {
                    adminActions.Visible = true;
                }
                else if (role == "customer")
                {
                    customerActions.Visible = true;
                }
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
            int jewelId = int.Parse(Request.QueryString["JewelID"]);
            Response.Redirect($"UpdateJewel.aspx?id={jewelId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int jewelId = int.Parse(Request.QueryString["JewelID"]);
            // Hapus jewel via controller
            controller.DeleteJewel(jewelId);

            Response.Redirect("Homepage.aspx");
        }
    }
}