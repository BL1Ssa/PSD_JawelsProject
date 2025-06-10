using System;
using System.Linq;
using jawels_project_2;
using jawels_project_2.Controller;

namespace jawels_project_2.Views
{
    public partial class AddJewel : System.Web.UI.Page
    {
        private JewelController jewelController = new JewelController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "admin")
            {
                Response.Redirect("ErrorPage.aspx");
            }

            if (!IsPostBack)
            {
                ddlCategory.DataSource = jewelController.GetCategories();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Category --", ""));

                ddlBrand.DataSource = jewelController.GetBrands();
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Brand --", ""));
            }
        }

        protected void cvJewelName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = jewelController.ValidateJewelName(args.Value);
        }

        protected void cvReleaseYear_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = jewelController.ValidateReleaseYear(args.Value);
        }

        protected void btnAddJewel_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!jewelController.ValidatePrice(txtPrice.Text.Trim()))
                {
                    lblError.Text = "Error: Price must be a number and more than $25.";
                    lblError.Visible = true;
                    return;
                }

                string errorMessage;
                bool success = jewelController.AddJewel(
                    txtJewelName.Text.Trim(),
                    ddlCategory.SelectedValue,
                    ddlBrand.SelectedValue,
                    txtPrice.Text.Trim(),
                    txtReleaseYear.Text.Trim(),
                    out errorMessage
                );

                if (success)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    lblError.Text = "Error: " + errorMessage;
                    lblError.Visible = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}