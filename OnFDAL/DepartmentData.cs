namespace PBA.OnfDAL
{
    using Microsoft.ApplicationBlocks.Data;
    using PBA.OnfInfo;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DepartmentData : DataAccess
    {
        public static DepartmentInfo[] GetDepartments(int? storeId)
        {
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            string commandText = "SELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (sqn > 0) \n\tAND (active_flag = 1) \nORDER by name";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        item.SubDepartments = SubDepartmentData.GetSubDepartments(storeId);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static DepartmentInfo[] GetDepartmentsAndDefault(int? storeId, int? superdeptid)
        {
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            string commandText = "SELECT \n\t@store_id AS store_id, \n\t0 AS dept_id, \n\t'(All)' AS name, \n\t'' AS descrip, \n\t'' AS text_color, \n\t0 AS sqn, \n\t0 AS active_flag, \n\t0 AS image_flag, \n\t0 AS thumb_image_flag \nUNION ALL \nSELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (sqn > 0) \n\tAND (active_flag = 1) \n";
            if (superdeptid.HasValue && (superdeptid.Value > -1))
            {
                commandText = commandText + " AND dept_id in (select code from code where store_id = @store_id and class = 'super_dept' and sqn = @superdeptid)";
            }
            commandText = commandText + "ORDER BY name ";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@superdeptid", SqlDbType.Int);
            parameter2.Value = 0;
            if (superdeptid.HasValue)
            {
                parameter2.Value = superdeptid;
            }
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static DepartmentInfo[] GetDepartmentsAndSelectOne(int? storeId)
        {
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            string commandText = "SELECT \n\t@store_id AS store_id, \n\t0 AS dept_id, \n\t'*** Select One ***' AS name, \n\t'' AS descrip, \n\t'' AS text_color, \n\t0 AS sqn, \n\t0 AS active_flag, \n\t0 AS image_flag, \n\t0 AS thumb_image_flag \nUNION ALL \nSELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (sqn > 0) \n\tAND (active_flag = 1) \nORDER BY name";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static DepartmentInfo[] GetDepartmentsOnly(int? storeId)
        {
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            string commandText = "SELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (sqn > 0) \n\tAND (active_flag = 1) \nORDER BY name";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static string GetDeptName(int? storeId, int? deptId)
        {
            string commandText = "SELECT name \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (dept_id = @dept_id) \n";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@dept_id", SqlDbType.Int);
            parameter2.Value = deptId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            return SqlHelper.ExecuteScalar(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters).ToString();
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType)
        {
            return GetDeptsForUserType(storeId, userType, DepartmentInfo.SortColumn.Sqn);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol)
        {
            return GetDeptsForUserType(storeId, userType, deptSortCol, false);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds)
        {
            return GetDeptsForUserType(storeId, userType, deptIds, DepartmentInfo.SortColumn.Sqn);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol)
        {
            return GetDeptsForUserType(storeId, userType, deptIds, deptSortCol, false);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts)
        {
            return GetDeptsForUserType(storeId, userType, deptSortCol, loadSubDepts, SubDepartmentInfo.SortColumn.Sqn);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts)
        {
            return GetDeptsForUserType(storeId, userType, deptIds, deptSortCol, loadSubDepts, SubDepartmentInfo.SortColumn.Sqn);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol)
        {
            return GetDeptsForUserType(storeId, userType, deptSortCol, loadSubDepts, subDeptSortCol, true);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol)
        {
            return GetDeptsForUserType(storeId, userType, deptIds, deptSortCol, loadSubDepts, subDeptSortCol, true);
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol, bool activeDeptsOnly)
        {
            string str;
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            switch (deptSortCol)
            {
                case DepartmentInfo.SortColumn.DeptId:
                    str = "dept_id";
                    break;

                case DepartmentInfo.SortColumn.Name:
                    str = "name";
                    break;

                case DepartmentInfo.SortColumn.Sqn:
                    str = "sqn";
                    break;

                default:
                    str = "sqn";
                    break;
            }
            StringBuilder builder = new StringBuilder("SELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (sqn > 0) \n\tAND (sqn <> 99) \n");
            if (activeDeptsOnly)
            {
                builder.Append("\tAND (active_flag = 1) \n");
            }
            builder.AppendFormat("\tAND (dept_id not in( \n\t\tSELECT dept_id \n\t\tFROM dept_usertype \n\t\tWHERE (store_id = @store_id) \n\t\tAND (user_type = @user_type) \n\t\tAND (access_flag = 0) \n\t)) \nORDER BY {0} \n", str);
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@user_type", SqlDbType.VarChar, 0xff);
            parameter2.Value = userType;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            if (loadSubDepts)
            {
                int? deptId;
                List<int> list2 = new List<int>();
                for (int i = 0; i < list.Count; i++)
                {
                    deptId = list[i].DeptId;
                    if (deptId.HasValue)
                    {
                        list2.Add(deptId.Value);
                    }
                }
                if (list2.Count > 0)
                {
                    SubDepartmentInfo[] infoArray = SubDepartmentData.GetSubDepartments(storeId, list2.ToArray(), subDeptSortCol, false);
                    Dictionary<int, SubDepartmentInfo[]> dictionary = new Dictionary<int, SubDepartmentInfo[]>(4);
                    List<SubDepartmentInfo> list3 = null;
                    if ((infoArray != null) && (infoArray.Length > 0))
                    {
                        int num11 = -2147483648;
                        int num12 = infoArray[0].DeptId.Value;
                        list3 = new List<SubDepartmentInfo>(4);
                        foreach (SubDepartmentInfo info2 in infoArray)
                        {
                            num11 = info2.DeptId.Value;
                            if (num11 != num12)
                            {
                                dictionary[num12] = list3.ToArray();
                                list3.Clear();
                                num12 = num11;
                            }
                            list3.Add(info2);
                        }
                        if (list3.Count > 0)
                        {
                            dictionary[num11] = list3.ToArray();
                        }
                        foreach (DepartmentInfo info in list)
                        {
                            deptId = info.DeptId;
                            if (deptId.HasValue && dictionary.ContainsKey(deptId.Value))
                            {
                                info.SubDepartments = dictionary[deptId.Value];
                            }
                        }
                    }
                }
            }
            return list.ToArray();
        }

        public static DepartmentInfo[] GetDeptsForUserType(int? storeId, string userType, int[] deptIds, DepartmentInfo.SortColumn deptSortCol, bool loadSubDepts, SubDepartmentInfo.SortColumn subDeptSortCol, bool activeDeptsOnly)
        {
            int? deptId;
            int num;
            string str;
            string[] strArray = new string[deptIds.Length];
            for (num = 0; num < deptIds.Length; num++)
            {
                strArray[num] = deptIds[num].ToString();
            }
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            switch (deptSortCol)
            {
                case DepartmentInfo.SortColumn.DeptId:
                    str = "dept_id";
                    break;

                case DepartmentInfo.SortColumn.Name:
                    str = "name";
                    break;

                case DepartmentInfo.SortColumn.Sqn:
                    str = "sqn";
                    break;

                default:
                    str = "sqn";
                    break;
            }
            StringBuilder builder = new StringBuilder("SELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n");
            builder.AppendFormat("\tAND (dept_id IN({0})) \n", string.Join(", ", strArray));
            builder.Append("\tAND (sqn > 0) \n\tAND (sqn <> 99) \n");
            if (activeDeptsOnly)
            {
                builder.Append("\tAND (active_flag = 1) \n");
            }
            builder.AppendFormat("\tAND (dept_id not in( \n\t\tSELECT dept_id \n\t\tFROM dept_usertype \n\t\tWHERE (store_id = @store_id) \n\t\tAND (user_type = @user_type) \n\t\tAND (access_flag = 0) \n\t)) \nORDER BY {0} \n", str);
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@user_type", SqlDbType.VarChar, 0xff);
            parameter2.Value = userType;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num3 = reader.GetOrdinal("dept_id");
                    int num4 = reader.GetOrdinal("name");
                    int num5 = reader.GetOrdinal("descrip");
                    int num6 = reader.GetOrdinal("text_color");
                    int num7 = reader.GetOrdinal("sqn");
                    int num8 = reader.GetOrdinal("active_flag");
                    int num9 = reader.GetOrdinal("image_flag");
                    int num10 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        deptId = DataAccess.NCI(reader[num3]);
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = deptId;
                        item.Name = DataAccess.NCS(reader[num4]);
                        item.Descrip = DataAccess.NCS(reader[num5]);
                        item.TextColor = DataAccess.NCS(reader[num6]);
                        item.Sqn = DataAccess.NCI(reader[num7]);
                        item.ActiveFlag = DataAccess.NCB(reader[num8]);
                        item.ImageFlag = DataAccess.NCB(reader[num9]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num10]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            if (loadSubDepts)
            {
                List<int> list2 = new List<int>();
                for (num = 0; num < list.Count; num++)
                {
                    deptId = list[num].DeptId;
                    if (deptId.HasValue)
                    {
                        list2.Add(deptId.Value);
                    }
                }
                if (list2.Count > 0)
                {
                    SubDepartmentInfo[] infoArray = SubDepartmentData.GetSubDepartments(storeId, list2.ToArray(), subDeptSortCol, false);
                    Dictionary<int, SubDepartmentInfo[]> dictionary = new Dictionary<int, SubDepartmentInfo[]>(4);
                    List<SubDepartmentInfo> list3 = null;
                    if ((infoArray != null) && (infoArray.Length > 0))
                    {
                        int num11 = -2147483648;
                        int num12 = infoArray[0].DeptId.Value;
                        list3 = new List<SubDepartmentInfo>(4);
                        foreach (SubDepartmentInfo info2 in infoArray)
                        {
                            num11 = info2.DeptId.Value;
                            if (num11 != num12)
                            {
                                dictionary[num12] = list3.ToArray();
                                list3.Clear();
                                num12 = num11;
                            }
                            list3.Add(info2);
                        }
                        if (list3.Count > 0)
                        {
                            dictionary[num11] = list3.ToArray();
                        }
                        foreach (DepartmentInfo info in list)
                        {
                            deptId = info.DeptId;
                            if (deptId.HasValue && dictionary.ContainsKey(deptId.Value))
                            {
                                info.SubDepartments = dictionary[deptId.Value];
                            }
                        }
                    }
                }
            }
            return list.ToArray();
        }

        public static DepartmentInfo[] GetDeptsFromProduct(int? storeId, int productId)
        {
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            string commandText = new StringBuilder("SELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (sqn > 0) \n\tAND (sqn <> 99) \n\tAND (active_flag = 1) \n AND dept_id in (select top 1 dept_id from dept_product where store_id = @store_id and active_flag = 1 and product_id = @product_id) \n").ToString();
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@product_id", SqlDbType.Int);
            parameter2.Value = productId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static DepartmentInfo[] GetDeptsFromSuperDept(int? storeId, string superDept)
        {
            List<DepartmentInfo> list = new List<DepartmentInfo>();
            string commandText = new StringBuilder("SELECT \n\tstore_id, \n\tdept_id, \n\tname, \n\tdescrip, \n\ttext_color, \n\tsqn, \n\tactive_flag, \n\timage_flag, \n\tthumb_image_flag \nFROM dept \nWHERE \n\t(store_id = @store_id) \n\tAND (dept_id in( \n\t\tSELECT code \n\t\tFROM code \n\t\tWHERE (store_id = @store_id) \n\t\tAND (class = 'super_dept') \n\t\tAND (label = @super_dept) \n\t)) \n").ToString();
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@super_dept", SqlDbType.VarChar, 0xff);
            parameter2.Value = superDept;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("store_id");
                    int num2 = reader.GetOrdinal("dept_id");
                    int num3 = reader.GetOrdinal("name");
                    int num4 = reader.GetOrdinal("descrip");
                    int num5 = reader.GetOrdinal("text_color");
                    int num6 = reader.GetOrdinal("sqn");
                    int num7 = reader.GetOrdinal("active_flag");
                    int num8 = reader.GetOrdinal("image_flag");
                    int num9 = reader.GetOrdinal("thumb_image_flag");
                    while (reader.Read())
                    {
                        DepartmentInfo item = new DepartmentInfo();
                        item.StoreId = DataAccess.NCI(reader[ordinal]);
                        item.DeptId = DataAccess.NCI(reader[num2]);
                        item.Name = DataAccess.NCS(reader[num3]);
                        item.Descrip = DataAccess.NCS(reader[num4]);
                        item.TextColor = DataAccess.NCS(reader[num5]);
                        item.Sqn = DataAccess.NCI(reader[num6]);
                        item.ActiveFlag = DataAccess.NCB(reader[num7]);
                        item.ImageFlag = DataAccess.NCB(reader[num8]);
                        item.ThumbImageFlag = DataAccess.NCB(reader[num9]);
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static bool itemExists(PBA.OnfInfo.ItemInfo item, int deptId)
        {
            string commandText = "SELECT store_id \nFROM dept_product \nWHERE \n\t(store_id = @store_id) \n\tAND (dept_id = @dept_id) \n AND (product_id = @product_id) \n";
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.Int);
            parameter.Value = item.StoreId.Value;
            SqlParameter parameter2 = new SqlParameter("@dept_id", SqlDbType.Int);
            parameter2.Value = deptId;
            SqlParameter parameter3 = new SqlParameter("@product_id", SqlDbType.Int);
            parameter3.Value = item.ProductId.Value;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2, parameter3 };
            return (SqlHelper.ExecuteScalar(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters) != null);
        }
    }
}

