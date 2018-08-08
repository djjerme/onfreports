using System;
using System.Collections.Generic;
using System.Text;
using PBA.OnfDAL;
using PBA.OnfInfo;

namespace PBA.OnfBLL
{
    public class GenericPODReport
    {
        public static GenericPODReportInfo[] GetGenericPODReport(DateTime startdate, DateTime enddate)
        {
            return GenericPODReportData.GetPODReportData(startdate, enddate);
        }

        public static GenericPODReportInfo[] GetGenericPODReport(int? storeId, DateTime startdate, DateTime enddate, int deptId, string userType)
        {
            return GenericPODReportData.GetPODReportData(storeId, startdate, enddate, deptId, userType);
        }
    }
}
