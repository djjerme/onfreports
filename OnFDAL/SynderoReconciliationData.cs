using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL
{
    /// <summary>
    /// This class implements Data Access logic
    /// associated with the Order Reconciliation Report.
    /// </summary>
    public class SynderoReconciliationReportData : DataAccess
    {
        static public SynderoReconciliationReportInfo[] GetSynderoReconciliationReport(int storeid, DateTime importdate,
            DateTime workdate)
        {
            ArrayList c = new ArrayList();
            SqlParameter lParm;
            SqlDataReader d = null;
            SqlConnection conn;

            conn = new SqlConnection(dbConnection);

            SqlCommand lSP = new SqlCommand("sp_Syndero_ReconciliationReport", conn);
            lSP.CommandType = System.Data.CommandType.StoredProcedure;

            lParm = lSP.Parameters.Add("@storeid", SqlDbType.Int, 0);
            lParm.Value = storeid;
            lParm = lSP.Parameters.Add("@ImportDate", SqlDbType.DateTime, 0);
            lParm.Value = importdate;
            lParm = lSP.Parameters.Add("@WorkDate", SqlDbType.DateTime, 0);
            lParm.Value = workdate;

            lSP.CommandTimeout = 300;

            try
            {
                conn.Open();

                lSP.Prepare();
                d = lSP.ExecuteReader();

                while (d.Read())
                {
                    SynderoReconciliationReportInfo al = new SynderoReconciliationReportInfo();

                    al.StoreId = NCI(d["StoreId"]);
                    al.ImportDate = NCD(d["ImportDate"]);
                    al.WorkDate = NCD(d["WorkDate"]);
                    al.ItemId = NCS(d["ItemId"]);
                    al.ConvertedItemId = NCS(d["ConvertedItemId"]);
                    al.ProductName = NCS(d["ProductName"]);
                    al.QtyImported = NCI(d["QtyImported"]);
                    al.QtyShipped = NCI(d["QtyShipped"]);
                    al.QtyDropped = NCI(d["QtyDropped"]);
                    al.QtyUnresolved = NCI(d["QtyUnresolved"]);
                    c.Add(al);
                }

            }
            catch (Exception e)
            {
                throw;
            }
            if (d != null)
            {
                d.Close();
            }
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

            return (SynderoReconciliationReportInfo[])c.ToArray(typeof(SynderoReconciliationReportInfo));

        }
    }
}
