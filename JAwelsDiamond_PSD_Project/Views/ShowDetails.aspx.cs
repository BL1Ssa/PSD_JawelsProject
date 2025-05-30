using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JAwelsDiamond_PSD_Project.Models;

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
            
            var jewel = controller.GetJewelDetails(jewelId);

            if (jewel == null)
            {
                ShowNotFound();
                return;
            }


            MsCategory category = handler.GetCategory(jewel.CategoryID);
            MsBrand brand = handler.getBrand(jewel.BrandID);
            
            lblName.Text = jewel.JewelName;
            lblCategory.Text = category.CategoryName;
            lblBrand.Text = brand.BrandName;
            lblCountry.Text = brand.BrandCountry;
            lblClass.Text = brand.BrandClass;
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

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            //Response.Redirect("")
        }
    }
}