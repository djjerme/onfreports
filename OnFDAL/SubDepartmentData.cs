namespace PBA.OnfDAL
{
    using Microsoft.ApplicationBlocks.Data;
    using PBA.OnfInfo;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class SubDepartmentData : DataAccess
    {
        public static SubDepartmentInfo[] GetSubDepartments(int? storeId)
        {
            return GetSubDepartments(storeId, (int?) null);
        }

        public static SubDepartmentInfo[] GetSubDepartments(int? storeId, int? deptId)
        {
            return GetSubDepartments(storeId, deptId, SubDepartmentInfo.SortColumn.Sqn);
        }

        public static SubDepartmentInfo[] GetSubDepartments(int? storeId, int[] deptIds)
        {
            return GetSubDepartments(storeId, deptIds, SubDepartmentInfo.SortColumn.Sqn);
        }

        public static SubDepartmentInfo[] GetSubDepartments(int? storeId, int? deptId, SubDepartmentInfo.SortColumn sortCol)
        {
            return GetSubDepartments(storeId, deptId, sortCol, false);
        }

        public static SubDepartmentInfo[] GetSubDepartments(int? storeId, int[] deptIds, SubDepartmentInfo.SortColumn sortCol)
        {
            return GetSubDepartments(storeId, deptIds, sortCol, false);
        }

        public static SubDepartmentInfo[] GetSubDepartments(int? storeId, int? deptId, SubDepartmentInfo.SortColumn sortCol, bool includeDefault)
        {
            List<SubDepartmentInfo> list = new List<SubDepartmentInfo>();
            StringBuilder builder = new StringBuilder("SELECT \n\tstore_id, \n\tdept_id, \n\tsub_dept_id, \n\tname, \n\tdescrip, \n\titem_page_view, \n\tsqn, \n\tactive_flag, \n\timage_flag \nFROM sub_dept \nWHERE \n\t(store_id = @store_id) \n\tAND (active_flag = 1) \n");
            if (!includeDefault)
            {
                builder.Append("\tAND (sqn > 0) \n");
            }
            if (deptId.HasValue)
            {
                builder.Append("\tAND (dept_id = @dept_id) \n");
            }
            switch (sortCol)
            {
                case SubDepartmentInfo.SortColumn.Name:
                    builder.Append("ORDER BY name \n");
                    break;

                case SubDepartmentInfo.SortColumn.Sqn:
                    builder.Append("ORDER BY sqn \n");
                    break;

                case SubDepartmentInfo.SortColumn.SubDeptId:
                    builder.Append("ORDER BY sub_dept_id \n");
                    break;
            }
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@dept_id", SqlDbType.Int);
            parameter2.Value = deptId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("name");
                    int num2 = reader.GetOrdinal("store_id");
                    int num3 = reader.GetOrdinal("dept_id");
                    int num4 = reader.GetOrdinal("sub_dept_id");
                    int num5 = reader.GetOrdinal("descrip");
                    int num6 = reader.GetOrdinal("item_page_view");
                    int num7 = reader.GetOrdinal("sqn");
                    int num8 = reader.GetOrdinal("active_flag");
                    int num9 = reader.GetOrdinal("image_flag");
                    while (reader.Read())
                    {
                        SubDepartmentInfo item = new SubDepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[num2]);
                        item.DeptId = DataAccess.NCI(reader[num3]);
                        item.SubDeptId = DataAccess.NCI(reader[num4]);
                        item.Name = DataAccess.NCS(reader[ordinal]);
                        item.Descrip = DataAccess.NCS(reader[num5]);
                        item.ItemPageView = DataAccess.NCS(reader[num6]);
                        item.Sqn = DataAccess.NCI(reader[num7]);
                        item.ActiveFlag = DataAccess.NCB(reader[num8]);
                        item.ImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static SubDepartmentInfo[] GetSubDepartments(int? storeId, int[] deptIds, SubDepartmentInfo.SortColumn sortCol, bool includeDefault)
        {
            List<SubDepartmentInfo> list = new List<SubDepartmentInfo>();
            string[] strArray = new string[deptIds.Length];
            for (int i = 0; i < deptIds.Length; i++)
            {
                strArray[i] = deptIds[i].ToString();
            }
            StringBuilder builder = new StringBuilder("SELECT \n\tstore_id, \n\tdept_id, \n\tsub_dept_id, \n\tname, \n\tdescrip, \n\titem_page_view, \n\tsqn, \n\tactive_flag, \n\timage_flag \nFROM sub_dept \nWHERE \n\t(store_id = @store_id) \n\tAND (active_flag = 1) \n");
            builder.AppendFormat("\tAND (dept_id IN({0})) \n", string.Join(", ", strArray));
            if (!includeDefault)
            {
                builder.Append("\tAND (sqn > 0) \n");
            }
            switch (sortCol)
            {
                case SubDepartmentInfo.SortColumn.Name:
                    builder.Append("ORDER BY dept_id, name \n");
                    break;

                case SubDepartmentInfo.SortColumn.Sqn:
                    builder.Append("ORDER BY dept_id, sqn \n");
                    break;

                case SubDepartmentInfo.SortColumn.SubDeptId:
                    builder.Append("ORDER BY dept_id, sub_dept_id \n");
                    break;
            }
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("name");
                    int num3 = reader.GetOrdinal("store_id");
                    int num4 = reader.GetOrdinal("dept_id");
                    int num5 = reader.GetOrdinal("sub_dept_id");
                    int num6 = reader.GetOrdinal("descrip");
                    int num7 = reader.GetOrdinal("item_page_view");
                    int num8 = reader.GetOrdinal("sqn");
                    int num9 = reader.GetOrdinal("active_flag");
                    int num10 = reader.GetOrdinal("image_flag");
                    while (reader.Read())
                    {
                        SubDepartmentInfo item = new SubDepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[num3]);
                        item.DeptId = DataAccess.NCI(reader[num4]);
                        item.SubDeptId = DataAccess.NCI(reader[num5]);
                        item.Name = DataAccess.NCS(reader[ordinal]);
                        item.Descrip = DataAccess.NCS(reader[num6]);
                        item.ItemPageView = DataAccess.NCS(reader[num7]);
                        item.Sqn = DataAccess.NCI(reader[num8]);
                        item.ActiveFlag = DataAccess.NCB(reader[num9]);
                        item.ImageFlag = DataAccess.NCB(reader[num10]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static SubDepartmentInfo[] GetSubDepartmentsAndDefault(int? storeId, int? deptId)
        {
            int? nullable;
            string commandText = string.Empty;
            List<SubDepartmentInfo> list = new List<SubDepartmentInfo>();
            if (deptId.HasValue && (((nullable = deptId).GetValueOrDefault() != 0) || !nullable.HasValue))
            {
                commandText = "SELECT \n\t@store_id AS store_id, \n\t0 AS dept_id, \n\t0 AS sub_dept_id, \n\t'(All)' AS name, \n\t'' AS descrip, \n\t'' AS item_page_view, \n\t0 AS sqn, \n\t0 AS active_flag, \n\t0 AS image_flag \nUNION ALL \nSELECT \n\tstore_id, \n\tdept_id, \n\tsub_dept_id, \n\tname, \n\tdescrip, \n\titem_page_view, \n\tsqn, \n\tactive_flag, \n\timage_flag \nFROM sub_dept \nWHERE \n\t(store_id = @store_id) \n\tAND (dept_id = @dept_id) \n\tAND (sqn > 0) \n\tAND (active_flag = 1) \n ";
            }
            else
            {
                commandText = "SELECT \n\t@store_id AS store_id, \n\t0 AS dept_id, \n\t0 AS sub_dept_id, \n\t'(All)' AS name, \n\t'' AS descrip, \n\t'' AS item_page_view, \n\t0 AS sqn, \n\t0 AS active_flag, \n\t0 AS image_flag \n";
            }
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@dept_id", SqlDbType.Int);
            parameter2.Value = deptId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("name");
                    int num2 = reader.GetOrdinal("store_id");
                    int num3 = reader.GetOrdinal("dept_id");
                    int num4 = reader.GetOrdinal("sub_dept_id");
                    int num5 = reader.GetOrdinal("descrip");
                    int num6 = reader.GetOrdinal("item_page_view");
                    int num7 = reader.GetOrdinal("sqn");
                    int num8 = reader.GetOrdinal("active_flag");
                    int num9 = reader.GetOrdinal("image_flag");
                    while (reader.Read())
                    {
                        SubDepartmentInfo item = new SubDepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[num2]);
                        item.DeptId = DataAccess.NCI(reader[num3]);
                        item.SubDeptId = DataAccess.NCI(reader[num4]);
                        item.Name = DataAccess.NCS(reader[ordinal]);
                        item.Descrip = DataAccess.NCS(reader[num5]);
                        item.ItemPageView = DataAccess.NCS(reader[num6]);
                        item.Sqn = DataAccess.NCI(reader[num7]);
                        item.ActiveFlag = DataAccess.NCB(reader[num8]);
                        item.ImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static string GetSubDeptName(int? storeId, int? deptId, int? subDeptId)
        {
            string commandText = "SELECT name \nFROM sub_dept \nWHERE \n\t(store_id = @store_id) \n\tAND (dept_id = @dept_id) \n\tAND (sub_dept_id = @sub_dept_id) \n";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@dept_id", SqlDbType.Int);
            parameter2.Value = deptId;
            SqlParameter parameter3 = new SqlParameter("@sub_dept_id", SqlDbType.Int);
            parameter3.Value = subDeptId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2, parameter3 };
            return SqlHelper.ExecuteScalar(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters).ToString();
        }
    }
}

