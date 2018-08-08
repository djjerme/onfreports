namespace PBA.OnfDAL
{
    using Microsoft.ApplicationBlocks.Data;
    using PBA.OnfInfo;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;

    public class StoreNameIDData : DataAccess
    {
        public static StoreNameIDInfo[] GetStoreNameID(string userid)
        {
            string commandText = string.Empty;
            ArrayList list = new ArrayList();
            commandText = "SELECT * from (SELECT s.store_id, s.name FROM Handler h INNER Join Store s on (s.whse_id = h.whse_id) WHERE (s.active_flag = 1 and s.store_id <> 0)  and h.handler_id = '" + userid + "' UNION SELECT 0 storeid, '(ALL)' name) A order by A.name";
            SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText);
            while (reader.Read())
            {
                StoreNameIDInfo info = new StoreNameIDInfo();
                info.StoreId = DataAccess.NCI(reader["store_id"]);
                info.StoreName = DataAccess.NCS(reader["name"]);
                list.Add(info);
            }
            reader.Close();
            return (StoreNameIDInfo[]) list.ToArray(typeof(StoreNameIDInfo));
        }

        public static StoreNameIDInfo[] GetStoreNameIDAndSelectAll()
        {
            string commandText = string.Empty;
            ArrayList list = new ArrayList();
            commandText = "SELECT s.store_id, s.name from Store s WHERE (s.active_flag = 1 and s.store_id <> 0) UNION SELECT 0 storeid, '*** All Stores ***' name order by A.name";
            SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText);
            while (reader.Read())
            {
                StoreNameIDInfo info = new StoreNameIDInfo();
                info.StoreId = DataAccess.NCI(reader["store_id"]);
                info.StoreName = DataAccess.NCS(reader["name"]);
                list.Add(info);
            }
            reader.Close();
            return (StoreNameIDInfo[]) list.ToArray(typeof(StoreNameIDInfo));
        }

        public static StoreNameIDInfo[] GetStoreNameIDAndSelectAll(string userid)
        {
            string commandText = string.Empty;
            ArrayList list = new ArrayList();
            commandText = "SELECT * from (SELECT s.store_id, s.name FROM Handler h INNER Join Store s on (s.whse_id = h.whse_id) WHERE (s.active_flag = 1 and s.store_id <> 0)  and h.handler_id = '" + userid + "' UNION SELECT 0 storeid, '*** All Stores ***' name) A order by A.name";
            SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText);
            while (reader.Read())
            {
                StoreNameIDInfo info = new StoreNameIDInfo();
                info.StoreId = DataAccess.NCI(reader["store_id"]);
                info.StoreName = DataAccess.NCS(reader["name"]);
                list.Add(info);
            }
            reader.Close();
            return (StoreNameIDInfo[]) list.ToArray(typeof(StoreNameIDInfo));
        }

        public static StoreNameIDInfo[] GetStoreNameIDAndSelectOne(string userid)
        {
            string commandText = string.Empty;
            ArrayList list = new ArrayList();
            commandText = "SELECT * from (SELECT s.store_id, s.name FROM Handler h INNER Join Store s on (s.whse_id = h.whse_id) WHERE (s.active_flag = 1 and s.store_id <> 0)  and h.handler_id = '" + userid + "' UNION SELECT 0 storeid, '*** Select One ***' name) A order by A.name";
            SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText);
            while (reader.Read())
            {
                StoreNameIDInfo info = new StoreNameIDInfo();
                info.StoreId = DataAccess.NCI(reader["store_id"]);
                info.StoreName = DataAccess.NCS(reader["name"]);
                list.Add(info);
            }
            reader.Close();
            return (StoreNameIDInfo[]) list.ToArray(typeof(StoreNameIDInfo));
        }

        public static StoreNameIDInfo[] GetStoresOnly(int? storeid, string userid)
        {
            ArrayList list = new ArrayList();
            string commandText = string.Empty;
            commandText = "SELECT DISTINCT s.store_id, s.name FROM Handler h INNER Join Store s on (s.whse_id = h.whse_id) WHERE (s.active_flag = 1 and s.store_id <> 0)  and h.handler_id = '" + userid + "'  order by s.name";
            SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText);
            while (reader.Read())
            {
                StoreNameIDInfo info = new StoreNameIDInfo();
                info.StoreId = DataAccess.NCI(reader["store_id"]);
                info.StoreName = DataAccess.NCS(reader["name"]);
                list.Add(info);
            }
            reader.Close();
            return (StoreNameIDInfo[]) list.ToArray(typeof(StoreNameIDInfo));
        }
    }
}

