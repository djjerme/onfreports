using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PBA.OnfInfo;
using PBA.OnfDAL;

namespace PBA.OnfBLL
{
    /// <summary>
    /// This class implements business logic associated with
    /// Syndero batch order processing.
    /// </summary>
    public class OrderDetailReport
    {
        static public OrderDetailReportInfo[] GetOrderDetailReport(int storeid, DateTime startdate,
            DateTime enddate, string itemid, int deptid, int subdeptid, string usertype, bool snapshotsync,
            bool archive)
        {
            OrderDetailReportInfo[] orderInfo = OrderDetailReportData.GetOrderDetailReport(storeid,
                startdate, enddate, itemid, deptid, subdeptid, usertype, snapshotsync, archive);
            return orderInfo;
        }
    }
}
