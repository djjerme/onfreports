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
    public class OrderShippingDetailData : DataAccess
    {
        static public OrderShippingDetailInfo[] GetOrderShippingDetail()
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();
            SqlDataReader d = null;
            SqlConnection conn;

            conn = new SqlConnection(dbConnection);

            sql = "select * "
                + "from v_OrderShippingDetail "
                + "order by urgency_code, need_date";

            d = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);
            while (d.Read())
            {
                OrderShippingDetailInfo al = new OrderShippingDetailInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.PickDate = NCD(d["pick_date"]);
                al.NeedDate = NCD(d["need_date"]);
                al.RequestedShipMethod = NCS(d["requested_ship_method"]);
                al.ShipLabelComment=NCS(d["ship_label_comment"]);
                al.StoreName=NCS(d["store_name"]);
                al.UrgencyCode = NCI(d["urgency_code"]);
                c.Add(al);
            }

            return (OrderShippingDetailInfo[])c.ToArray(typeof(OrderShippingDetailInfo));

        }

        static public OrderShippingDetailInfo[] GetOrderShippingDetail(int? storeid, DateTime? needstart, DateTime? needend, string requestedshipmethod)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();
            SqlDataReader d = null;
            SqlConnection conn;
            string whereclause = "";
            SqlParameter parmStoreId = null;
            SqlParameter parmneedstart = null;
            SqlParameter parmneedend = null;
            SqlParameter parmrequestedshipmethod = null;
            SqlParameter[] parms = new SqlParameter[4];
            

            conn = new SqlConnection(dbConnection);

            sql = "select * "
                + "from v_OrderShippingDetail ";
            if (storeid != null)
            {
                whereclause += string.Format("{0} store_id = @storeid ",
                    whereclause == "" ? "WHERE" : "AND");

                parmStoreId = new SqlParameter("@storeid", SqlDbType.Int);
                parmStoreId.Value = storeid;
            }

            if (needstart != null)
            {
                whereclause += string.Format("{0} need_date >= @needdatestart ",
                    whereclause == "" ? "WHERE" : "AND");
                parmneedstart = new SqlParameter("@needdatestart", SqlDbType.DateTime, 0);
                parmneedstart.Value = needstart;
            }

            if (needend != null)
            {
                whereclause += string.Format("{0} need_date < @needdateend ",
                    whereclause == "" ? "WHERE" : "AND");
                parmneedend = new SqlParameter("@needdateend", SqlDbType.DateTime, 0);
                parmneedend.Value = needstart;
            }

            if (requestedshipmethod != "")
            {
                whereclause += string.Format("{0} requested_ship_method like @requestedshipmethod ",
                    whereclause == "" ? "WHERE" : "AND");
                parmrequestedshipmethod = new SqlParameter("@requestedshipmethod", SqlDbType.VarChar, 250);
                parmrequestedshipmethod.Value = string.Format("%{0}%", requestedshipmethod);
            }

            sql += whereclause + "order by urgency_code, need_date";
            SqlCommand  cmd = new SqlCommand(sql);
            int i = 0;
            if (parmStoreId != null)
            {
                parms[0] = parmStoreId;
            }
            if (parmneedstart != null)
            {
                parms[1] = parmneedstart;
            }
            if (parmneedend != null)
            {
                parms[2] = parmneedend;
            }
            if (parmrequestedshipmethod != null)
            {
                parms[3] = parmrequestedshipmethod;
            }

            d = SqlHelper.ExecuteReader(conn, CommandType.Text, cmd.CommandText, parms);
            while (d.Read())
            {
                OrderShippingDetailInfo al = new OrderShippingDetailInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.PickDate = NCD(d["pick_date"]);
                al.NeedDate = NCD(d["need_date"]);
                al.RequestedShipMethod = NCS(d["requested_ship_method"]);
                al.ShipLabelComment = NCS(d["ship_label_comment"]);
                al.StoreName = NCS(d["store_name"]);
                al.UrgencyCode = NCI(d["urgency_code"]);
                c.Add(al);
            }

            return (OrderShippingDetailInfo[])c.ToArray(typeof(OrderShippingDetailInfo));

        }
    }
}
