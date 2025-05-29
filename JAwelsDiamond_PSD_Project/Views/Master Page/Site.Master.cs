using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views.Master_Page
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    string role = Session["role"] as string;
                    string username = Session["username"] as string;

                    if (string.IsNullOrEmpty(role))
                    {
                        pnlGuest.Visible = true;
                    }
                    else if (role == "Customer")
                    {
                        pnlCustomer.Visible = true;
                        lblUserCustomer.Text = "Welcome, " + username;
                    }
                    else if (role == "Admin")
                    {
                        pnlAdmin.Visible = true;
                        lblUserAdmin.Text = "Welcome, " + username;
                    }
                }
            

        }
    }
}