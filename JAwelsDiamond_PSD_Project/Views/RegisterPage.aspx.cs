using JAwelsDiamond_PSD_Project.Controller;
using System;
<<<<<<< HEAD
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
                Response.Redirect("Home.aspx");
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
=======
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class Register : System.Web.UI.Page
    {
        UserController controller = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dateCalendar_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void genderRadio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            string username = nametb.Text;
            string email = emailtb.Text;
            string password = passwordtb.Text;
            string confPass = confpasstb.Text;
            string gender = genderRadio.SelectedValue;
            DateTime dob = dateCalendar.SelectedDate;

            string response = controller.Register(email, username, password, confPass, gender, dob);
            messagelbl.Text = response;

            Response.Redirect("~/Views/LoginPage.aspx");

>>>>>>> alvin
        }
    }
}