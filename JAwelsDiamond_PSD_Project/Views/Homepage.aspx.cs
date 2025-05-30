using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Linq;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            JewelController controller = new JewelController();

            if (!IsPostBack)
            {
              
                var jewelList = controller.GetAllJewels();
                rptJewels.DataSource = jewelList;
                rptJewels.DataBind();
            }
        }
    }
}