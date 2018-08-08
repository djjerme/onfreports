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
    public class OrderDetailReportData : DataAccess
    {
        static public OrderDetailReportInfo[] GetOrderDetailReport(int storeid, DateTime startdate,
            DateTime enddate, string itemid, int deptid, int subdeptid, string usertype, bool snapshotsync,
            bool archive)
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

            SqlCommand lSP = new SqlCommand("sp_OrderDetail", conn);
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
                    OrderDetailReportInfo al = new OrderDetailReportInfo();

                    //al.OrderId = NCI(d["order_id"]);
                    al.CustOrderNo = NCS(d["cust_order_no"]);
                    al.ExternalOrderId = NCS(d["external_order_id"]);
                    al.OrderWhen = NCD(d["order_when"]);
                    al.ShipDate = NCD(d["ship_date"]);
                    //al.OrderStatus = NCS(d["status"]);
                    al.FirstName = NCS(d["first_name"]);
                    al.LastName = NCS(d["last_name"]);
                    al.UserType = NCS(d["user_type"]);
                    al.QtyPicked = -1 * NCI(d["pick_qty"]);
                    al.QtyOrderedPrior = NCI(d["qty_ordered_prior"]);
                    al.QtyNotShipped = NCI(d["qty_not_shipped"]);
                    al.ItemId = NCS(d["item_id"]);
                    al.ProductName = NCS(d["product_name"]);
                    //al.DeptName = NCS(d["dept_name"]);
                    //al.SubDeptName = NCS(d["subdept_name"]);
                    al.BegSnapshot = NCD(d["beg_snapshot"]);
                    al.EndSnapshot = NCD(d["end_snapshot"]);
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

            return (OrderDetailReportInfo[])c.ToArray(typeof(OrderDetailReportInfo));

        }
    }
}
