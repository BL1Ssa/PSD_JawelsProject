using System;
using System.Linq;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
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
            using (var db = new JawelsdatabaseEntities2())
            {
                ddlCategory.DataSource = db.MsCategories.ToList();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Category--", ""));

                ddlBrand.DataSource = db.MsBrands.ToList();
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Brand--", ""));
            }
        }

        private void LoadJewelData()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                var jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == JewelID);
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            int price, year, catId, brandId;
            if (!int.TryParse(txtPrice.Text, out price) ||
                !int.TryParse(txtReleaseYear.Text, out year) ||
                !int.TryParse(ddlCategory.SelectedValue, out catId) ||
                !int.TryParse(ddlBrand.SelectedValue, out brandId))
            {
                lblError.Text = "Invalid input.";
                lblError.Visible = true;
                return;
            }

            using (var db = new JawelsdatabaseEntities2())
            {
                var jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == JewelID);
                if (jewel == null)
                {
                    lblError.Text = "Jewel not found.";
                    lblError.Visible = true;
                    return;
                }
                jewel.JewelName = txtJewelName.Text.Trim();
                jewel.CategoryID = catId;
                jewel.BrandID = brandId;
                jewel.JewelPrice = price;
                jewel.JewelReleaseYear = year;

                db.SaveChanges();
                lblSuccess.Text = "Jewel updated successfully!";
                lblSuccess.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            Response.Redirect("HomePage.aspx");
        }

        protected void cvJewelName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            var len = args.Value.Trim().Length;
            args.IsValid = len >= 3 && len <= 25;
        }

        protected void cvReleaseYear_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            int year;
            args.IsValid = int.TryParse(args.Value, out year) && year < DateTime.Now.Year;
        }
    }
}