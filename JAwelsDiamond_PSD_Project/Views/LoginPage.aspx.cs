using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Web;
using System.Web.UI;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private UserController userController = new UserController();

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

            if (Session["UserID"] == null && Request.Cookies["UserLogin"] != null)
            {
                string userId = Request.Cookies["UserLogin"]["UserID"];
                var user = userController.GetUserById(userId);
                if (user != null)
                {
                    Session["UserID"] = user.UserID;
                    Session["UserName"] = user.UserName;
                    Session["UserRole"] = user.UserRole;
                }
            }

            if (Session["UserID"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            string errorMessage;
            var user = userController.Login(email, password, out errorMessage);

            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["UserName"] = user.UserName;
                Session["UserRole"] = user.UserRole;

                if (chkRememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("UserLogin");
                    cookie.Values["UserID"] = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblError.Text = errorMessage;
                lblError.Visible = true;
            }
        }
    }
}