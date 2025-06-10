using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views.Master_Page
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string role = Session["UserRole"] as string;
                string username = Session["UserName"] as string;

                if (string.IsNullOrEmpty(role))
                {
                    pnlGuest.Visible = true;
                }
                else if (role == "customer")
                {
                    pnlCustomer.Visible = true;
                    lblUserCustomer.Text = "Welcome, " + username;
                }
                else if (role == "admin")
                {
                    pnlAdmin.Visible = true;
                    lblUserAdmin.Text = "Welcome, " + username;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // clear cookie pas logout
            if (Request.Cookies["UserLogin"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}