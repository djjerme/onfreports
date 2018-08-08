using System;
//using MS;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace PBA.OnfDAL
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class DAL
	{
		//private member variables

		//static variables
		
		//static string dbConnection0 = ConfigurationManager.AppSettings["dbConnection"].ToString();

        public static string dbConnection
        {
            get
            {
                string connstr;

                System.Configuration.ConnectionStringSettingsCollection css =
                     System.Configuration.ConfigurationManager.ConnectionStrings;
                connstr = css["PBA.OnfDAL.Properties.Settings.estoreConnectionString"].ConnectionString;

                return connstr;
            }
        }
		//constructors	

		//public methods
		//public properties

		//static methods
        public static bool ValidateHandler(int storeID, string handler)
        {
            string sqlQuery;

            sqlQuery = "SELECT isnull(count(handler_id),0) "
             + "FROM handler h "
             + "inner join store s "
             + "on s.whse_id = h.whse_id "
             + "WHERE h.handler_id = '" + handler + "' "
             + "and s.store_id = " + storeID + " ";


            int recordCount = System.Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sqlQuery).ToString());

            if (recordCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool ValidateHandler(int storeID, string handler, string password)
        {
            string sqlQuery;

            sqlQuery = "SELECT isnull(count(handler_id),0) "
             + "FROM handler h "
             + "inner join store s "
             + "on s.whse_id = h.whse_id "
             + "WHERE h.handler_id = '" + handler + "' "
             + "AND h.password = '" + password + "' "
             + "and s.store_id = " + storeID + " ";


            int recordCount = System.Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sqlQuery).ToString());

            if (recordCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Ths version of validate handler is intended for non-store specific access. 
        /// This would be used for a web service to handle username authentication over
        /// transport, where the client will be issuing webservice requests that may
        /// not be associated with a specific store. For a handler to be authenticated,
        /// it must have its whse_id set to zero. 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="password"></param>
        /// <returns>true = validated</returns>
        public static bool ValidateHandler(string handler, string password)
        {
            string sqlQuery;

            sqlQuery = "SELECT isnull(count(handler_id),0) "
             + "FROM handler h "
             + "WHERE h.handler_id = '" + handler + "' "
             + "AND h.password = '" + password + "' "
             + "and h.whse_id = 0";


            int recordCount = System.Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sqlQuery).ToString());

            if (recordCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static DataSet GetOrderLineInfo(int storeID, int orderID, int orderSuffix, int orderLine)
        {
            string sqlQuery;
            DataSet orderLineInfo;

            sqlQuery = "select s.store_id, oh.order_id, oh.order_suffix, ol.line_no, s.name, ol.item_id, p.name "
            + "from order_line ol "
            + "inner join order_head oh "
            + "on ol.store_id = oh.store_id "
            + "and ol.order_id = oh.order_id "
            + "and ol.order_suffix = oh.order_suffix "
            + "inner join store s "
            + "on s.store_id = oh.store_id "
            + "inner join item i "
            + "on i.store_id = ol.store_id "
            + "and i.item_id = ol.item_id "
            + "inner join product p "
            + "on p.store_id = i.store_id  "
            + "and p.product_id = i.product_id "
            + "where ol.store_id = " + storeID + " "
            + "and ol.order_id = " + orderID + " "
            + "and ol.order_suffix = " + orderSuffix + " "
            + "and ol.line_no = " + orderLine + " ";


            orderLineInfo = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, sqlQuery);

            return orderLineInfo;

        }

        public static string GetEmailTemplate(int StoreId)
        {
            string l_Query;
            string l_EmailTemplate;

            l_Query = string.Format("SELECT coalesce(email_ship_confirm_template, '') email_ship_confirm_template "
                + "FROM store with (NOLOCK) WHERE store_id = {0}", StoreId);

            l_EmailTemplate = (SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query)).ToString();

            return l_EmailTemplate;
        }

        public static DataSet GetSynderoItem(int StoreID, int OrderID, int OrderSuffix)
        {
            string l_Query;
            DataSet l_DSet;

            l_Query = string.Format("SELECT TOP 1 i.item_id, i.product_id " +
                "FROM order_line AS ol with (NOLOCK) " +
                "INNER JOIN item AS i with (NOLOCK) ON " +
                "   (ol.store_id = i.store_id) AND (ol.item_id = i.item_id) " +
                "WHERE (ol.store_id = {0}) " +
                "   AND (ol.order_id = {1}) " +
                "   AND (ol.order_suffix = {2})", StoreID, OrderID, OrderSuffix);

            l_DSet = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, l_Query);

            return l_DSet;
        }

        public static DataSet GetLineItemForEmail(int StoreID, int OrderID, int OrderSuffix)
        {
            string l_Query;
            DataSet l_DSet;

            l_Query = string.Format("select * from v_Order_Line_Info " +
                "where store_id = {0} " +
                "   and order_id = {1} " +
                "   and order_suffix = {2}",
                StoreID, OrderID, OrderSuffix);

            l_DSet = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, l_Query);

            return l_DSet;
        }

        public static DataSet GetOrderHeaderForEmail(int StoreID, int OrderID, int OrderSuffix)
        {
            string l_Query;
            DataSet l_DSet;

            l_Query = string.Format("select * from v_Order_Header_Info " +
                "where store_id = {0} " +
                "   and order_id = {1} " +
                "   and order_suffix = {2}",
                StoreID, OrderID, OrderSuffix);

            l_DSet = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, l_Query);

            return l_DSet;
        }

        public static void UpdateSendConfirmEmailFlag(int StoreID, int OrderID, int OrderSuffix, bool SentFlag)
        {
            string sqlQuery;

            sqlQuery = string.Format("UPDATE order_head " +
                "SET ship_confirm_email_sent_flag = {0} " +
                "WHERE store_id = {1} and order_id = {2} and order_suffix = {3}",
                SentFlag ? 1 : 0,
                StoreID, OrderID, OrderSuffix);

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);
        }

        public static int AssignLicenseKeys(int StoreID, int OrderID, int OrderSuffix,
            string ItemID, int RequestedCount, string LicenseKeyType)
        {
            string l_SP;

            l_SP = "sp_AssignLicenseKey";
            SqlParameter l_store_id = new SqlParameter("@storeid", SqlDbType.Int, 0);
            l_store_id.Value = StoreID;
            SqlParameter l_order_id = new SqlParameter("@orderid", SqlDbType.Int, 0);
            l_order_id.Value = OrderID;
            SqlParameter l_order_suffix = new SqlParameter("@ordersuffix", SqlDbType.Int, 0);
            l_order_suffix.Value = OrderSuffix;
            SqlParameter l_itemid = new SqlParameter("@itemid", SqlDbType.VarChar, 80);
            l_itemid.Value = ItemID;
            SqlParameter l_requestedcount = new SqlParameter("@requestedcount", SqlDbType.Int, 0);
            l_requestedcount.Value = RequestedCount;
            SqlParameter l_licensekeytype = new SqlParameter("@licensekeytype", SqlDbType.VarChar, 32);
            l_licensekeytype.Value = LicenseKeyType;
            SqlParameter l_return = new SqlParameter("@return", SqlDbType.Int, 0);
            l_return.Value = 0;
            l_return.Direction = ParameterDirection.Output;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, l_SP,
                l_store_id, l_order_id, l_order_suffix,
                l_itemid, l_requestedcount, l_licensekeytype, l_return));
        }

        public static int UpdateInventoryShipped(int StoreID, int OrderID, int OrderSuffix,
            string Reference, string Handler, string Comment)
        {
            string l_SP;

            l_SP = "sp_Update_Inventory_Shipped";
            SqlParameter l_store_id = new SqlParameter("@store_id", SqlDbType.Int, 0);
            l_store_id.Value = StoreID;
            SqlParameter l_order_id = new SqlParameter("@order_id", SqlDbType.Int, 0);
            l_order_id.Value = OrderID;
            SqlParameter l_order_suffix = new SqlParameter("@order_suffix", SqlDbType.Int, 0);
            l_order_suffix.Value = OrderSuffix;
            SqlParameter l_reference = new SqlParameter("@reference", SqlDbType.VarChar, 50);
            l_reference.Value = Reference;
            SqlParameter l_handler = new SqlParameter("@handler", SqlDbType.VarChar, 50);
            l_handler.Value = Handler;
            SqlParameter l_comment = new SqlParameter("@comment", SqlDbType.VarChar, 255);
            l_comment.Value = Comment;
            SqlParameter l_return = new SqlParameter("@return", SqlDbType.Int, 0);
            l_return.Value = 0;
            l_return.Direction = ParameterDirection.Output;

            //result = SqlHelper.ExecuteNonQuery(dbConnection, l_SP,
            //    l_store_id, l_order_id, l_order_suffix,
            //    l_reference, l_handler, l_comment, l_return);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, l_SP,
                l_store_id, l_order_id, l_order_suffix,
                l_reference, l_handler, l_comment, l_return));
        }
            

        public static int GetNISNewGameCount(int StoreID, int OrderId, int OrderSuffix)
        {
            string l_Query;
            int l_ItemCount;

            l_Query = string.Format("SELECT COUNT(*) " +
                "FROM order_line ol " +
                "INNER JOIN item i ON (ol.store_id = i.store_id) " +
                "   AND (ol.item_id = i.item_id) "  +
                "INNER JOIN product p ON (i.store_id = p.store_id) " +
                "   AND (i.product_id = p.product_id) " +
                "WHERE (ol.store_id = {0}) " +
                "   AND (ol.order_id = {1}) " +
                "   AND (ol.order_suffix = {2}) " +
                "   AND (p.product_id = 14) ", StoreID, OrderId, OrderSuffix);

            l_ItemCount = (int) SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query);

            return l_ItemCount;
        }

        public static bool FeatureCheck(string Feature, int StoreID)
        {
            string l_Query;
            bool l_Available;

            l_Query = string.Format("select coalesce(flag, 0) from code " +
                "where class = 'feature' and code = '{0}' " +
                "   and store_id = {1}", Feature, StoreID);

            l_Available = 
                Convert.ToBoolean(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, l_Query));

            return l_Available;
        }

        public static DataSet GetEmailAddresses(int StoreId, string MsgType)
        {
            string l_Query;
            DataSet l_Dset;

            l_Query = string.Format("select * from email_notification_address " +
                "where store_id = {0} " +
                "and message_type = '{1}' " +
                "order by store_id, address_type, sequence", StoreId, MsgType);

            l_Dset = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, l_Query);

            return l_Dset;
        }

        public static DataSet GetOrderConfirmationMsg(int StoreID, string UserID)
        {
            string l_Query;
            DataSet l_DSet;

            l_Query = string.Format("select p.email, s.order_confirm_msg, " +
                "s.customer_contact_email " +
                "from person p inner join store s on p.store_id = s.store_id " +
                "where p.person_id = {0} and p.store_id = {1}", UserID, StoreID);

            l_DSet = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, l_Query);

            return l_DSet;
        }

        public static DataSet GetSerialInfo(int storeID, int orderID, int orderSuffix, int orderLine)
        {
            string sqlQuery;
            DataSet serialInfo;

            sqlQuery = "select distinct isn.item_serial_number_id, isn.serial_number "
            + "from order_line ol "
            + "inner join order_head oh "
            + "on ol.store_id = oh.store_id "
            + "and ol.order_id = oh.order_id "
            + "and ol.order_suffix = oh.order_suffix "
            + "inner join item_serial_number isn "
            + "on isn.store_id = ol.store_id "
            + "and isn.original_order_id = ol.order_id "
            + "and isn.original_order_suffix = ol.order_suffix "
            + "and isn.item_id = ol.item_id "
            + "where ol.store_id = " + storeID + " "
            + "and ol.order_id = " + orderID + " "
            + "and ol.order_suffix = " + orderSuffix + " "
            + "and ol.line_no = " + orderLine + " ";


            serialInfo = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, sqlQuery);

            if (serialInfo.Tables[0].Rows.Count < 1)
            {
                serialInfo.Tables[0].Rows.Add(serialInfo.Tables[0].NewRow());
            }

            return serialInfo;

        }

        public static void InsertSerial(int storeID, int orderID, int orderSuffix, int orderLine,
            string itemID, string serialNumber)
        {
            string sqlQuery;
            int itemSerialNumberID;
            int serialCount;

            sqlQuery = string.Format("select count(*) from item_serial_number where store_id = {0} " +
                "and serial_number = '{1}' ", storeID, serialNumber);
            serialCount = Convert.ToInt32(
                SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sqlQuery));

            if (serialCount > 0)
            {
                DuplicateSerialException e = new DuplicateSerialException("Attempt to insert duplicate serial number.");
                throw e;
            }

            sqlQuery = "insert into item_serial_number(item_id, serial_number, original_order_id, "
            + "original_order_suffix, store_id) "
            + "values('" + itemID + "','" + serialNumber + "'," + orderID + "," + orderSuffix
            + "," + storeID + ")";

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);


            sqlQuery = "SELECT item_serial_number_id  "
                + "FROM item_serial_number "
                + "WHERE store_id = " + storeID + " "
                + "AND original_order_id = " + orderID + " "
                + "AND original_order_suffix = " + orderSuffix + " "
                + "AND serial_number = '" + serialNumber + "' "
                + "AND item_id = '" + itemID + "' ";


            itemSerialNumberID = (int)SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sqlQuery);


            sqlQuery = "insert into order_line_serial_number(store_id, order_id, order_suffix, item_id, item_serial_number_id) "
            + "values(" + storeID.ToString() + "," + orderID.ToString() + "," + orderSuffix.ToString() + ",'" + itemID
            + "'," + itemSerialNumberID.ToString() + ")";

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);


        }

        public static void DeleteSerial(int serialNumberID)
        {
            string sqlQuery;

            sqlQuery = "DELETE FROM item_serial_number "
            + "WHERE item_serial_number_id = " + serialNumberID.ToString() + " ";

            sqlQuery += "DELETE FROM order_line_serial_number "
            + "WHERE item_serial_number_id = " + serialNumberID.ToString();

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);


        }

        public static void UpdateSerial(int serialNumberID, string serialNumber)
        {
            string sqlQuery;

            sqlQuery = "UPDATE item_serial_number "
            + "SET serial_number = '" + serialNumber + "' "
            + "WHERE item_serial_number_id = " + serialNumberID.ToString();

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);
        }

        public static void MarkLicenseKeysPrinted(int StoreID, int OrderID, int OrderSuffix)
        {
            string sqlQuery;

            sqlQuery = string.Format("UPDATE license_key " +
                "SET status = 3 " +
                "WHERE store_id = {0} and order_id = {1} and order_suffix = {2} " +
                "and status = 2",
                StoreID, OrderID, OrderSuffix);

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);
            
        }

        public static void ConfirmPointsAccumulation(int StoreID, int OrderID, int OrderSuffix)
        {
            string sqlQuery;

            sqlQuery = string.Format("UPDATE purchase_rewards " +
                "SET status = 'verified' " +
                "WHERE store_id = {0} and order_id = {1} and order_suffix = {2} ",
                StoreID, OrderID, OrderSuffix);

            SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sqlQuery);
        }

        public static int GetUserPurchaseRewardsPointTotal(int storeId, int personId, string pointStatus)
        {
            string sqlQuery;
            int pointTotal = 0;

            sqlQuery = string.Format("SELECT ISNULL(SUM(amount),0) AS amount FROM purchase_rewards WHERE WHERE store_id = {0} and person_id = {1} and status = {2}", storeId, personId, pointStatus);
            pointTotal = (int)SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sqlQuery);

            return pointTotal;

        }

    }
}
