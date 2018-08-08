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
    /// associated with the Juniper Cost Report.
    /// </summary>
    public class JuniperPODReportData : DataAccess
    {
        static public JuniperPODReportInfo[] GetPODReportData(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype)
        {
            List<JuniperPODReportInfo> partReportList = new List<JuniperPODReportInfo>();

            string sql = String.Format(""
                + "select order_line.order_id,order_head.order_when,order_head.department,order_head.ship_date,person.user_type,person.last_name,person.first_name,order_line.item_id,order_line.qty_ordered,order_line.inventory_cost as Value, order_line.onf_cost as Cost,address.* \n"
                + " from order_line,order_head,person \n"
                + "LEFT JOIN address on address.person_id = person.person_id and address.store_id = person.store_id \n"
                + " where person.store_id = order_line.store_id and person.person_id = order_head.order_for and order_line.store_id = order_head.store_id and order_line.order_id = order_head.order_id and order_line.store_id = @store_id and order_line.order_id in (select order_head.order_id from order_head,person where order_head.store_id = @store_id and order_head.order_when > @start_date and order_head.order_when < @end_date and order_head.order_source = 'Web 2.0 order' and order_head.status <> 'D' and order_head.person_id = person.person_id and order_head.store_id = person.store_id) and order_line.print_on_demand_flag = 1 \n"
            );

            if (string.IsNullOrEmpty(usertype) == false)
            {
                sql += "AND (person.user_type = @usertype) \n";
            }

            if (deptid > 0)
            {
                sql += "AND order_head.order_id in (select order_id from order_line where store_id = @store_id and item_id in (select item_id from item where store_id = @store_id and product_id in (select product_id from dept_product where store_id = @store_id and dept_id = @deptid)))";
            }

            SqlParameter parmDeptId = new SqlParameter("@deptid", SqlDbType.Int);
            parmDeptId.Value = deptid;

            SqlParameter parmUserType = new SqlParameter("@usertype", SqlDbType.VarChar);
            parmUserType.Value = usertype;

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
            parmStoreId.Value = storeId.Value;

            SqlParameter parmStartDate = new SqlParameter("@start_date", SqlDbType.DateTime);
            parmStartDate.Value = startdate;

            SqlParameter parmEndDate = new SqlParameter("@end_date", SqlDbType.DateTime);
            parmEndDate.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
                parmStartDate,
                parmEndDate,
                parmUserType,
                parmDeptId
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxOrderId = reader.GetOrdinal("order_id");
                    int idxItemId = reader.GetOrdinal("item_id");
                    int idxDateOrdered = reader.GetOrdinal("order_when");
                    int idxDateShipped = reader.GetOrdinal("ship_date");
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxQtyOrdered = reader.GetOrdinal("qty_ordered");
                    int idxValue = reader.GetOrdinal("Value");
                    int idxCost = reader.GetOrdinal("Cost");
                    int idxDept = reader.GetOrdinal("department");

                    // address info
                    int idxCompany = reader.GetOrdinal("company");
                    int idxTitle = reader.GetOrdinal("title");
                    int idxAddress1 = reader.GetOrdinal("address_1");
                    int idxAddress2 = reader.GetOrdinal("address_2");
                    int idxAddress3 = reader.GetOrdinal("address_3");
                    int idxCity = reader.GetOrdinal("city");
                    int idxState = reader.GetOrdinal("state");
                    int idxCountry = reader.GetOrdinal("country");
                    int idxZip = reader.GetOrdinal("zip");
                    int idxBusPhone = reader.GetOrdinal("bus_phone");
                    int idxHomePhone = reader.GetOrdinal("home_phone");
                    int idxFaxPhone = reader.GetOrdinal("fax_phone");

                    while (reader.Read())
                    {
                        JuniperPODReportInfo cr = new JuniperPODReportInfo();

                        cr.OrderId = NCI(reader[idxOrderId]).Value;
                        cr.DateOrdered = NCD(reader[idxDateOrdered]);
                        cr.DateShipped = NCD(reader[idxDateShipped]);
                        cr.UserType = NCS(reader[idxUserType]);
                        cr.FirstName = NCS(reader[idxFirstName]);
                        cr.LastName = NCS(reader[idxLastName]);
                        cr.ItemID = NCS(reader[idxItemId]);
                        cr.QtyOrdered = NCI(reader[idxQtyOrdered]);
                        cr.Value = NCDcm(reader[idxValue]);
                        cr.Cost = NCDcm(reader[idxCost]);
                        cr.Department = NCS(reader[idxDept]);

                        // address info
                        cr.Address.Company = NCS(reader[idxCompany], "");
                        cr.Address.Title = NCS(reader[idxTitle], "");
                        cr.Address.Address1 = NCS(reader[idxAddress1], "");
                        cr.Address.Address2 = NCS(reader[idxAddress2], "");
                        cr.Address.Address3 = NCS(reader[idxAddress3], "");
                        cr.Address.City = NCS(reader[idxCity], "");
                        cr.Address.State = NCS(reader[idxState], "");
                        cr.Address.Country = NCS(reader[idxCountry], "");
                        cr.Address.Zip = NCS(reader[idxZip], "");
                        cr.Address.BusPhone = NCS(reader[idxBusPhone], "");
                        cr.Address.HomePhone = NCS(reader[idxHomePhone], "");
                        cr.Address.FaxPhone = NCS(reader[idxFaxPhone], "");

                        partReportList.Add(HideNulls(cr));
                    }
                }
                reader.Close();
            }

            return partReportList.ToArray();
        }

        static JuniperPODReportInfo HideNulls(JuniperPODReportInfo crli)
        {
            if (crli.Value.HasValue == false) { crli.Value = 0m; }
            if (crli.Cost.HasValue == false) { crli.Cost = 0m; }
            if (crli.QtyOrdered.HasValue == false) { crli.QtyOrdered = 0; }
            if (crli.Department == null) { crli.Department = ""; }

            return crli;
        }
    }
}
