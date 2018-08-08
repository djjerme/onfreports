using System;
using System.Collections.Generic;
using System.Text;
using PBA.OnfDAL;
using PBA.OnfInfo;

namespace PBA.OnfBLL
{
    public class JuniperPODReport
    {
        public static JuniperPODReportInfo[] GetJuniperPODReport(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype)
        {
            return JuniperPODReportData.GetPODReportData(storeId, startdate, enddate, deptid, usertype);
        }
    }
}
