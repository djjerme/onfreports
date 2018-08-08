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
    /// associated with the Order Summary Report.
    /// </summary>
    public class OrderSummaryReportData : DataAccess
    {
        static public OrderSummaryReportInfo[] GetOrderSummaryReport(int storeid, DateTime startdate,
            DateTime enddate, string itemid, int deptid, int subdeptid, string usertype,
            string grouping, bool snapshotsync, bool archive)
        {
            ArrayList c = new ArrayList();
            SqlParameter lParm;
            SqlDataReader d = null;
            SqlConnection conn;

            if (!archive)
            {
                conn = new SqlConnection(dbConnection);
            }
            else
            {
                conn = new SqlConnection(dbConnectionArchive);
            }

            SqlCommand lSP = new SqlCommand("sp_OrderSummary", conn);
            lSP.CommandType = System.Data.CommandType.StoredProcedure;

            lParm = lSP.Parameters.Add("@storeid", SqlDbType.Int, 0);
            lParm.Value = storeid;
            lParm = lSP.Parameters.Add("@startdate", SqlDbType.DateTime, 0);
            lParm.Value = startdate;
            lParm = lSP.Parameters.Add("@enddate", SqlDbType.DateTime, 0);
            lParm.Value = enddate;
            lParm = lSP.Parameters.Add("@itemid", SqlDbType.VarChar, 80);
            lParm.Value = itemid;
            lParm = lSP.Parameters.Add("@deptid", SqlDbType.Int, 0);
            lParm.Value = deptid;
            lParm = lSP.Parameters.Add("@subdeptid", SqlDbType.Int, 0);
            lParm.Value = subdeptid;
            lParm = lSP.Parameters.Add("@usertype", SqlDbType.VarChar, 80);
            lParm.Value = usertype;
            lParm = lSP.Parameters.Add("@grouping", SqlDbType.VarChar, 80);
            lParm.Value = grouping;
            lParm = lSP.Parameters.Add("@snapshotsync", SqlDbType.Bit, 0);
            lParm.Value = snapshotsync;

            lSP.CommandTimeout = 300;

            try
            {
                conn.Open();

                lSP.Prepare();
                d = lSP.ExecuteReader();

                while (d.Read())
                {
                    OrderSummaryReportInfo al = new OrderSummaryReportInfo();

                    al.ItemId = NCS(d["item_id"]);
                    al.ProductName = NCS(d["product_name"]);
                    al.DeptName = NCS(d["dept_name"]);
                    al.SubDeptName = NCS(d["subdept_name"]);
                    al.TransDate = NCD(d["trans_date"]);
                    al.BegSnapshot = NCD(d["beg_snapshot"]);
                    al.EndSnapshot = NCD(d["end_snapshot"]);
                    al.UserType = NCS(d["user_type"]);
                    al.PickQty = NCI(d["pick_qty"]);
                    al.QtyOrdered = NCI(d["qty_ordered"]);
                    al.QtyOrderedBefore = NCI(d["qty_ordered_prior"]);
                    al.QtyNotPickedDuring = NCI(d["qty_shipped_after"]);
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

            return (OrderSummaryReportInfo[])c.ToArray(typeof(OrderSummaryReportInfo));

        }
    }
}
