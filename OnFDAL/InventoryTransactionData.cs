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
    /// Data access class for InventoryTransaction
    /// </summary>
    public class InventoryTransactionData : DataAccess
    {
        // Get transaction info by store, item, date range
        static public InventoryTransactionInfo[] GetInventoryTransaction(
            int? storeid, string itemid, DateTime? startdate, DateTime? enddate)
        {
            string startdatestr = Escape(((DateTime)(startdate)).ToString("yyyy-MM-dd HH:mm:ss.fff"));

            string enddatestr = Escape(((DateTime)(enddate)).ToString("yyyy-MM-dd HH:mm:ss.fff"));

            string sql = string.Empty;
            ArrayList c = new ArrayList();


            sql = "select dbo.UDF_ProperCase(ita.[action]) action, sum(coalesce(it.qty, 0)) qty "
                + "from inv_trans_action ita "
                + "left outer join inv_trans it on ita.[action] = it.[action] "
                + "   and it.store_id = " + Escape(storeid.ToString()) + " "
                + "   and it.trans_time >= '" + startdatestr + "' "
                + "   and it.trans_time <= '" + enddatestr + "' "
                + "   and it.item_id = '" + itemid + "' "
                + "group by ita.[action] order by ita.[action]";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                InventoryTransactionInfo al = new InventoryTransactionInfo();

                al.Action = NCS(d["action"]);
                al.Qty = NCI(d["qty"]);
                c.Add(al);
            }

            d.Close();

            return (InventoryTransactionInfo[])c.ToArray(typeof(InventoryTransactionInfo));
        }

    }
}
