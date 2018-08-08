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
    public class JuniperCostReportData : DataAccess
    {
        static public JuniperCostReportInfo[] GetCostReportHeaders(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype)
        {
            List<JuniperCostReportInfo> costReportList = new List<JuniperCostReportInfo>();

			string sql = String.Format(""
				+ "SELECT oh.*,p.user_type,p.region,p.last_name,p.first_name,address.* \n"
				+ "FROM order_head AS oh, person AS p \n"
                + "LEFT JOIN address on address.person_id = p.person_id and address.store_id = p.store_id \n"
				+ "WHERE \n"
				+ "	(oh.store_id = @store_id) AND \n"
                + "	(p.store_id = oh.store_id) AND \n"
                + "	(p.person_id = oh.order_for) AND \n"
                + "	(oh.order_when > @start_date) AND \n"
                + "	(oh.order_source = 'Web 2.0 order') AND \n"
                + "	(oh.status <> 'D') AND \n"
                + "	(oh.order_when < @end_date) \n"
			);

            if (string.IsNullOrEmpty(usertype) == false)
            {
                sql += "AND (p.user_type = @usertype) \n";
            }

            if (deptid > 0)
            {
                sql += "AND oh.order_id in (select order_id from order_line where store_id = @store_id and item_id in (select item_id from item where store_id = @store_id and product_id in (select product_id from dept_product where store_id = @store_id and dept_id = @deptid)))";
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

			using(SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms)) {
				if(reader.HasRows) {
					int idxOrderId = reader.GetOrdinal("order_id");
                    int idxDateOrdered = reader.GetOrdinal("order_when");
                    int idxShipDate = reader.GetOrdinal("ship_date");
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxRegion = reader.GetOrdinal("region");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxStatus = reader.GetOrdinal("status");
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

					while(reader.Read()) {
                        JuniperCostReportInfo cr = new JuniperCostReportInfo();

                        cr.OrderId = NCI(reader[idxOrderId]).Value;
                        cr.DateOrdered = NCD(reader[idxDateOrdered]);
                        cr.ShipDate = NCD(reader[idxShipDate]);
                        cr.UserType = NCS(reader[idxUserType]);
                        cr.FirstName = NCS(reader[idxFirstName]);
                        cr.LastName = NCS(reader[idxLastName]);
                        cr.Region = NCS(reader[idxRegion]);
                        cr.Status = NCS(reader[idxStatus]);
                        cr.Department = NCS(reader[idxDept], "");

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

                        costReportList.Add(HideNulls(cr));
					}
				}
				reader.Close();
			}

            return costReportList.ToArray();
		}

        static public JuniperCostReportLineInfo[] GetCostReportOrderLines(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype)
        {
            List<JuniperCostReportLineInfo> costOrderLinesList = new List<JuniperCostReportLineInfo>();

            string sql = String.Format(""
                + "SELECT ol.* \n"
                + "FROM order_line AS ol, order_head AS oh, person AS p \n"
                + "WHERE \n"
                + "	(ol.store_id = @store_id) AND \n"
                + "	(p.store_id = ol.store_id) AND \n"
                + "	(oh.store_id = ol.store_id) AND \n"
                + "	(ol.order_id = oh.order_id) AND \n"
                + "	(p.person_id = oh.person_id) AND \n"
                + "	(oh.order_when > @start_date) AND \n"
                + "	(oh.order_source = 'Web 2.0 order') AND \n"
                + "	(oh.order_when < @end_date) \n"
            );

            if (string.IsNullOrEmpty(usertype) == false)
            {
                sql += "AND (p.user_type = @usertype) \n";
            }

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
                parmUserType
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxOrderId = reader.GetOrdinal("order_id");
                    int idxItemId = reader.GetOrdinal("item_id");
                    int idxQtyOrdered = reader.GetOrdinal("qty_ordered");
                    int idxQtyShipped = reader.GetOrdinal("qty_shipped");
                    int idxInvCost = reader.GetOrdinal("inventory_cost");
                    int idxPrice = reader.GetOrdinal("unit_price");

                    while (reader.Read())
                    {
                        JuniperCostReportLineInfo crl = new JuniperCostReportLineInfo();

                        crl.OrderId = NCI(reader[idxOrderId]).Value;
                        crl.ItemId = NCS(reader[idxItemId]);
                        crl.Qty = NCI(reader[idxQtyOrdered]);
                        crl.QtyShipped = NCI(reader[idxQtyShipped]);
                        crl.Value = NCDcm(reader[idxInvCost]);
                        crl.Cost = NCDcm(reader[idxPrice]);

                        costOrderLinesList.Add(HideNulls(crl));
                    }
                }
                reader.Close();
            }

            return costOrderLinesList.ToArray();
        }

        static JuniperCostReportLineInfo HideNulls(JuniperCostReportLineInfo crli)
        {
            if (crli.Value.HasValue == false) { crli.Value = 0m; }
            if (crli.Cost.HasValue == false) { crli.Cost = 0m; }
            if (crli.Qty.HasValue == false) { crli.Qty = 0; }

            return crli;
        }

        static JuniperCostReportInfo HideNulls(JuniperCostReportInfo cr)
        {
            if (cr.Region == null) { cr.Region = ""; }
            if (cr.UserType == null) { cr.UserType = ""; }

            return cr;
        }
    }

    public class JuniperActiveUsersReportData : DataAccess
    {
        static public JuniperActiveUserReportInfo[] GetActiveUsersReport(int? storeId, DateTime startdate, DateTime enddate, bool SSOUsers)
        {
            List<JuniperActiveUserReportInfo> LinesList = new List<JuniperActiveUserReportInfo>();

            string sql = String.Format(""
                + "select user_type,count(user_type) as count from person where store_id = @store_id and active_flag = 1 AND \n"
                + "	(current_login_time > @start_date) AND \n"
                + "	(current_login_time < @end_date) \n"
            );

            if (SSOUsers)
            {
                sql += " AND (login_source = 'SSO') \n";
            }

            sql += " group by user_type \n";

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
            parmStoreId.Value = storeId.Value;

            SqlParameter parmStartDate = new SqlParameter("@start_date", SqlDbType.DateTime);
            parmStartDate.Value = startdate;

            SqlParameter parmEndDate = new SqlParameter("@end_date", SqlDbType.DateTime);
            parmEndDate.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
                parmStartDate,
                parmEndDate
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxCount = reader.GetOrdinal("count");

                    while (reader.Read())
                    {
                        JuniperActiveUserReportInfo crl = new JuniperActiveUserReportInfo();

                        crl.UserType = NCS(reader[idxUserType]);
                        crl.Count = NCI(reader[idxCount]).Value;
                        
                        LinesList.Add(crl);
                    }
                }
                reader.Close();
            }

            return LinesList.ToArray();
        }

        static public JuniperActiveUsersInfo[] GetJuniperActiveUsers(int? storeId, DateTime startdate, DateTime enddate, bool SSOUsers)
        {
            List<JuniperActiveUsersInfo> LinesList = new List<JuniperActiveUsersInfo>();

            string sql = String.Format(""
                + "select user_type,current_login_time,first_name,last_name,department,email,address.* from person,address where person.store_id = @store_id and address.store_id = person.store_id and person.person_id = address.person_id and person.active_flag = 1 AND \n"
                + "	(person.current_login_time > @start_date) AND \n"
                + "	(person.current_login_time < @end_date) \n"
            );

            if (SSOUsers)
            {
                sql += " AND (person.login_source = 'SSO') \n";
            }

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
            parmStoreId.Value = storeId.Value;

            SqlParameter parmStartDate = new SqlParameter("@start_date", SqlDbType.DateTime);
            parmStartDate.Value = startdate;

            SqlParameter parmEndDate = new SqlParameter("@end_date", SqlDbType.DateTime);
            parmEndDate.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
                parmStartDate,
                parmEndDate
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxDept = reader.GetOrdinal("department");
                    int idxEmail = reader.GetOrdinal("email");
                    int idxcurrent_login_time = reader.GetOrdinal("current_login_time");

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
                        JuniperActiveUsersInfo cr = new JuniperActiveUsersInfo();
                        cr.UserType = NCS(reader[idxUserType]);
                        cr.FirstName = NCS(reader[idxFirstName], "");
                        cr.LastName = NCS(reader[idxLastName], "");
                        cr.Department = NCS(reader[idxDept], "");
                        cr.Email = NCS(reader[idxEmail], "");
                        cr.LastLogin = NCD(reader[idxcurrent_login_time]);

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

                        LinesList.Add(cr);
                    }
                }
                reader.Close();
            }

            return LinesList.ToArray();
        }
    }

    public class JuniperOrderedItemsReportData : DataAccess
    {
        static public JuniperOrderedItemsInfo[] GetJuniperOrderedItems(int? storeId, DateTime startdate, DateTime enddate)
        {
            List<JuniperOrderedItemsInfo> LinesList = new List<JuniperOrderedItemsInfo>();

            string sql = String.Format(""
                + "select order_line.item_id,(select product.name from product where product.store_id = @store_id and product_id = (select item.product_id from item where item.store_id = @store_id and item.item_id = order_line.item_id)) as ProductName,count(order_line.item_id) as ItemCount,sum(order_line.qty_ordered) as TotalQty,sum(order_line.unit_price*order_line.qty_ordered) as TotalPrice from order_line,order_head where order_line.store_id = @store_id and order_line.store_id = order_head.store_id and order_line.order_id = order_head.order_id and order_head.status <> 'D' AND \n"
                + "	(order_head.order_when > @start_date) AND \n"
                + "	(order_head.order_when < @end_date) \n"
            );

            sql += " group by order_line.item_id \n";
            sql += " order by TotalQty desc \n";

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
            parmStoreId.Value = storeId.Value;

            SqlParameter parmStartDate = new SqlParameter("@start_date", SqlDbType.DateTime);
            parmStartDate.Value = startdate;

            SqlParameter parmEndDate = new SqlParameter("@end_date", SqlDbType.DateTime);
            parmEndDate.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
                parmStartDate,
                parmEndDate
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxItemId = reader.GetOrdinal("item_id");
                    int idxProductName = reader.GetOrdinal("ProductName");
                    int idxItemCount = reader.GetOrdinal("ItemCount");
                    int idxTotalQty = reader.GetOrdinal("TotalQty");
                    int idxTotalPrice = reader.GetOrdinal("TotalPrice");

                    while (reader.Read())
                    {
                        JuniperOrderedItemsInfo crl = new JuniperOrderedItemsInfo();

                        crl.ItemID = NCS(reader[idxItemId]);
                        crl.ProductName = NCS(reader[idxProductName]);
                        crl.ItemCount = NCI(reader[idxItemCount]).Value;
                        crl.TotalQty = NCI(reader[idxTotalQty]).Value;
                        crl.TotalPrice = NCDcm(reader[idxTotalPrice]).Value;

                        LinesList.Add(crl);
                    }
                }
                reader.Close();
            }

            return LinesList.ToArray();
        }
    }
}
