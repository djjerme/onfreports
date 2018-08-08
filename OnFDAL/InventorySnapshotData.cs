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
    /// Data access class for InventorySnapshot
    /// </summary>
    public class InventorySnapshotData : DataAccess
    {
        // Get Snapshot info by store, date range
        static public InventorySnapshotInfo[] GetInventorySnapshot(int? storeid, DateTime? startdate, DateTime? enddate,
            bool archive)
        {
            SqlConnection conn;
            
            string startdatestr = Escape(((DateTime)(startdate)).ToString("MM/dd/yyyy"));
            string enddatestr = Escape(((DateTime)(enddate)).ToString("MM/dd/yyyy"));

            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "select i.store_id, i.item_id, p.name product_name, "
                + "coalesce(d.name, '') dept_name, "
                + "coalesce(sd.name, '') sub_dept_name, "
                + "coalesce(is1.qty_on_hand, 0) beg_qty, "
                + "case when is1.snapshot_date is null then 0 else 1 end beg_snapshot_exists, "
                + "case when is2.snapshot_date is null then 0 else 1 end end_snapshot_exists, "
                + "coalesce(is1.snapshot_date, p.created_date) beg_date, "
                + "coalesce(is2.qty_on_hand, 0) end_qty, "
                + "coalesce(is2.snapshot_date, " 
                + "         (select max(snapshot_date) "
                + "             from inv_snapshot "
                + "          where snapshot_date <= DateAdd(dd, 1, '" + enddatestr + "') " 
                + "             and store_id = " + Escape(storeid.ToString()) + ")) end_date "
                + "from item i "
                + "inner join product p on i.store_id = p.store_id "
                + "   and i.product_id = p.product_id "
                + "left outer join dept_product dp on p.store_id = dp.store_id "
                + "   and p.product_id = dp.product_id "
                + "left outer  join dept d on dp.store_id = d.store_id "
                + "   and dp.dept_id = d.dept_id "
                + "left outer join sub_dept sd on dp.store_id = sd.store_id "
                + "   and dp.sub_dept_id = sd.sub_dept_id "
                + "left outer join inv_snapshot is1 on i.store_id = is1.store_id "
                + "   and i.item_id = is1.item_id "
                + "   and is1.snapshot_date = "
                + "     (select max(snapshot_date) from inv_snapshot "
                + "      where snapshot_date <= DateAdd(dd, 1, '" + startdatestr + "') "
                + "        and store_id = " + Escape(storeid.ToString())  
                + "        and item_id = i.item_id) "
                + "left outer join inv_snapshot is2 on i.store_id = is2.store_id "
                + "   and i.item_id = is2.item_id "
                + "   and is2.snapshot_date = "
                + "     (select max(snapshot_date) from inv_snapshot "
                + "      where snapshot_date <= DateAdd(dd, 1, '" + enddatestr + "') "
                + "         and store_id = " + Escape(storeid.ToString()) 
                + "         and item_id = i.item_id) "
                + "where i.store_id = " + Escape(storeid.ToString()) + " "
                //+ "and is1.snapshot_date is not null and is2.snapshot_date is not null "
                + "and (is1.snapshot_date between '" + startdatestr + "' and dateadd(dd, 1, '" + enddatestr + "') "
                + "     or is2.snapshot_date between '" + startdatestr + "' and dateadd(dd, 1, '" + enddatestr + "') ) "
                + "order by i.item_id";


            if (!archive)
            {
                conn = new SqlConnection(dbConnection);
            }
            else
            {
                conn = new SqlConnection(dbConnectionArchive);
            }
            SqlDataReader d = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);

            while (d.Read())
            {
                InventorySnapshotInfo al = new InventorySnapshotInfo();

                al.StoreId = NCI(d["store_id"]);
                al.ItemId = NCS(d["item_id"]);
                al.ProductName = NCS(d["product_name"]);
                al.DeptName = NCS(d["dept_name"]);
                al.SubDeptName = NCS(d["sub_dept_name"]);
                al.BegSnapshotExists = NCB(d["beg_snapshot_exists"]);
                al.BegQty = NCI(d["beg_qty"]);
                al.BegDate = NCD(d["beg_date"]);
                al.EndSnapshotExists = NCB(d["end_snapshot_exists"]);
                al.EndQty = NCI(d["end_qty"]);
                al.EndDate = NCD(d["end_date"]);

                al.Transactions = InventoryTransactionData.GetInventoryTransaction(storeid,
                    al.ItemId, (DateTime)al.BegDate, (DateTime)al.EndDate);

                c.Add(al);


            }

            d.Close();

            return (InventorySnapshotInfo[])c.ToArray(typeof(InventorySnapshotInfo));
        }

    }
}
