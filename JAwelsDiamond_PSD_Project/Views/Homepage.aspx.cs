﻿using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class HomePage : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            JewelController controller = new JewelController();

            if (!IsPostBack)
            {
              
                var jewelList = controller.GetAllJewels();
                rptJewel.DataSource = jewelList;
                rptJewel.DataBind();
            }
        }
    }
}