using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PBA.OnfInfo;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace PBA.OnfDAL
{
    public class CarrierData : DataAccess
    {
        public static CarrierInfo[] GetCarrier()
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "SELECT carrier_id, carrier_code, name, domestic_multiplier, international_multiplier "
            + "FROM carrier "
            + "WHERE carrier_id <> 0 "
            + "UNION "
            + "SELECT 0 carrier_id, '(All)' carrier_code, 'All Carriers' name, null domestic_multiplier, null international_multiplier "
            + "Order by Carrier_code";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                CarrierInfo al = new CarrierInfo();

                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.Name = NCS(d["name"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                c.Add(al);
            }

            d.Close();

            return (CarrierInfo[])c.ToArray(typeof(CarrierInfo));
        }

        public static CarrierInfo[] GetCarriersOnly()
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "SELECT carrier_id, carrier_code, name, domestic_multiplier, international_multiplier "
            + "FROM carrier "
            + "WHERE carrier_id <> 0 ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                CarrierInfo al = new CarrierInfo();

                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.Name = NCS(d["name"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                c.Add(al);
            }

            d.Close();

            return (CarrierInfo[])c.ToArray(typeof(CarrierInfo));
        }

        public static CarrierInfo[] GetCarriersWithoutFreightRule(int? storeid)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "select c.carrier_id, c.carrier_code, c.name, c.domestic_multiplier, c.international_multiplier "
                + "from Carrier c "
                + "left outer join freight_rule fr on c.carrier_id = fr.carrier_id "
	            + "and fr.store_id = @StoreId "
                + "where fr.store_id is null "
                + "   and c.carrier_id <> 0";

            SqlParameter parm1 = new SqlParameter("@StoreId", SqlDbType.SmallInt);
            parm1.Value = storeid;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1 };

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);

            while (d.Read())
            {
                CarrierInfo al = new CarrierInfo();

                al.CarrierId = NCI(d["carrier_id"]);
                al.CarrierCode = NCS(d["carrier_code"]);
                al.Name = NCS(d["name"]);
                al.DomesticMultiplier = NCDbl(d["domestic_multiplier"]);
                al.InternationalMultiplier = NCDbl(d["international_multiplier"]);
                c.Add(al);
            }

            d.Close();

            return (CarrierInfo[])c.ToArray(typeof(CarrierInfo));
        }

        public static CarrierInfo UpdateCarrier(CarrierInfo info)
        {
            string sql = string.Empty;
            CarrierInfo info1 = null;

            sql = "UPDATE carrier set domestic_multiplier = @DomesticMultiplier, "
                + "   international_multiplier = @InternationalMultiplier "
                + "WHERE carrier_id = @CarrierId ";

            SqlParameter parm1 = new SqlParameter("@DomesticMultiplier", SqlDbType.Float);
            parm1.Value = info.DomesticMultiplier;

            SqlParameter parm2 = new SqlParameter("@InternationalMultiplier", SqlDbType.Float);
            parm2.Value = info.InternationalMultiplier;

            SqlParameter parm3 = new SqlParameter("@CarrierId", SqlDbType.Int);
            parm3.Value = info.CarrierId;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1, parm2, parm3 };

            try
            {
                SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);
                info1 = info;
            }
            catch (Exception)
            {
            }

            return info1;
        }
    }
}
