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
    public class SynderoReconciliation
    {
        static public SynderoReconciliationReportInfo[] GetSynderoReconciliationReport(int storeid, DateTime importdate,
            DateTime workdate)
        {
            SynderoReconciliationReportInfo[] reconciliationInfo = SynderoReconciliationReportData.GetSynderoReconciliationReport(storeid,
                importdate, workdate);
            return reconciliationInfo;
        }
    }
}
