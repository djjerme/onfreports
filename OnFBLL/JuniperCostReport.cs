using System;
using System.Collections.Generic;
using System.Text;
using PBA.OnfDAL;
using PBA.OnfInfo;

namespace PBA.OnfBLL
{
    public class JuniperCostReport
    {
        public static JuniperCostReportInfo[] GetJuniperCostReport(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype)
        {
            // lets get two arrays, one for the order head and one for order lines
            // then lets combine them and do some math -- easier than logic on the sql side
            JuniperCostReportInfo[] jcr = null;
            jcr = JuniperCostReportData.GetCostReportHeaders(storeId, startdate, enddate, deptid, usertype);

            // lets grab all order lines for these orders now
            JuniperCostReportLineInfo[] jcrl = null;
            jcrl = JuniperCostReportData.GetCostReportOrderLines(storeId, startdate, enddate, deptid, usertype);

            // lets cycle through the main order heads, add in the order lines and do any calculations needed
            foreach (JuniperCostReportInfo costReport in jcr)
            {
                costReport.OrderLines = getOrderLines(costReport, jcrl);
            }

            return jcr;
        }

        static List<JuniperCostReportLineInfo> getOrderLines(JuniperCostReportInfo costReport, JuniperCostReportLineInfo[] costLines)
        {
            List<JuniperCostReportLineInfo> orderLines = new List<JuniperCostReportLineInfo>();

            foreach (JuniperCostReportLineInfo cl in costLines)
            {
                if (cl.OrderId == costReport.OrderId)
                {
                    orderLines.Add(cl);
                }
            }

            return orderLines;
        }
    }

    public class JuniperActiveUserReport
    {
        public static JuniperActiveUserReportInfo[] GetJuniperActiveUserReport(int? storeId, DateTime startdate, DateTime enddate, bool SSOUsers)
        {
            return JuniperActiveUsersReportData.GetActiveUsersReport(storeId, startdate, enddate, SSOUsers);
        }

        public static JuniperActiveUsersInfo[] GetJuniperActiveUsers(int? storeId, DateTime startdate, DateTime enddate, bool SSOUsers)
        {
            return JuniperActiveUsersReportData.GetJuniperActiveUsers(storeId, startdate, enddate, SSOUsers);
        }
    }

    public class JuniperOrderedItemsReport
    {
        public static JuniperOrderedItemsInfo[] GetJuniperOrderedItems(int? storeId, DateTime startdate, DateTime enddate)
        {
            return JuniperOrderedItemsReportData.GetJuniperOrderedItems(storeId, startdate, enddate);
        }
    }
}
