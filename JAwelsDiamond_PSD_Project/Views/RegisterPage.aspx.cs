using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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

        protected void CustomEmail_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string email = args.Value.Trim();
            using (var db = new JawelsdatabaseEntities2()) 
            {
                args.IsValid = !db.MsUsers.Any(u => u.UserEmail == email);
            }
        }

        protected void CustomUsername_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string username = args.Value.Trim();
            args.IsValid = username.Length >= 3 && username.Length <= 25;
        }

        protected void CustomPassword_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string password = args.Value;
            args.IsValid = Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,20}$");
        }

        protected void CustomDOB_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            DateTime dob;
            args.IsValid = DateTime.TryParse(args.Value, out dob) && dob < new DateTime(2010, 1, 1);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (var db = new JawelsdatabaseEntities2())
                {
                    var User = new MsUser
                    {
                        UserEmail = txtEmail.Text.Trim(),
                        UserName = txtUsername.Text.Trim(),
                        UserPassword = txtPassword.Text, 
                        UserGender = rblGender.SelectedValue,
                        UserDOB = DateTime.Parse(txtDOB.Text),
                        UserRole = "customer"
                    };
                    db.MsUsers.Add(User);
                    db.SaveChanges();
                }
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}