using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class RegisterPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ScriptManager.ScriptResourceMapping.GetDefinition("jquery") == null)
            {
                ScriptManager.ScriptResourceMapping.AddDefinition(
                    "jquery",
                    new ScriptResourceDefinition
                    {
                        Path = "~/Scripts/jquery-3.7.1.min.js",
                        DebugPath = "~/Scripts/jquery-3.7.1.js",
                        CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.1.min.js",
                        CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.1.js"
                    }
                );
            }

            if (Session["UserID"] != null)
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var controller = new UserController();
            var result = controller.Register(
                txtEmail.Text.Trim(),
                txtUsername.Text.Trim(),
                txtPassword.Text,
                rblGender.SelectedValue,
                txtDOB.Text
            );

            if (result.IsSuccess)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                lblError.Text = result.ErrorMessage;
            }
        }
    }
}