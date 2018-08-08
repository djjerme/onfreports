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
    public class OrderSummaryReport
    {
        static public OrderSummaryReportInfo[] GetOrderSummaryReport(int storeid, DateTime startdate,
            DateTime enddate, string itemid, int deptid, int subdeptid, string usertype, string grouping,
            bool snapshotsync, bool archive)
        {
            OrderSummaryReportInfo[] orderInfo = OrderSummaryReportData.GetOrderSummaryReport(storeid,
                startdate, enddate, itemid, deptid, subdeptid, usertype, grouping, snapshotsync, archive);
            return orderInfo;
        }
    }
}
