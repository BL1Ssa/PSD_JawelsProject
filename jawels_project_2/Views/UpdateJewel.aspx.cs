using System;
using System.Linq;
using jawels_project_2.Models;
using jawels_project_2.Controller;
using System.Data.SqlClient;

namespace jawels_project_2.Views
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
        private JewelController jewelController = new JewelController();

        protected int JewelID
        {
            get
            {
                int id;
                return int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "admin")
            {
                Response.Redirect("ErrorPage.aspx");
            }

            if (!IsPostBack)
            {
                LoadDropdowns();
                LoadJewelData();
            }
        }

        private void LoadDropdowns()
        {
            ddlCategory.DataSource = jewelController.GetCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Category--", ""));

            ddlBrand.DataSource = jewelController.GetBrands();
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Brand--", ""));
        }

        private void LoadJewelData()
        {
            var jewel = jewelController.GetJewelById(JewelID);
            if (jewel == null)
            {
                lblError.Text = "Jewel not found.";
                lblError.Visible = true;
                btnUpdate.Enabled = false;
                return;
            }
            txtJewelName.Text = jewel.JewelName;
            ddlCategory.SelectedValue = jewel.CategoryID.ToString();
            ddlBrand.SelectedValue = jewel.BrandID.ToString();
            txtPrice.Text = jewel.JewelPrice.ToString();
            txtReleaseYear.Text = jewel.JewelReleaseYear.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string errorMessage;
            bool success = jewelController.UpdateJewel(
                JewelID,
                txtJewelName.Text.Trim(),
                ddlCategory.SelectedValue,
                ddlBrand.SelectedValue,
                txtPrice.Text.Trim(),
                txtReleaseYear.Text.Trim(),
                out errorMessage
            );

            if (success)
            {
                lblSuccess.Text = "Jewel updated successfully!";
                lblSuccess.Visible = true;
            }
            else
            {
                lblError.Text = errorMessage;
                lblError.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void cvJewelName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = jewelController.ValidateJewelName(args.Value);
        }

        protected void cvReleaseYear_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = jewelController.ValidateReleaseYear(args.Value);
        }
    }
}