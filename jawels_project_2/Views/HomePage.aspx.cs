using jawels_project_2.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        JewelHandler handler = new JewelHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var jewelList = handler.GetAllJewels();
                rptJewels.DataSource = jewelList;
                rptJewels.DataBind();
            }
        }
    }
}