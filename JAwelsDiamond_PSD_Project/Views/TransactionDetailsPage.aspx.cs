using JAwelsDiamond_PSD_Project.Controller;
using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class TransactionDetailsPage : System.Web.UI.Page
    {
        OrderController controller = new OrderController();
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            TransactionDetail td = controller.getTransactionDetail(id);


            int jewelId = td.JewelID;
            MsJewel jewel = jewelController.GetJewelById(jewelId);

            idlbl.Text = td.TransactionID.ToString();
            namelbl.Text = jewel.JewelName.ToString();
            quantitylbl.Text = td.Quantity.ToString();
        }
        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }
    }
}