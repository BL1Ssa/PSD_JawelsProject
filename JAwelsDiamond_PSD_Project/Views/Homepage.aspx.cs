using System;
using System.Linq;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var db = new JawelsdatabaseEntities2())
                {
                    var jewels = db.MsJewels.Select(j => new { j.JewelID }).ToList();
                    gvJewels.DataSource = jewels;
                    gvJewels.DataBind();
                }
            }
        }
    }
}