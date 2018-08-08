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
	public class ItemData : OnfDAL.DataAccess
    {
        public static void Delete(int? storeID, string itemID)
        {
            string sql;

            sql = "DELETE from item "
            + "WHERE store_id = " + Escape(storeID.ToString()) + " "
            + "AND item_id = '" + Escape(itemID.ToString()) + "'";


            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql);

        }

        public static void Delete(ItemInfo item)
        {
            int? storeID = item.StoreId;
            string itemID = item.ItemId;
            

            Delete(storeID, itemID);

        }


		public static Dictionary<string, ItemInfo> GetItemIdsAndItems(int storeId, string[] itemIds) {
			string itemId;
			Dictionary<string, ItemInfo> itemData = new Dictionary<string, ItemInfo>();

			ItemInfo[] items = GetItem(storeId, itemIds);
			if(items != null && items.Length > 0) {
				foreach(ItemInfo ii in items) {
					itemId = ii.ItemId;
					itemData.Add(itemId, ii);
				}
			}

			return itemData;
		}


		public static ItemInfo[] GetItem(int storeId, string[] itemIds) {
			List<ItemInfo> itemList = new List<ItemInfo>();

			// ensure valid item-ids
			if(itemIds != null && itemIds.Length > 0) {
				for(int i = 0; i < itemIds.Length; i++) {
					itemIds[i] = itemIds[i].Replace("'", "''");
				}
			}

			string sql = String.Format(""
				+ "SELECT i.* \n"
				+ "FROM item AS i \n"
				+ "WHERE \n"
				+ "	(i.store_id = @store_id) \n"
				+ "	AND (i.item_id IN('{0}')) \n",
				String.Join("', '", itemIds)
			);

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
			parmStoreId.Value = storeId;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

			using(SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms)) {
				if(reader.HasRows) {
					int idxStoreId = reader.GetOrdinal("store_id");
					int idxItemId = reader.GetOrdinal("item_id");
					int idxProductId = reader.GetOrdinal("product_id");
					int idxSqn = reader.GetOrdinal("sqn");
					int idxPickLoc = reader.GetOrdinal("pick_loc");
					int idxPrice = reader.GetOrdinal("price");
					int idxSalePrice = reader.GetOrdinal("sale_price");
					int idxShippingCharge = reader.GetOrdinal("shipping_charge");
					int idxReorderPoint = reader.GetOrdinal("reorder_point");
					int idxReorderQty = reader.GetOrdinal("reorder_qty");
                    int idxPageCount = reader.GetOrdinal("page_count");
                    int idxPartStatus = reader.GetOrdinal("part_status");
					int idxAttribute1Value = reader.GetOrdinal("attribute_1_value");
					int idxAttribute2Value = reader.GetOrdinal("attribute_2_value");
					int idxAttribute3Value = reader.GetOrdinal("attribute_3_value");
					int idxQtyReserved = reader.GetOrdinal("qty_reserved");
					int idxUseupFlag = reader.GetOrdinal("useup_flag");
					int idxActiveFlag = reader.GetOrdinal("active_flag");
					int idxItemContent = reader.GetOrdinal("item_content");
					int idxDefaultContent = reader.GetOrdinal("default_content");
					int idxCustomContentFlag = reader.GetOrdinal("custom_content_flag");
                    int idxOnfCost = reader.GetOrdinal("onf_cost");
					int idxInventoryCost = reader.GetOrdinal("inventory_cost");
					int idxInventoryOwner = reader.GetOrdinal("inventory_owner");
					int idxContentOwner = reader.GetOrdinal("content_owner");
					int idxQtyStaged = reader.GetOrdinal("qty_staged");
					int idxPrintOnDemandFlag = reader.GetOrdinal("print_on_demand_flag");
					int idxCdFulfillmentFlag = reader.GetOrdinal("cd_fulfillment_flag");
					int idxCdOnlyFlag = reader.GetOrdinal("cd_only_flag");
                    int idxWeight = reader.GetOrdinal("weight");
                    int idxPODOverRide = reader.GetOrdinal("POD_override_flag");
                    int idxRevision = reader.GetOrdinal("revision");
                    int idxRevisionDate = reader.GetOrdinal("revision_date");
                    int idxOnSecureFlag = reader.GetOrdinal("onSecure_flag");

					while(reader.Read()) {
						ItemInfo ii = new ItemInfo();

						ii.StoreId = NCI(reader[idxStoreId]);
						ii.ItemId = NCS(reader[idxItemId]);
						ii.ProductId = NCI(reader[idxProductId]);
						ii.Sqn = NCI(reader[idxSqn]);
						ii.PickLoc = NCS(reader[idxPickLoc]);
						ii.Price = NCDcm(reader[idxPrice]);
						ii.SalePrice = NCDcm(reader[idxSalePrice]);
						ii.ShippingCharge = NCDcm(reader[idxShippingCharge]);
						ii.ReorderPoint = NCI(reader[idxReorderPoint]);
						ii.ReorderQty = NCI(reader[idxReorderQty]);
                        ii.PageCount = NCI(reader[idxPageCount]);
                        ii.PartStatus = NCI(reader[idxPartStatus]);
						ii.Attribute1Value = NCS(reader[idxAttribute1Value]);
						ii.Attribute2Value = NCS(reader[idxAttribute2Value]);
						ii.Attribute3Value = NCS(reader[idxAttribute3Value]);
						ii.QtyReserved = NCI(reader[idxQtyReserved]);
						ii.UseupFlag = NCB(reader[idxUseupFlag]);
						ii.ActiveFlag = NCB(reader[idxActiveFlag]);
						ii.ItemContent = NCS(reader[idxItemContent]);
						ii.DefaultContent = NCS(reader[idxDefaultContent]);
						ii.CustomContentFlag = NCB(reader[idxCustomContentFlag]);
                        ii.OnfCost = NCDcm(reader[idxOnfCost]);
						ii.InventoryCost = NCDcm(reader[idxInventoryCost]);
						ii.InventoryOwner = NCS(reader[idxInventoryOwner]);
						ii.ContentOwner = NCS(reader[idxContentOwner]);
						ii.QtyStaged = NCI(reader[idxQtyStaged]);
						ii.PrintOnDemandFlag = NCB(reader[idxPrintOnDemandFlag]);
						ii.CdFulfillmentFlag = NCB(reader[idxCdFulfillmentFlag]);
						ii.CdOnlyFlag = NCB(reader[idxCdOnlyFlag]);
                        ii.weight = NCDcm(reader[idxWeight]);
                        ii.POD_OverrideFlag = NCB(reader[idxPODOverRide]);
                        ii.Revision = NCS(reader[idxRevision]);
                        ii.RevisionDate = NCD(reader[idxRevisionDate]);
                        ii.OnSecureFlag = NCB(reader[idxOnSecureFlag]);

						itemList.Add(ii);
					}
				}
				reader.Close();
			}

			return itemList.ToArray();
		}


        public static ItemInfo GetItem(int storeID, string itemID)
        { 
            string sql;
            int productID;
            

            sql = "SELECT product_id "
                + "FROM item "
                + "WHERE store_id = " + Escape(storeID.ToString()) + " "
                + "AND item_id = '" + Escape(itemID) + "' ";

            productID = (int) SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql);

            ItemInfo[] items = GetItem(storeID, productID);

            foreach (ItemInfo item in items)
            {
                if (item.ItemId == itemID)
                {
                    return item;
                }
            }

            return null;
                        
        }

        public static ItemInfo[] GetItem(int storeID, int productID)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "SELECT * "
            + "FROM item "
            + "WHERE store_id = " + Escape(storeID.ToString()) + " "
            + "AND product_id = " + Escape(productID.ToString()) + " ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);


            while (d.Read())
            {
                ItemInfo al = new ItemInfo();

                al.StoreId = NCI(d["store_id"]);
                al.ItemId = NCS(d["item_id"]);
                al.ProductId = NCI(d["product_id"]);
                al.Sqn = NCI(d["sqn"]);
                al.PickLoc = NCS(d["pick_loc"]);
                al.Price = NCDcm(d["price"]);
                al.SalePrice = NCDcm(d["sale_price"]);
                al.ShippingCharge = NCDcm(d["shipping_charge"]);
                al.ReorderPoint = NCI(d["reorder_point"]);
                al.ReorderQty = NCI(d["reorder_qty"]);
                al.PageCount = NCI(d["page_count"]);
                al.PartStatus = NCI(d["part_status"]);
                al.Attribute1Value = NCS(d["attribute_1_value"]);
                al.Attribute2Value = NCS(d["attribute_2_value"]);
                al.Attribute3Value = NCS(d["attribute_3_value"]);
                al.QtyReserved = NCI(d["qty_reserved"]);
                al.UseupFlag = NCB(d["useup_flag"]);
                al.ActiveFlag = NCB(d["active_flag"]);
                al.ItemContent = NCS(d["item_content"]);
                al.DefaultContent = NCS(d["default_content"]);
                al.CustomContentFlag = NCB(d["custom_content_flag"]);
                al.OnfCost = NCDcm(d["onf_cost"]);
                al.InventoryCost = NCDcm(d["inventory_cost"]);
                al.InventoryOwner = NCS(d["inventory_owner"]);
                al.ContentOwner = NCS(d["content_owner"]);
                al.QtyStaged = NCI(d["qty_staged"]);
                al.PrintOnDemandFlag = NCB(d["print_on_demand_flag"]);
                al.CdFulfillmentFlag = NCB(d["cd_fulfillment_flag"]);
                al.CdOnlyFlag = NCB(d["cd_only_flag"]);
                al.weight = NCDcm(d["weight"]);
                al.POD_OverrideFlag = NCB(d["POD_override_flag"]);
                al.Revision = NCS(d["revision"]);
                al.RevisionDate = NCD(d["revision_date"]);
                al.OnSecureFlag = NCB(d["onSecure_flag"]);

                c.Add(al);


            }

            d.Close();
            return (ItemInfo[])c.ToArray(typeof(ItemInfo));

        }
        /// <summary>
        /// Get all items for a store
        /// </summary>
        /// <param name="storeID">Store</param>
        /// <returns></returns>
        public static ItemInfo[] GetItem(int storeID)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "SELECT * "
            + "FROM item "
            + "WHERE store_id = " + Escape(storeID.ToString()) + " ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);


            while (d.Read())
            {
                ItemInfo al = new ItemInfo();

                al.StoreId = NCI(d["store_id"]);
                al.ItemId = NCS(d["item_id"]);
                al.ProductId = NCI(d["product_id"]);
                al.Sqn = NCI(d["sqn"]);
                al.PickLoc = NCS(d["pick_loc"]);
                al.Price = NCDcm(d["price"]);
                al.SalePrice = NCDcm(d["sale_price"]);
                al.ShippingCharge = NCDcm(d["shipping_charge"]);
                al.ReorderPoint = NCI(d["reorder_point"]);
                al.ReorderQty = NCI(d["reorder_qty"]);
                al.PageCount = NCI(d["page_count"]);
                al.PartStatus = NCI(d["part_status"]);
                al.Attribute1Value = NCS(d["attribute_1_value"]);
                al.Attribute2Value = NCS(d["attribute_2_value"]);
                al.Attribute3Value = NCS(d["attribute_3_value"]);
                al.QtyReserved = NCI(d["qty_reserved"]);
                al.UseupFlag = NCB(d["useup_flag"]);
                al.ActiveFlag = NCB(d["active_flag"]);
                al.ItemContent = NCS(d["item_content"]);
                al.DefaultContent = NCS(d["default_content"]);
                al.CustomContentFlag = NCB(d["custom_content_flag"]);
                al.OnfCost = NCDcm(d["onf_cost"]);
                al.InventoryCost = NCDcm(d["inventory_cost"]);
                al.InventoryOwner = NCS(d["inventory_owner"]);
                al.ContentOwner = NCS(d["content_owner"]);
                al.QtyStaged = NCI(d["qty_staged"]);
                al.PrintOnDemandFlag = NCB(d["print_on_demand_flag"]);
                al.CdFulfillmentFlag = NCB(d["cd_fulfillment_flag"]);
                al.CdOnlyFlag = NCB(d["cd_only_flag"]);
                al.weight = NCDcm(d["weight"]);
                al.POD_OverrideFlag = NCB(d["POD_override_flag"]);
                al.Revision = NCS(d["revision"]);
                al.RevisionDate = NCD(d["revision_date"]);
                al.OnSecureFlag = NCB(d["onSecure_flag"]);
                c.Add(al);


            }

            d.Close();
            return (ItemInfo[])c.ToArray(typeof(ItemInfo));

        }

        /// <summary>
        /// Get list of items with optional filtering on department or subdepartment
        /// Note: subdepartment implies department, so it's either one or the other
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="deptid"></param>
        /// <param name="subdeptid"></param>
        /// <returns></returns>
        public static ItemInfo[] GetItem(int storeID, int deptid, int subdeptid)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            if (subdeptid != 0)
            {
                sql = "select i.* "
                    + "from dept d "
                    + "inner join dept_product dp on d.store_id = dp.store_id "
                    + "   and d.dept_id = dp.dept_id "
                    + "inner join item i on dp.store_id = i.store_id "
                    + "   and dp.product_id = i.product_id "
                    + "where d.store_id = " + Escape(storeID.ToString()) + " "
                    + "   and d.sub_dept_id = " + Escape(subdeptid.ToString());
            }
            else if (deptid != 0)
            {
                sql = "select i.* "
                    + "from dept d "
                    + "inner join dept_product dp on d.store_id = dp.store_id "
                    + "   and d.dept_id = dp.dept_id "
                    + "inner join item i on dp.store_id = i.store_id "
                    + "   and dp.product_id = i.product_id "
                    + "where d.store_id = " + Escape(storeID.ToString()) + " "
                    + "   and d.dept_id = " + Escape(deptid.ToString());
            }
            else
            {
                sql = "SELECT * "
                + "FROM item "
                + "WHERE store_id = " + Escape(storeID.ToString());
            }

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);


            while (d.Read())
            {
                ItemInfo al = new ItemInfo();

                al.StoreId = NCI(d["store_id"]);
                al.ItemId = NCS(d["item_id"]);
                al.ProductId = NCI(d["product_id"]);
                al.Sqn = NCI(d["sqn"]);
                al.PickLoc = NCS(d["pick_loc"]);
                al.Price = NCDcm(d["price"]);
                al.SalePrice = NCDcm(d["sale_price"]);
                al.ShippingCharge = NCDcm(d["shipping_charge"]);
                al.ReorderPoint = NCI(d["reorder_point"]);
                al.ReorderQty = NCI(d["reorder_qty"]);
                al.PageCount = NCI(d["page_count"]);
                al.PartStatus = NCI(d["part_status"]);
                al.Attribute1Value = NCS(d["attribute_1_value"]);
                al.Attribute2Value = NCS(d["attribute_2_value"]);
                al.Attribute3Value = NCS(d["attribute_3_value"]);
                al.QtyReserved = NCI(d["qty_reserved"]);
                al.UseupFlag = NCB(d["useup_flag"]);
                al.ActiveFlag = NCB(d["active_flag"]);
                al.ItemContent = NCS(d["item_content"]);
                al.DefaultContent = NCS(d["default_content"]);
                al.CustomContentFlag = NCB(d["custom_content_flag"]);
                al.OnfCost = NCDcm(d["onf_cost"]);
                al.InventoryCost = NCDcm(d["inventory_cost"]);
                al.InventoryOwner = NCS(d["inventory_owner"]);
                al.ContentOwner = NCS(d["content_owner"]);
                al.QtyStaged = NCI(d["qty_staged"]);
                al.PrintOnDemandFlag = NCB(d["print_on_demand_flag"]);
                al.CdFulfillmentFlag = NCB(d["cd_fulfillment_flag"]);
                al.CdOnlyFlag = NCB(d["cd_only_flag"]);
                al.weight = NCDcm(d["weight"]);
                al.POD_OverrideFlag = NCB(d["POD_override_flag"]);
                al.Revision = NCS(d["revision"]);
                al.RevisionDate = NCD(d["revision_date"]);
                al.OnSecureFlag = NCB(d["onSecure_flag"]);

                c.Add(al);
            }

            d.Close();
            return (ItemInfo[])c.ToArray(typeof(ItemInfo));

        }
  
        public static ItemInfo[] GetOnSecureItems(int storeID)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            sql = "SELECT * "
            + "FROM item "
            + "WHERE store_id = " + Escape(storeID.ToString()) + " "
            + "  AND onSecure_flag = 1 ";

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            while (d.Read())
            {
                ItemInfo al = new ItemInfo
                {
                    StoreId = NCI(d["store_id"]),
                    ItemId = NCS(d["item_id"]),
                    ProductId = NCI(d["product_id"]),
                    Sqn = NCI(d["sqn"]),
                    PickLoc = NCS(d["pick_loc"]),
                    Price = NCDcm(d["price"]),
                    SalePrice = NCDcm(d["sale_price"]),
                    ShippingCharge = NCDcm(d["shipping_charge"]),
                    ReorderPoint = NCI(d["reorder_point"]),
                    ReorderQty = NCI(d["reorder_qty"]),
                    PageCount = NCI(d["page_count"]),
                    PartStatus = NCI(d["part_status"]),
                    Attribute1Value = NCS(d["attribute_1_value"]),
                    Attribute2Value = NCS(d["attribute_2_value"]),
                    Attribute3Value = NCS(d["attribute_3_value"]),
                    QtyReserved = NCI(d["qty_reserved"]),
                    UseupFlag = NCB(d["useup_flag"]),
                    ActiveFlag = NCB(d["active_flag"]),
                    ItemContent = NCS(d["item_content"]),
                    DefaultContent = NCS(d["default_content"]),
                    CustomContentFlag = NCB(d["custom_content_flag"]),
                    InventoryCost = NCDcm(d["inventory_cost"]),
                    InventoryOwner = NCS(d["inventory_owner"]),
                    ContentOwner = NCS(d["content_owner"]),
                    QtyStaged = NCI(d["qty_staged"]),
                    PrintOnDemandFlag = NCB(d["print_on_demand_flag"]),
                    CdFulfillmentFlag = NCB(d["cd_fulfillment_flag"]),
                    CdOnlyFlag = NCB(d["cd_only_flag"]),
                    weight = NCDcm(d["weight"]),
                    POD_OverrideFlag = NCB(d["POD_override_flag"]),
                    Revision = NCS(d["revision"]),
                    RevisionDate = NCD(d["revision_date"])
                };

                c.Add(al);
            }

            d.Close();
            return (ItemInfo[])c.ToArray(typeof(ItemInfo));

        }

        /// <summary>
        /// Get list of items with optional filtering on department or subdepartment.
        /// Also, get a default item "(All)" for use in dropdown lists
        /// Note: subdepartment implies department, so it's either one or the other
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="deptid"></param>
        /// <param name="subdeptid"></param>
        /// <returns></returns>
        public static ItemInfo[] GetItemAndDefault(int storeID, int deptid, int subdeptid)
        {
            string sql = string.Empty;
            ArrayList c = new ArrayList();

            if (subdeptid != 0)
            {
                sql = "select i.* "
                    + "from dept_product dp "
                    + "inner join item i on dp.store_id = i.store_id "
                    + "   and dp.product_id = i.product_id "
                    + "where dp.store_id = " + Escape(storeID.ToString()) + " "
                    + "   and dp.sub_dept_id = " + Escape(subdeptid.ToString());
            }
            else if (deptid != 0)
            {
                sql = "select i.* "
                    + "from dept_product dp "
                    + "inner join item i on dp.store_id = i.store_id "
                    + "   and dp.product_id = i.product_id "
                    + "where dp.store_id = " + Escape(storeID.ToString()) + " "
                    + "   and dp.dept_id = " + Escape(deptid.ToString());
            }
            else
            {
                sql = "SELECT * "
                + "FROM item "
                + "WHERE store_id = " + Escape(storeID.ToString());
            }

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);

            // Add in the default item
            ItemInfo aldef = new ItemInfo();
            aldef.StoreId = storeID;
            aldef.ItemId = "(All)";
            aldef.ProductId = null;
            c.Add(aldef);

            while (d.Read())
            {
                ItemInfo al = new ItemInfo();

                al.StoreId = NCI(d["store_id"]);
                al.ItemId = NCS(d["item_id"]);
                al.ProductId = NCI(d["product_id"]);
                al.Sqn = NCI(d["sqn"]);
                al.PickLoc = NCS(d["pick_loc"]);
                al.Price = NCDcm(d["price"]);
                al.SalePrice = NCDcm(d["sale_price"]);
                al.ShippingCharge = NCDcm(d["shipping_charge"]);
                al.ReorderPoint = NCI(d["reorder_point"]);
                al.ReorderQty = NCI(d["reorder_qty"]);
                al.PageCount = NCI(d["page_count"]);
                al.PartStatus = NCI(d["part_status"]);
                al.Attribute1Value = NCS(d["attribute_1_value"]);
                al.Attribute2Value = NCS(d["attribute_2_value"]);
                al.Attribute3Value = NCS(d["attribute_3_value"]);
                al.QtyReserved = NCI(d["qty_reserved"]);
                al.UseupFlag = NCB(d["useup_flag"]);
                al.ActiveFlag = NCB(d["active_flag"]);
                al.ItemContent = NCS(d["item_content"]);
                al.DefaultContent = NCS(d["default_content"]);
                al.CustomContentFlag = NCB(d["custom_content_flag"]);
                al.OnfCost = NCDcm(d["onf_cost"]);
                al.InventoryCost = NCDcm(d["inventory_cost"]);
                al.InventoryOwner = NCS(d["inventory_owner"]);
                al.ContentOwner = NCS(d["content_owner"]);
                al.QtyStaged = NCI(d["qty_staged"]);
                al.PrintOnDemandFlag = NCB(d["print_on_demand_flag"]);
                al.CdFulfillmentFlag = NCB(d["cd_fulfillment_flag"]);
                al.CdOnlyFlag = NCB(d["cd_only_flag"]);
                al.weight = NCDcm(d["weight"]);
                al.POD_OverrideFlag = NCB(d["POD_override_flag"]);
                al.Revision = NCS(d["revision"]);
                al.RevisionDate = NCD(d["revision_date"]);
                al.OnSecureFlag = NCB(d["onSecure_flag"]);

                c.Add(al);


            }

            d.Close();
            return (ItemInfo[])c.ToArray(typeof(ItemInfo));

        }

        public static ItemInfo SaveItem(ItemInfo item)
        {
            string sql;
            bool itemExists = false;
            

                //check to see if item already exists.
                sql = "SELECT cast(count(item_id) as bit) "
                    + "FROM item "
                    + "WHERE store_id = " + Escape(item.StoreId.ToString()) + " "
                    + "AND item_id = '" + Escape(item.ItemId) + "' ";


                itemExists = SqlBitToBool(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql));

            //New item
            if (!itemExists)
            {

                sql = "INSERT INTO item ("
                    + "store_id,"
                    + "item_id,"
                    + "product_id,"
                    + "sqn,"
                    + "pick_loc,"
                    + "price,"
                    + "sale_price,"
                    + "shipping_charge,"
                    + "reorder_point,"
                    + "reorder_qty,"
                    + "page_count,"
                    + "part_status,"
                    + "attribute_1_value,"
                    + "attribute_2_value,"
                    + "attribute_3_value,"
                    + "qty_reserved,"
                    + "useup_flag,"
                    + "active_flag,"
                    + "item_content,"
                    + "default_content,"
                    + "custom_content_flag,"
                    + "onf_cost,"
                    + "inventory_cost,"
                    + "inventory_owner,"
                    + "content_owner,"
                    + "qty_staged,"
                    + "print_on_demand_flag,"
                    + "cd_fulfillment_flag,"
                    + "cd_only_flag,"
                    + "weight,"
                    + "POD_override_flag,"
                    + "revision,"
                    + "revision_date,"
                    + "onSecure_flag "
                    + ")"
                    + "VALUES("
                    + nullChk(item.StoreId) + ","
                    + nullChk(item.ItemId) + ","
                    + nullChk(item.ProductId) + ","
                    + nullChk(item.Sqn) + ","
                    + nullChk(item.PickLoc) + ","
                    + nullChk(item.Price) + ","
                    + nullChk(item.SalePrice) + ","
                    + nullChk(item.ShippingCharge) + ","
                    + nullChk(item.ReorderPoint) + ","
                    + nullChk(item.ReorderQty) + ","
                    + nullChk(item.PageCount) + ","
                    + nullChk(item.PartStatus) + ","
                    + nullChk(item.Attribute1Value) + ","
                    + nullChk(item.Attribute2Value) + ","
                    + nullChk(item.Attribute3Value) + ","
                    + nullChk(item.QtyReserved) + ","
                    + nullChk(item.UseupFlag) + ","
                    + nullChk(item.ActiveFlag) + ","
                    + nullChk(item.ItemContent) + ","
                    + nullChk(item.DefaultContent) + ","
                    + nullChk(item.CustomContentFlag) + ","
                    + nullChk(item.OnfCost) + ","
                    + nullChk(item.InventoryCost) + ","
                    + nullChk(item.InventoryOwner) + ","
                    + nullChk(item.ContentOwner) + ","
                    + nullChk(item.QtyStaged) + ","
                    + nullChk(item.PrintOnDemandFlag) + ","
                    + nullChk(item.CdFulfillmentFlag) + ","
                    + nullChk(item.CdOnlyFlag) + ","
                    + nullChk(item.weight) + ","
                    + nullChk(item.POD_OverrideFlag) + ","
                    + nullChk(item.Revision) + ","
                    + nullChk(item.RevisionDate) + ","
                    + nullChk(item.OnSecureFlag)
                    + ")";

            }
            else //item already exists, do update.
            {
                sql = "UPDATE item SET "
                    + "store_id = " + nullChk(item.StoreId) + ","
                    + "item_id = " + nullChk(item.ItemId) + ","
                    + "product_id = " + nullChk(item.ProductId) + ","
                    + "sqn = " + nullChk(item.Sqn) + ","
                    + "pick_loc = " + nullChk(item.PickLoc) + ","
                    + "price = " + nullChk(item.Price) + ","
                    + "sale_price = " + nullChk(item.SalePrice) + ","
                    + "shipping_charge = " + nullChk(item.ShippingCharge) + ","
                    + "reorder_point = " + nullChk(item.ReorderPoint) + ","
                    + "reorder_qty = " + nullChk(item.ReorderQty) + ","
                    + "page_count = " + nullChk(item.PageCount) + ","
                    + "part_status = " + nullChk(item.PartStatus) + ","
                    + "attribute_1_value = " + nullChk(item.Attribute1Value) + ","
                    + "attribute_2_value = " + nullChk(item.Attribute2Value) + ","
                    + "attribute_3_value = " + nullChk(item.Attribute3Value) + ","
                    + "qty_reserved = " + nullChk(item.QtyReserved) + ","
                    + "useup_flag = " + nullChk(item.UseupFlag) + ","
                    + "active_flag = " + nullChk(item.ActiveFlag) + ","
                    + "item_content = " + nullChk(item.ItemContent) + ","
                    + "default_content = " + nullChk(item.DefaultContent) + ","
                    + "custom_content_flag = " + nullChk(item.CustomContentFlag) + ","
                    + "onf_cost = " + nullChk(item.OnfCost) + ","
                    + "inventory_cost = " + nullChk(item.InventoryCost) + ","
                    + "inventory_owner = " + nullChk(item.InventoryOwner) + ","
                    + "content_owner = " + nullChk(item.ContentOwner) + ","
                    + "qty_staged = " + nullChk(item.QtyStaged) + ","
                    + "print_on_demand_flag = " + nullChk(item.PrintOnDemandFlag) + ","
                    + "cd_fulfillment_flag = " + nullChk(item.CdFulfillmentFlag) + ","
                    + "weight = " + nullChk(item.weight) + ","
                    + "POD_override_flag = " + nullChk(item.POD_OverrideFlag) + ","
                    + "cd_only_flag = " + nullChk(item.CdOnlyFlag) + ", "
                    + "revision = " + nullChk(item.Revision) + ", "
                    + "revision_date = " + nullChk(item.RevisionDate) + ","
                    + "onSecure_flag = " + nullChk(item.OnSecureFlag) + " "
                    + "WHERE store_id = " + nullChk(item.StoreId) + " "
                    + "AND item_id = " + nullChk(item.ItemId) + " ";

            }

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql);
            
            return item;
        }

        public static int CalcQtyAvailable(int? storeID, string itemID)
        {
            int qtyAvailable = 0;
            string sql;

            sql = "select dbo.getQtyAvail(" + storeID.ToString() + ",'" + itemID + "')";

            try
            {
                qtyAvailable = (int) SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql);
            }
            catch
            { 
            }

            return qtyAvailable;

        }

        public static DateTime? GetEarliestInboundMaterialArrivalDate(int? storeId, string itemId)
        {
            DateTime? date = null;
            string sql;

            sql = "SELECT dbo.getEarliestInboundMaterialArrivalDate(" + storeId.ToString() + ",'" + itemId + "')";

            try
            {
                date = (DateTime?) SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql);
            }
            catch
            {
            }

            return date;
        }

        public static int GetEarliestInboundMaterialArrivalQuantity(int? storeId, string itemId)
        {
            int quantity = 0;
            string sql;

            sql = "SELECT dbo.getEarliestInboundMaterialQuantity(" + storeId.ToString() + ",'" + itemId + "')";

            try
            {
                quantity = (int)SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql);
            }
            catch
            {
            }

            return quantity;
        }        

    }
}
