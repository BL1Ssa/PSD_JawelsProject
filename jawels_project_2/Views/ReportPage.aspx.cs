using jawels_project_2.Datasets;
using jawels_project_2.Factory;
using jawels_project_2.Handler;
using jawels_project_2.Models;
using jawels_project_2.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jawels_project_2.Views
{
    public partial class ReportPage : System.Web.UI.Page
    {
        
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            JawelsCrystalReport repor = new JawelsCrystalReport();
            ReportHandler repoHandle = new ReportHandler();
            CrystalReportViewer1.ReportSource = repor;
            JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3();
            JawelDatasets data = repoHandle.getData(db.TransactionHeaders.ToList());
            repor.SetDataSource(data);
            
        }
    }
}