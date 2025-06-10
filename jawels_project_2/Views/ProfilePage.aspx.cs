using jawels_project_2.Controller;
using jawels_project_2.Models;
using System;
using System.Data.SqlClient;

namespace jawels_project_2.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected MsUser CurrentUser;
        private readonly UserController _controller = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            string userId = Session["UserID"].ToString();
            CurrentUser = _controller.GetProfile(userId);

            if (CurrentUser == null)
            {
                lblError.Text = "User not found.";
                return;
            }

            if (!IsPostBack)
            {
                lblEmail.Text = CurrentUser.UserEmail;
                lblUsername.Text = CurrentUser.UserName;
                lblGender.Text = CurrentUser.UserGender;
                lblDOB.Text = CurrentUser.UserDOB != default(DateTime) ? CurrentUser.UserDOB.ToString("yyyy-MM-dd") : string.Empty;
            }
        }

        protected void cvOldPassword_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (CurrentUser == null)
            {
                args.IsValid = false;
                lblError.Text = "Session expired. Please log in again.";
                return;
            }

            string userId = Session["UserID"].ToString();
            args.IsValid = _controller.ValidateOldPassword(userId, txtOldPassword.Text);
        }

        protected void cvNewPassword_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = _controller.ValidateNewPassword(args.Value);
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int userId = Convert.ToInt32(Session["UserID"]);
                _controller.ChangePassword(userId, txtNewPassword.Text);

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Password changed successfully.";
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}