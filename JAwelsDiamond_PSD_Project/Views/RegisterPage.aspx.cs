using JAwelsDiamond_PSD_Project.Controller;
using System;
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

        }
    }
}