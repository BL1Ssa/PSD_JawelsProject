using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Web.UI;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        private readonly UserController _controller = new UserController();

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
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                if (_controller.Register(txtEmail.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text, rblGender.SelectedValue, txtDOB.Text))
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    lblError.Text = "Registration failed. Please check your input or try again.";
                }
            }
        }

        protected void CustomEmail_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = _controller.ValidateEmail(args.Value.Trim());
        }

        protected void CustomUsername_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = _controller.ValidateUsername(args.Value.Trim());
        }

        protected void CustomPassword_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = _controller.ValidatePassword(args.Value);
        }

        protected void CustomDOB_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            DateTime dob;
            args.IsValid = _controller.ValidateDOB(args.Value, out dob);
        }
    }
}