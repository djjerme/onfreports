using System;
using System.Collections.Generic;
using System.Text;
using PBA.OnfDAL;
using PBA.OnfInfo;

namespace PBA.OnfBLL
{
    public class JuniperPartReport
    {
        public static JuniperPartReportInfo[] GetJuniperPartReport(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype, bool onlyDeptParts, int subdeptid)
        {
            return JuniperPartReportData.GetPartReportData(storeId, startdate, enddate, deptid, usertype, onlyDeptParts, subdeptid);
        }
    }
}
