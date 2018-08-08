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
    /// associated with the Generic Cost Report.
    /// </summary>
    public class GenericPODReportData : DataAccess
    {

        public static GenericPODReportInfo[] GetPODReportData(DateTime startdate, DateTime enddate)
        {
            List<GenericPODReportInfo> partReportList = new List<GenericPODReportInfo>();

            /*          
            string sql = @"
            SELECT * FROM
            (                
                SELECT oh.*, item_id, qty_ordered, qty_shipped, inventory_cost, base_onf_cost, onf_cost, multiplier_onf_cost, page_count FROM
                (SELECT * from order_head) oh
                INNER JOIN
                (
                    SELECT ol.*, i.onf_cost as base_onf_cost, i.page_count FROM
                    (SELECT * from order_line) ol
                    INNER JOIN
                    (SELECT * from item) i
                    ON ol.store_id = i.store_id AND ol.item_id = i.item_id
                ) oli
                ON oh.store_id = oli.store_id AND oh.order_id = oli.order_id  AND oh.order_suffix = oli.order_suffix
                WHERE oh.order_source = 'Web 2.0 order' AND oh.status <> 'D' and oli.print_on_demand_flag = 1 
            ) ohli
            INNER JOIN
            (
                SELECT user_type, last_name, first_name, a.* FROM
                (SELECT * FROM person) p
                LEFT OUTER JOIN
                (SELECT * FROM address) a
                ON p.person_id = a.person_id AND p.store_id = a.store_id
            ) pa
            ON ohli.store_id = pa.store_id AND ohli.order_for = pa.person_id
            WHERE ohli.order_when > @start_date AND ohli.order_when < @end_date 
            ";
            */

            string sql = @"
            SELECT oh.*, ol.item_id, ol.qty_ordered, ol.qty_shipped, ol.inventory_cost, i.onf_cost base_onf_cost, ol.onf_cost, ol.multiplier_onf_cost, i.page_count, pp.user_type, p.last_name, p.first_name, a.*, s.store_id, s.name store_name
            FROM  order_head oh
            INNER JOIN store s ON oh.store_id = s.store_id
            INNER JOIN order_line ol ON oh.store_id = ol.store_id
            AND oh.order_id=ol.order_id AND oh.order_suffix = ol.order_suffix
            INNER JOIN item i ON ol.store_id = i.store_id AND ol.item_id = i.item_id
            INNER JOIN person p ON oh.store_id = p.store_id AND oh.order_for = p.person_id
            INNER JOIN person pp ON oh.store_id = pp.store_id AND oh.person_id = pp.person_id
            LEFT OUTER JOIN [address] a ON oh.store_id = a.store_id AND p.person_id = a.person_id AND oh.send_to_address = a.address_id
            WHERE  oh.order_source = 'Web 2.0 order' AND oh.status <> 'D' AND ol.print_on_demand_flag = 1 AND oh.order_when !< @start_date AND oh.order_when !> @end_date
            ORDER BY oh.store_id
            ";

            TimeSpan ts = new TimeSpan(23, 59, 59);
            enddate = enddate.Date + ts;

            SqlParameter parmStartDate = new SqlParameter("@start_date", SqlDbType.DateTime);
            parmStartDate.Value = startdate;

            SqlParameter parmEndDate = new SqlParameter("@end_date", SqlDbType.DateTime);
            parmEndDate.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[]{
                parmStartDate,
                parmEndDate
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
                    int idxInventoryCost = reader.GetOrdinal("inventory_cost");
                    int idxOnfCostBase = reader.GetOrdinal("base_onf_cost");
                    int idxOnfCost = reader.GetOrdinal("onf_cost");
                    int idxOnfCostMultiplier = reader.GetOrdinal("multiplier_onf_cost");
                    int idxPrintLocationId = reader.GetOrdinal("print_location_id");
                    int idxFulfillmentLocationId = reader.GetOrdinal("fulfillment_location_id");
                    int idxPageCount = reader.GetOrdinal("page_count");
                    int idxDept = reader.GetOrdinal("department");
                    int idxCustomerOrderNumber = reader.GetOrdinal("cust_order_no");

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

                    int idxStoreId = reader.GetOrdinal("store_id");
                    int idxStoreName = reader.GetOrdinal("store_name");

                    while (reader.Read())
                    {
                        GenericPODReportInfo cr = new GenericPODReportInfo();

                        cr.StoreId = NCI(reader[idxStoreId]).Value;
                        cr.StoreName = NCS(reader[idxStoreName]);
                        cr.OrderId = NCI(reader[idxOrderId]).Value;
                        cr.DateOrdered = NCD(reader[idxDateOrdered]);
                        cr.DateShipped = NCD(reader[idxDateShipped]);
                        cr.UserType = NCS(reader[idxUserType]);
                        cr.FirstName = NCS(reader[idxFirstName]);
                        cr.LastName = NCS(reader[idxLastName]);
                        cr.ItemID = NCS(reader[idxItemId]);
                        cr.QtyOrdered = NCI(reader[idxQtyOrdered]);
                        cr.InventoryCost = NCDcm(reader[idxInventoryCost]);
                        cr.OnfCostBase = NCDcm(reader[idxOnfCostBase]);
                        cr.OnfCost = NCDcm(reader[idxOnfCost]);
                        cr.OnfCostMultiplier = NCDcm(reader[idxOnfCostMultiplier]);
                        cr.PrintLocationId = NCS(reader[idxPrintLocationId]);
                        cr.FulfillmentLocationId = NCS(reader[idxFulfillmentLocationId]);
                        cr.PageCount = NCI(reader[idxPageCount]);
                        cr.Department = NCS(reader[idxDept]);
                        cr.CustomerOrderNumber = NCS(reader[idxCustomerOrderNumber]);

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

        static public GenericPODReportInfo[] GetPODReportData(int? storeId, DateTime startdate, DateTime enddate, int deptid, string usertype)
        {
            List<GenericPODReportInfo> partReportList = new List<GenericPODReportInfo>();

            string sql = @"
            SELECT oh.*,
                   ol.item_id,
                   ol.qty_ordered,
                   ol.qty_shipped,
                   ol.inventory_cost,
                   i.onf_cost base_onf_cost,
                   ol.onf_cost,
                   ol.multiplier_onf_cost,
                   i.page_count,
                   pp.user_type,
                   p.last_name,
                   p.first_name,
                   a.*,
                   s.store_id,
                   s.name store_name,
                   aship.country AS 'ship_to_country',
                   aship.state AS 'ship_to_state'
            FROM  order_head oh
            INNER JOIN store s ON oh.store_id = s.store_id
            INNER JOIN order_line ol ON oh.store_id = ol.store_id
	            AND oh.order_id=ol.order_id
	            AND oh.order_suffix = ol.order_suffix
            INNER JOIN item i ON ol.store_id = i.store_id
	            AND ol.item_id = i.item_id
            INNER JOIN person p ON oh.store_id = p.store_id
	            AND oh.order_for = p.person_id
            INNER JOIN person pp on oh.store_id = pp.store_id
                AND oh.person_id = pp.person_id
            INNER JOIN person pship ON oh.store_id = pship.store_id
	            AND oh.send_to_person = pship.person_id	 
            LEFT OUTER JOIN [address] aship ON oh.store_id = aship.store_id
	            AND pship.person_id = aship.person_id
            LEFT OUTER JOIN [address] a ON oh.store_id = a.store_id
	            AND p.person_id = a.person_id
	            AND oh.send_to_address = a.address_id
            WHERE  oh.store_id = @store_id
                   AND oh.order_source = 'Web 2.0 order'
                   AND oh.status <> 'D'
                   AND ol.print_on_demand_flag = 1
                   AND oh.order_when > @start_date
                   AND oh.order_when < @end_date
            ";

            if (string.IsNullOrEmpty(usertype) == false)
            {
                sql += " AND (pp.user_type = @usertype) \n";
            }

            if (deptid > 0)
            {
                sql += " AND oh.order_id in (select order_id from order_line where store_id = @store_id AND item_id in (select item_id from item where store_id = @store_id AND product_id in (select product_id from dept_product where store_id = @store_id AND dept_id = @deptid)))";
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
                    int idxInventoryCost = reader.GetOrdinal("inventory_cost");
                    int idxOnfCostBase = reader.GetOrdinal("base_onf_cost");
                    int idxOnfCost = reader.GetOrdinal("onf_cost");
                    int idxOnfCostMultiplier = reader.GetOrdinal("multiplier_onf_cost");
                    int idxPrintLocationId = reader.GetOrdinal("print_location_id");
                    int idxPageCount = reader.GetOrdinal("page_count");
                    int idxDept = reader.GetOrdinal("department");
                    int idxCustomerOrderNumber = reader.GetOrdinal("cust_order_no");
                    int idxFulfillmentLocationId = reader.GetOrdinal("fulfillment_location_id");
                    int idxCostCenter = reader.GetOrdinal("cost_center");

                    int idxShipToCountry = reader.GetOrdinal("ship_to_country");
                    int idxShipToState = reader.GetOrdinal("ship_to_state");

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
                        GenericPODReportInfo cr = new GenericPODReportInfo();

                        cr.OrderId = NCI(reader[idxOrderId]).Value;
                        cr.DateOrdered = NCD(reader[idxDateOrdered]);
                        cr.DateShipped = NCD(reader[idxDateShipped]);
                        cr.UserType = NCS(reader[idxUserType]);
                        cr.FirstName = NCS(reader[idxFirstName]);
                        cr.LastName = NCS(reader[idxLastName]);
                        cr.ItemID = NCS(reader[idxItemId]);
                        cr.QtyOrdered = NCI(reader[idxQtyOrdered]);
                        cr.InventoryCost = NCDcm(reader[idxInventoryCost]);
                        cr.OnfCostBase = NCDcm(reader[idxOnfCostBase]);
                        cr.OnfCost = NCDcm(reader[idxOnfCost]);
                        cr.OnfCostMultiplier = NCDcm(reader[idxOnfCostMultiplier]);
                        cr.PrintLocationId = NCS(reader[idxPrintLocationId]);
                        cr.FulfillmentLocationId = NCS(reader[idxFulfillmentLocationId]);
                        cr.CostCenter = NCS(reader[idxCostCenter]);
                        cr.PageCount = NCI(reader[idxPageCount]);
                        cr.Department = NCS(reader[idxDept]);
                        cr.CustomerOrderNumber = NCS(reader[idxCustomerOrderNumber]);

                        cr.ShipToCountry = NCS(reader[idxShipToCountry]);
                        cr.ShipToState = NCS(reader[idxShipToState]);

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


        static GenericPODReportInfo HideNulls(GenericPODReportInfo crli)
        {
            if (crli.PrintLocationId == null) { crli.PrintLocationId = String.Empty; }
            if (crli.FulfillmentLocationId == null) { crli.FulfillmentLocationId = string.Empty; }
            if (crli.CostCenter == null) { crli.CostCenter = string.Empty; }
            if (crli.InventoryCost.HasValue == false) { crli.InventoryCost = 0m; }
            if (crli.OnfCostBase.HasValue == false) { crli.OnfCostBase = 0m; }
            if (crli.QtyOrdered.HasValue == false) { crli.QtyOrdered = 0; }
            if (crli.PageCount.HasValue == false) { crli.PageCount = 0; }
            if (crli.Department == null) { crli.Department = ""; }
            if (crli.CustomerOrderNumber == null) { crli.CustomerOrderNumber = ""; }

            return crli;
        }
    }
}