using System;
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
    public class FreightReportData : DataAccess
    {
        static public FreightReportInfo[] GetFreightReport(DateTime startdate,
            DateTime enddate, int carrierid, string orderby)
        {
            string sql;
            ArrayList c = new ArrayList();

            string sqlcarrier = carrierid > 0 ? 
                "     and fr.carrier_id = @CarrierId " : 
                "     and fr.carrier_id is not null ";

            if (orderby == "")
            {
                sql = "select * from "
                    + "(select fr.* from v_Freight_Report fr "
                    + "inner join store s on fr.store_id = s.store_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + sqlcarrier
                    + "   UNION ALL "
                    + "select fr.* from JNP_SQL.estore.dbo.v_Freight_Report fr "
                    + "inner join JNP_SQL.estore.dbo.store s on fr.store_id = s.store_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate) a "
                    + "ORDER BY a.store_id, a.order_id";
            }
            else
            {
                sql = "select * from "
                    + "(select fr.* from v_Freight_Report fr "
                    + "inner join store s on fr.store_id = s.store_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + sqlcarrier
                    + "   UNION ALL "
                    + "select fr.* from JNP_SQL.estore.dbo.v_Freight_Report fr "
                    + "inner join JNP_SQL.estore.dbo.store s on fr.store_id = s.store_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate) a "
                    + "ORDER BY a.store_id, a." + orderby + ", a.order_id";
            }

            SqlParameter parm1 = new SqlParameter("@StartDate", SqlDbType.DateTime);
            parm1.Value = startdate;

            SqlParameter parm2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            parm2.Value = enddate;

            SqlParameter parm3 = new SqlParameter("@CarrierId", SqlDbType.Int);
            parm2.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1, parm2, parm3 };

            //SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms, 120);
            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms); 

            while (d.Read())
            {
                FreightReportInfo al = new FreightReportInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderType = NCS(d["order_type"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.ShipDate = NCD(d["ship_date"]);
                al.ShipProcessDate = NCD(d["ship_process_date"]);
                al.ResolvedShipDate = NCD(d["resolved_ship_date"]);
                al.BatchUpdate = NCB(d["batch_update"]);
                al.PaymentMethod = NCS(d["payment_method"]);
                al.TransactionId = NCS(d["transaction_id"]);
                al.ActualShipping = NCDbl(d["actual_shipping"]);
                al.InternalShippingCost = NCDbl(d["internal_shipping_cost"]);
                al.NumberOfPackages = NCI(d["number_of_packages"]);
                al.OrderReason = NCS(d["order_reason"]);
                al.UserType = NCS(d["user_type"]);
                al.TrackingNo = NCS(d["tracking_no"]);
                al.ProductFamily = NCS(d["product_family"]);
                al.ActualShipMethod = NCS(d["actual_ship_method"]);
                al.ThirdPartyShipperFlag = NCB(d["third_party_shipper_flag"]);
                al.ThirdPartyShipperInfo = NCS(d["third_party_shipper_info"]);
                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                al.FirstName = NCS(d["first_name"]);
                al.LastName = NCS(d["last_name"]);
                al.ShipFirstName = NCS(d["ship_firstname"]);
                al.ShipLastName = NCS(d["ship_lastname"]);
                al.StoreName = NCS(d["store_name"]);
                al.Address1 = NCS(d["address_1"]);
                al.Address2 = NCS(d["address_2"]);
                al.Address3 = NCS(d["address_3"]);
                al.City = NCS(d["city"]);
                al.State = NCS(d["state"]);
                al.Zip = NCS(d["zip"]);
                al.Country = NCS(d["country"]);
                al.International = NCB(d["international"]);
                al.LineCount = NCI(d["line_count"]);
                al.UnitCount = NCI(d["unit_count"]);
                al.DomesticDiscount = NCDbl(d["domestic_discount"]);
                al.InternationalDiscount = NCDbl(d["international_discount"]);

                c.Add(al);
            }

            d.Close();

            return (FreightReportInfo[])c.ToArray(typeof(FreightReportInfo));
        }

        static public FreightReportInfo[] GetFreightReport(string userid, DateTime startdate,
            DateTime enddate, string orderby)
        {
            string sql;
            ArrayList c = new ArrayList();

            if (orderby == "")
            {
                sql = "select * from "
                    + "(select fr.* from v_Freight_Report fr "
                    + "inner join store s on fr.store_id = s.store_id "
                    + "inner join handler h on s.whse_id = h.whse_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and h.handler_id = @UserId "
                    + "   UNION ALL "
                    + "select fr.* from JNP_SQL.estore.dbo.v_Freight_Report fr "
                    + "inner join JNP_SQL.estore.dbo.store s on fr.store_id = s.store_id "
                    + "inner join JNP_SQL.estore.dbo.handler h on s.whse_id = h.whse_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and h.handler_id = @UserId) a "
                    + "ORDER BY a.store_id, a.order_id";
            }
            else
            {
                sql = "select * from "
                    + "(select fr.* from v_Freight_Report fr "
                    + "inner join store s on fr.store_id = s.store_id "
                    + "inner join handler h on s.whse_id = h.whse_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and h.handler_id = @UserId "
                    + "   UNION ALL "
                    + "select fr.* from JNP_SQL.estore.dbo.v_Freight_Report fr "
                    + "inner join JNP_SQL.estore.dbo.store s on fr.store_id = s.store_id "
                    + "inner join JNP_SQL.estore.dbo.handler h on s.whse_id = h.whse_id "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and h.handler_id = @UserId) a "
                    + "ORDER BY a.store_id, a." + orderby + ", a.order_id";
            }

            SqlParameter parm1 = new SqlParameter("@StartDate", SqlDbType.DateTime);
            parm1.Value = startdate;

            SqlParameter parm2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            parm2.Value = enddate;

            SqlParameter parm3 = new SqlParameter("@UserId", SqlDbType.VarChar);
            parm3.Value = userid;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1, parm2, parm3 };

            //SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms, 120);
            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);
            while (d.Read())
            {
                FreightReportInfo al = new FreightReportInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderType = NCS(d["order_type"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.ShipDate = NCD(d["ship_date"]);
                al.ShipProcessDate = NCD(d["ship_process_date"]);
                al.ResolvedShipDate = NCD(d["resolved_ship_date"]);
                al.BatchUpdate = NCB(d["batch_update"]);
                al.PaymentMethod = NCS(d["payment_method"]);
                al.TransactionId = NCS(d["transaction_id"]);
                al.ActualShipping = NCDbl(d["actual_shipping"]);
                al.InternalShippingCost = NCDbl(d["internal_shipping_cost"]);
                al.NumberOfPackages = NCI(d["number_of_packages"]);
                al.OrderReason = NCS(d["order_reason"]);
                al.UserType = NCS(d["user_type"]);
                al.TrackingNo = NCS(d["tracking_no"]);
                al.ProductFamily = NCS(d["product_family"]);
                al.ActualShipMethod = NCS(d["actual_ship_method"]);
                al.ThirdPartyShipperFlag = NCB(d["third_party_shipper_flag"]);
                al.ThirdPartyShipperInfo = NCS(d["third_party_shipper_info"]);
                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                al.FirstName = NCS(d["first_name"]);
                al.LastName = NCS(d["last_name"]);
                al.ShipFirstName = NCS(d["ship_firstname"]);
                al.ShipLastName = NCS(d["ship_lastname"]);
                al.StoreName = NCS(d["store_name"]);
                al.Address1 = NCS(d["address_1"]);
                al.Address2 = NCS(d["address_2"]);
                al.Address3 = NCS(d["address_3"]);
                al.City = NCS(d["city"]);
                al.State = NCS(d["state"]);
                al.Zip = NCS(d["zip"]);
                al.Country = NCS(d["country"]);
                al.International = NCB(d["international"]);
                al.LineCount = NCI(d["line_count"]);
                al.UnitCount = NCI(d["unit_count"]);
                al.DomesticDiscount = NCDbl(d["domestic_discount"]);
                al.InternationalDiscount = NCDbl(d["international_discount"]);

                c.Add(al);
            }

            d.Close();

            return (FreightReportInfo[])c.ToArray(typeof(FreightReportInfo));
        }

        static public FreightReportInfo[] GetFreightReport(int storeid, DateTime startdate,
            DateTime enddate, string orderby)
        {
            string sql;
            ArrayList c = new ArrayList();

            if (orderby == "")
            {
                sql = "select * from "
                    + "(select * from v_Freight_Report "
                    + "where ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and ship_date >= @StartDate "
                    + "     and store_id = @StoreId "
                    + "   UNION ALL "
                    + "select * from JNP_SQL.estore.dbo.v_Freight_Report "
                    + "where ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and ship_date >= @StartDate "
                    + "     and store_id = @StoreId) a "
                    + "ORDER BY a.order_id";
            }
            else
            {
                sql = "select * from "
                    + "(select * from v_Freight_Report "
                    + "where ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and ship_date >= @StartDate "
                    + "     and store_id = @StoreId "
                    + "   UNION ALL "
                    + "select * from JNP_SQL.estore.dbo.v_Freight_Report "
                    + "where ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and ship_date >= @StartDate "
                    + "     and store_id = @StoreId) a "
                    + "ORDER BY a." + orderby + ", a.order_id";
            }

            SqlParameter parm1 = new SqlParameter("@StartDate", SqlDbType.DateTime);
            parm1.Value = startdate;

            SqlParameter parm2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            parm2.Value = enddate;

            SqlParameter parm3 = new SqlParameter("@StoreId", SqlDbType.VarChar);
            parm3.Value = storeid;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1, parm2, parm3 };

            //SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms, 120);
            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);

            while (d.Read())
            {
                FreightReportInfo al = new FreightReportInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderType = NCS(d["order_type"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.ShipDate = NCD(d["ship_date"]);
                al.ShipProcessDate = NCD(d["ship_process_date"]);
                al.ResolvedShipDate = NCD(d["resolved_ship_date"]);
                al.BatchUpdate = NCB(d["batch_update"]);
                al.PaymentMethod = NCS(d["payment_method"]);
                al.TransactionId = NCS(d["transaction_id"]);
                al.ActualShipping = NCDbl(d["actual_shipping"]);
                al.InternalShippingCost = NCDbl(d["internal_shipping_cost"]);
                al.NumberOfPackages = NCI(d["number_of_packages"]);
                al.OrderReason = NCS(d["order_reason"]);
                al.UserType = NCS(d["user_type"]);
                al.TrackingNo = NCS(d["tracking_no"]);
                al.ProductFamily = NCS(d["product_family"]);
                al.ActualShipMethod = NCS(d["actual_ship_method"]);
                al.ThirdPartyShipperFlag = NCB(d["third_party_shipper_flag"]);
                al.ThirdPartyShipperInfo = NCS(d["third_party_shipper_info"]);
                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                al.FirstName = NCS(d["first_name"]);
                al.LastName = NCS(d["last_name"]);
                al.ShipFirstName = NCS(d["ship_firstname"]);
                al.ShipLastName = NCS(d["ship_lastname"]);
                al.StoreName = NCS(d["store_name"]);
                al.Address1 = NCS(d["address_1"]);
                al.Address2 = NCS(d["address_2"]);
                al.Address3 = NCS(d["address_3"]);
                al.City = NCS(d["city"]);
                al.State = NCS(d["state"]);
                al.Zip = NCS(d["zip"]);
                al.Country = NCS(d["country"]);
                al.International = NCB(d["international"]);
                al.LineCount = NCI(d["line_count"]);
                al.UnitCount = NCI(d["unit_count"]);
                al.DomesticDiscount = NCDbl(d["domestic_discount"]);
                al.InternationalDiscount = NCDbl(d["international_discount"]);

                c.Add(al);
            }

            d.Close();

            return (FreightReportInfo[])c.ToArray(typeof(FreightReportInfo));
        }

        static public FreightReportInfo[] GetFreightReport(int storeid, DateTime startdate,
            DateTime enddate, string orderby, ArrayList itemlist)
        {
            StringBuilder itempredicate = new StringBuilder();

            string sql;
            ArrayList c = new ArrayList();

            if (itemlist.Count > 0)
            {
                foreach (object itemid in itemlist)
                {
                    if (itempredicate.Length == 0)
                    {
                        itempredicate.Append("     and ol.item_id in (");
                    }
                    else
                    {
                        itempredicate.Append(", ");
                    }

                    itempredicate.Append(string.Format("'{0}'", itemid));
                }

                itempredicate.Append(") ");
            }

            if (orderby == "")
            {
                sql = "select a.* from "
                    + "(select distinct fr.* from v_Freight_Report fr "
                    + "inner join order_line ol on fr.store_id = ol.store_id "
                    + "     and fr.order_id = ol.order_id "
                    + "     and fr.order_suffix = ol.order_suffix "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and fr.store_id = @StoreId "
                    + itempredicate
                    + "   UNION ALL "
                    + "select distinct fr.* from JNP_SQL.estore.dbo.v_Freight_Report fr "
                    + "inner join JNP_SQL.estore.dbo.order_line ol on fr.store_id = ol.store_id "
                    + "     and fr.order_id = ol.order_id "
                    + "     and fr.order_suffix = ol.order_suffix "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and fr.store_id = @StoreId "
                    + itempredicate
                    + ") a"
                    + "ORDER BY a.order_id";
            }
            else
            {
                sql = "select a.* from "
                    + "(select distinct fr.* from v_Freight_Report fr "
                    + "inner join order_line ol on fr.store_id = ol.store_id "
                    + "     and fr.order_id = ol.order_id "
                    + "     and fr.order_suffix = ol.order_suffix "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and fr.store_id = @StoreId "
                    + itempredicate
                    + "   UNION ALL "
                    + "select distinct fr.* from JNP_SQL.estore.dbo.v_Freight_Report fr "
                    + "inner join JNP_SQL.estore.dbo.order_line ol on fr.store_id = ol.store_id "
                    + "     and fr.order_id = ol.order_id "
                    + "     and fr.order_suffix = ol.order_suffix "
                    + "where fr.ship_date < DateAdd(dd, 1, @EndDate) "
                    + "     and fr.ship_date >= @StartDate "
                    + "     and fr.store_id = @StoreId "
                    + itempredicate
                    + ") a"
                    + "ORDER BY a." + orderby + ", a.order_id";
            }

            SqlParameter parm1 = new SqlParameter("@StartDate", SqlDbType.DateTime);
            parm1.Value = startdate;

            SqlParameter parm2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            parm2.Value = enddate;

            SqlParameter parm3 = new SqlParameter("@StoreId", SqlDbType.VarChar);
            parm3.Value = storeid;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1, parm2, parm3 };

            //SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms, 120);
            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);

            while (d.Read())
            {
                FreightReportInfo al = new FreightReportInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderType = NCS(d["order_type"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.ShipDate = NCD(d["ship_date"]);
                al.ShipProcessDate = NCD(d["ship_process_date"]);
                al.ResolvedShipDate = NCD(d["resolved_ship_date"]);
                al.BatchUpdate = NCB(d["batch_update"]);
                al.PaymentMethod = NCS(d["payment_method"]);
                al.TransactionId = NCS(d["transaction_id"]);
                al.ActualShipping = NCDbl(d["actual_shipping"]);
                al.InternalShippingCost = NCDbl(d["internal_shipping_cost"]);
                al.NumberOfPackages = NCI(d["number_of_packages"]);
                al.OrderReason = NCS(d["order_reason"]);
                al.UserType = NCS(d["user_type"]);
                al.TrackingNo = NCS(d["tracking_no"]);
                al.ProductFamily = NCS(d["product_family"]);
                al.ActualShipMethod = NCS(d["actual_ship_method"]);
                al.ThirdPartyShipperFlag = NCB(d["third_party_shipper_flag"]);
                al.ThirdPartyShipperInfo = NCS(d["third_party_shipper_info"]);
                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                al.FirstName = NCS(d["first_name"]);
                al.LastName = NCS(d["last_name"]);
                al.ShipFirstName = NCS(d["ship_firstname"]);
                al.ShipLastName = NCS(d["ship_lastname"]);
                al.StoreName = NCS(d["store_name"]);
                al.Address1 = NCS(d["address_1"]);
                al.Address2 = NCS(d["address_2"]);
                al.Address3 = NCS(d["address_3"]);
                al.City = NCS(d["city"]);
                al.State = NCS(d["state"]);
                al.Zip = NCS(d["zip"]);
                al.Country = NCS(d["country"]);
                al.International = NCB(d["international"]);
                al.LineCount = NCI(d["line_count"]);
                al.UnitCount = NCI(d["unit_count"]);
                al.DomesticDiscount = NCDbl(d["domestic_discount"]);
                al.InternationalDiscount = NCDbl(d["international_discount"]);

                c.Add(al);
            }

            d.Close();

            return (FreightReportInfo[])c.ToArray(typeof(FreightReportInfo));
        }
    }
}
