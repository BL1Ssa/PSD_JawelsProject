using jawels_project_2.Datasets;
using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace jawels_project_2.Handler
{
    public class ReportHandler
    {
        public JawelDatasets getData(List<TransactionHeader> transactions)
        {
            JawelDatasets data = new JawelDatasets();

            var header = data.TransactionHeader;
            var detailtable = data.TransactionDetail;

            int grandtotal = 0;

            
            foreach (TransactionHeader th in transactions)
            {
                var hrow = header.NewRow();
                hrow["Transaction_id"] = th.TransactionID;
                hrow["User_id"] = th.UserID;
                hrow["Transaction_date"] = th.TransactionDate;

                if(th.TransactionStatus == "Done") {
                    foreach (TransactionDetail dt in th.TransactionDetails)
                    {
                        var drow = detailtable.NewRow();
                        drow["Transaction_id"] = dt.TransactionID;
                        drow["Jewel_id"] = dt.JewelID;
                        drow["quantity"] = dt.Quantity;

                        int subtotal = (int)(dt.Quantity * dt.MsJewel.JewelPrice);
                        grandtotal += subtotal;
                        drow["sub_total"] = subtotal;
                        detailtable.Rows.Add(drow);
                    }  
                }
                hrow["grand_total"] = grandtotal;
                header.Rows.Add(hrow);

            }
            return data;
        }
    }
}