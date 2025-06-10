using jawels_project_2.Controller;
using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views
{
    public partial class TransactionDetailsPage : System.Web.UI.Page
    {
        OrderController controller = new OrderController();
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                int id = int.Parse(Request.QueryString["id"]);
                TransactionDetail td = controller.getTransactionDetail(id);


                int jewelId = td.JewelID;
                MsJewel jewel = jewelController.GetJewelById(jewelId);

                idlbl.Text = td.TransactionID.ToString();
                namelbl.Text = jewel.JewelName.ToString();
                quantitylbl.Text = td.Quantity.ToString();
            }

        }
        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}