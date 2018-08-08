namespace PBA.OnfDAL
{
    using Microsoft.ApplicationBlocks.Data;
    using PBA.OnfInfo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class UserTypeData : DataAccess
    {
        public static UserTypeInfo GetUserType(int? storeId, string userType)
        {
            UserTypeInfo info = null;
            string commandText = "SELECT \n\tstore_id, \n\tuser_type, \n\tshow_price_flag, \n\tshow_available_flag, \n\tpayment_required_flag, \n\tadmin_flag, \n\tsuper_admin_flag, \n\tsecurity_flag, \n\tmanager_flag, \n\treorder_notify_flag, \n\tchoose_cost_center_flag, \n\torder_for_flag, \n\tonfulfill_flag, \n\tgod_flag, \n\twhse_flag, \n\treport_master_flag, \n\torder_one_flag, \n\tPO_Payment_Option_flag, \n\tSource_Code_Access_flag, \n\tAdd_To_Cart_flag, \n\tvirtual_fulfillment_flag \nFROM usertype \nWHERE \n\t(store_id = @store_id) \n\tAND (user_type = @user_type) \n";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@user_type", SqlDbType.VarChar, 0xff);
            parameter2.Value = userType;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.Read())
                {
                    info = new UserTypeInfo();
                    info.StoreId = DataAccess.NCI(reader["store_id"]);
                    info.UserType = DataAccess.NCS(reader["user_type"]);
                    info.ShowPriceFlag = DataAccess.NCB(reader["show_price_flag"]);
                    info.ShowAvailableFlag = DataAccess.NCB(reader["show_available_flag"]);
                    info.PaymentRequiredFlag = DataAccess.NCB(reader["payment_required_flag"]);
                    info.AdminFlag = DataAccess.NCB(reader["admin_flag"]);
                    info.SuperAdminFlag = DataAccess.NCB(reader["super_admin_flag"]);
                    info.SecurityFlag = DataAccess.NCB(reader["security_flag"]);
                    info.ManagerFlag = DataAccess.NCB(reader["manager_flag"]);
                    info.ReorderNotifyFlag = DataAccess.NCB(reader["reorder_notify_flag"]);
                    info.ChooseCostCenterFlag = DataAccess.NCB(reader["choose_cost_center_flag"]);
                    info.OrderForFlag = DataAccess.NCB(reader["order_for_flag"]);
                    info.OnFulfillFlag = DataAccess.NCB(reader["onfulfill_flag"]);
                    info.GodFlag = DataAccess.NCB(reader["god_flag"]);
                    info.WhseFlag = DataAccess.NCB(reader["whse_flag"]);
                    info.ReportMasterFlag = DataAccess.NCB(reader["report_master_flag"]);
                    info.OrderOneFlag = DataAccess.NCB(reader["order_one_flag"]);
                    info.POPaymentOptionFlag = DataAccess.NCB(reader["PO_Payment_Option_flag"]);
                    info.SourceCodeAccessFlag = DataAccess.NCB(reader["Source_Code_Access_flag"]);
                    info.AddToCartFlag = DataAccess.NCB(reader["Add_To_Cart_flag"]);
                    info.VirtualFulfillmentFlag = DataAccess.NCB(reader["virtual_fulfillment_flag"]);
                }
                reader.Close();
            }
            return info;
        }

        public static UserTypeInfo[] GetUserTypes(int? storeId)
        {
            return GetUserTypes(storeId, "");
        }

        public static UserTypeInfo[] GetUserTypes(int? storeId, string whereClause)
        {
            List<UserTypeInfo> list = new List<UserTypeInfo>();
            string commandText = "SELECT \n\tstore_id, \n\tuser_type, \n\tshow_price_flag, \n\tshow_available_flag, \n\tpayment_required_flag, \n\tadmin_flag, \n\tsuper_admin_flag, \n\tsecurity_flag, \n\tmanager_flag, \n\treorder_notify_flag, \n\tchoose_cost_center_flag, \n\torder_for_flag, \n\tonfulfill_flag, \n\tgod_flag, \n\twhse_flag, \n\treport_master_flag, \n\torder_one_flag, \n\tPO_Payment_Option_flag, \n\tSource_Code_Access_flag, \n\tAdd_To_Cart_flag, \n\tvirtual_fulfillment_flag \nFROM usertype \nWHERE (store_id = @store_id) \n";
            if (!string.IsNullOrEmpty(whereClause))
            {
                commandText = commandText + " AND " + whereClause + "\n";
            }
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("user_type");
                    int num3 = reader.GetOrdinal("show_price_flag");
                    int num4 = reader.GetOrdinal("show_available_flag");
                    int num5 = reader.GetOrdinal("payment_required_flag");
                    int num6 = reader.GetOrdinal("admin_flag");
                    int num7 = reader.GetOrdinal("super_admin_flag");
                    int num8 = reader.GetOrdinal("security_flag");
                    int num9 = reader.GetOrdinal("manager_flag");
                    int num10 = reader.GetOrdinal("reorder_notify_flag");
                    int num11 = reader.GetOrdinal("choose_cost_center_flag");
                    int num12 = reader.GetOrdinal("order_for_flag");
                    int num13 = reader.GetOrdinal("onfulfill_flag");
                    int num14 = reader.GetOrdinal("god_flag");
                    int num15 = reader.GetOrdinal("whse_flag");
                    int num16 = reader.GetOrdinal("report_master_flag");
                    int num17 = reader.GetOrdinal("order_one_flag");
                    int num18 = reader.GetOrdinal("PO_Payment_Option_flag");
                    int num19 = reader.GetOrdinal("Source_Code_Access_flag");
                    int num20 = reader.GetOrdinal("Add_To_Cart_flag");
                    int num21 = reader.GetOrdinal("virtual_fulfillment_flag");
                    while (reader.Read())
                    {
                        UserTypeInfo item = new UserTypeInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.UserType = DataAccess.NCS(reader[num2]);
                        item.ShowPriceFlag = DataAccess.NCB(reader[num3]);
                        item.ShowAvailableFlag = DataAccess.NCB(reader[num4]);
                        item.PaymentRequiredFlag = DataAccess.NCB(reader[num5]);
                        item.AdminFlag = DataAccess.NCB(reader[num6]);
                        item.SuperAdminFlag = DataAccess.NCB(reader[num7]);
                        item.SecurityFlag = DataAccess.NCB(reader[num8]);
                        item.ManagerFlag = DataAccess.NCB(reader[num9]);
                        item.ReorderNotifyFlag = DataAccess.NCB(reader[num10]);
                        item.ChooseCostCenterFlag = DataAccess.NCB(reader[num11]);
                        item.OrderForFlag = DataAccess.NCB(reader[num12]);
                        item.OnFulfillFlag = DataAccess.NCB(reader[num13]);
                        item.GodFlag = DataAccess.NCB(reader[num14]);
                        item.WhseFlag = DataAccess.NCB(reader[num15]);
                        item.ReportMasterFlag = DataAccess.NCB(reader[num16]);
                        item.OrderOneFlag = DataAccess.NCB(reader[num17]);
                        item.POPaymentOptionFlag = DataAccess.NCB(reader[num18]);
                        item.SourceCodeAccessFlag = DataAccess.NCB(reader[num19]);
                        item.AddToCartFlag = DataAccess.NCB(reader[num20]);
                        item.VirtualFulfillmentFlag = DataAccess.NCB(reader[num21]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static UserTypeInfo[] GetUserTypesAndDefault(int? storeid)
        {
            string commandText = string.Empty;
            ArrayList list = new ArrayList();
            commandText = "SELECT " + DataAccess.Escape(storeid.ToString()) + " store_id, '(All)' user_type, 0 show_price_flag, 0 show_available_flag, 0 payment_required_flag, 0 admin_flag, 0 super_admin_flag, 0 security_flag, 0 manager_flag, 0 reorder_notify_flag, 0 choose_cost_center_flag, 0 order_for_flag, 0 onfulfill_flag, 0 god_flag, 0 whse_flag, 0 report_master_flag, 0 order_one_flag, 0 PO_Payment_Option_flag, 0 Source_Code_Access_flag, 0 Add_To_Cart_flag, 0 virtual_fulfillment_flag UNION ALL SELECT store_id, user_type, show_price_flag, show_available_flag, payment_required_flag, admin_flag, super_admin_flag, security_flag, manager_flag, reorder_notify_flag, choose_cost_center_flag, order_for_flag, onfulfill_flag, god_flag, whse_flag, report_master_flag, order_one_flag, PO_Payment_Option_flag, Source_Code_Access_flag, Add_To_Cart_flag, virtual_fulfillment_flag FROM usertype WHERE store_id = " + DataAccess.Escape(storeid.ToString());
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText))
            {
                while (reader.Read())
                {
                    UserTypeInfo info = new UserTypeInfo();
                    info.StoreId = DataAccess.NCI(reader["store_id"]);
                    info.UserType = DataAccess.NCS(reader["user_type"]);
                    info.ShowPriceFlag = DataAccess.NCB(reader["show_price_flag"]);
                    info.ShowAvailableFlag = DataAccess.NCB(reader["show_available_flag"]);
                    info.PaymentRequiredFlag = DataAccess.NCB(reader["payment_required_flag"]);
                    info.AdminFlag = DataAccess.NCB(reader["admin_flag"]);
                    info.SuperAdminFlag = DataAccess.NCB(reader["super_admin_flag"]);
                    info.SecurityFlag = DataAccess.NCB(reader["security_flag"]);
                    info.ManagerFlag = DataAccess.NCB(reader["manager_flag"]);
                    info.ReorderNotifyFlag = DataAccess.NCB(reader["reorder_notify_flag"]);
                    info.ChooseCostCenterFlag = DataAccess.NCB(reader["choose_cost_center_flag"]);
                    info.OrderForFlag = DataAccess.NCB(reader["order_for_flag"]);
                    info.POPaymentOptionFlag = DataAccess.NCB(reader["PO_Payment_Option_flag"]);
                    info.SourceCodeAccessFlag = DataAccess.NCB(reader["Source_Code_Access_flag"]);
                    info.AddToCartFlag = DataAccess.NCB(reader["Add_To_Cart_flag"]);
                    info.VirtualFulfillmentFlag = DataAccess.NCB(reader["virtual_fulfillment_flag"]);
                    list.Add(info);
                }
                reader.Close();
            }
            return (UserTypeInfo[]) list.ToArray(typeof(UserTypeInfo));
        }

        public static UserTypeInfo[] GetUserTypesAndDefaultValue(int? storeId, string defaultValue)
        {
            return GetUserTypesAndDefaultValue(storeId, "", defaultValue);
        }

        public static UserTypeInfo[] GetUserTypesAndDefaultValue(int? storeId, string whereClause, string defaultValue)
        {
            List<UserTypeInfo> list = new List<UserTypeInfo>();
            string commandText = "SELECT \n\tstore_id, \n\tuser_type, \n\tshow_price_flag, \n\tshow_available_flag, \n\tpayment_required_flag, \n\tadmin_flag, \n\tsuper_admin_flag, \n\tsecurity_flag, \n\tmanager_flag, \n\treorder_notify_flag, \n\tchoose_cost_center_flag, \n\torder_for_flag, \n\tonfulfill_flag, \n\tgod_flag, \n\twhse_flag, \n\treport_master_flag, \n\torder_one_flag, \n\tPO_Payment_Option_flag, \n\tSource_Code_Access_flag, \n\tAdd_To_Cart_flag, \n\tvirtual_fulfillment_flag \nFROM usertype \nWHERE (store_id = @store_id) \n";
            if (!string.IsNullOrEmpty(whereClause))
            {
                commandText = commandText + " AND " + whereClause + "\n";
            }
            commandText = commandText + "ORDER BY user_type ";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter };
            bool? showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            showpriceflag = null;
            list.Add(new UserTypeInfo(storeId, defaultValue, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, showpriceflag, null));
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("user_type");
                    int num3 = reader.GetOrdinal("show_price_flag");
                    int num4 = reader.GetOrdinal("show_available_flag");
                    int num5 = reader.GetOrdinal("payment_required_flag");
                    int num6 = reader.GetOrdinal("admin_flag");
                    int num7 = reader.GetOrdinal("super_admin_flag");
                    int num8 = reader.GetOrdinal("security_flag");
                    int num9 = reader.GetOrdinal("manager_flag");
                    int num10 = reader.GetOrdinal("reorder_notify_flag");
                    int num11 = reader.GetOrdinal("choose_cost_center_flag");
                    int num12 = reader.GetOrdinal("order_for_flag");
                    int num13 = reader.GetOrdinal("onfulfill_flag");
                    int num14 = reader.GetOrdinal("god_flag");
                    int num15 = reader.GetOrdinal("whse_flag");
                    int num16 = reader.GetOrdinal("report_master_flag");
                    int num17 = reader.GetOrdinal("order_one_flag");
                    int num18 = reader.GetOrdinal("PO_Payment_Option_flag");
                    int num19 = reader.GetOrdinal("Source_Code_Access_flag");
                    int num20 = reader.GetOrdinal("Add_To_Cart_flag");
                    int num21 = reader.GetOrdinal("virtual_fulfillment_flag");
                    while (reader.Read())
                    {
                        UserTypeInfo item = new UserTypeInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.UserType = DataAccess.NCS(reader[num2]);
                        item.ShowPriceFlag = DataAccess.NCB(reader[num3]);
                        item.ShowAvailableFlag = DataAccess.NCB(reader[num4]);
                        item.PaymentRequiredFlag = DataAccess.NCB(reader[num5]);
                        item.AdminFlag = DataAccess.NCB(reader[num6]);
                        item.SuperAdminFlag = DataAccess.NCB(reader[num7]);
                        item.SecurityFlag = DataAccess.NCB(reader[num8]);
                        item.ManagerFlag = DataAccess.NCB(reader[num9]);
                        item.ReorderNotifyFlag = DataAccess.NCB(reader[num10]);
                        item.ChooseCostCenterFlag = DataAccess.NCB(reader[num11]);
                        item.OrderForFlag = DataAccess.NCB(reader[num12]);
                        item.OnFulfillFlag = DataAccess.NCB(reader[num13]);
                        item.GodFlag = DataAccess.NCB(reader[num14]);
                        item.WhseFlag = DataAccess.NCB(reader[num15]);
                        item.ReportMasterFlag = DataAccess.NCB(reader[num16]);
                        item.OrderOneFlag = DataAccess.NCB(reader[num17]);
                        item.POPaymentOptionFlag = DataAccess.NCB(reader[num18]);
                        item.SourceCodeAccessFlag = DataAccess.NCB(reader[num19]);
                        item.AddToCartFlag = DataAccess.NCB(reader[num20]);
                        item.VirtualFulfillmentFlag = DataAccess.NCB(reader[num21]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }
    }
}

