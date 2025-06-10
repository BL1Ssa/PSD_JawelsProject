using jawels_project_2.Datasets;
using jawels_project_2.Models;
using jawels_project_2.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jawels_project_2.Factory
{
    public class ReportFactory
    {
        JawelsCrystalReport reports = new JawelsCrystalReport();
        JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3();
    }
}