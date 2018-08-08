namespace PBA.OnfDAL
{
    using Microsoft.ApplicationBlocks.Data;
    using PBA.OnfInfo;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class AddressBookEntryData : DataAccess
    {
        public static AddressBookEntryInfo[] GetPersonalAddressList(int? storeId, int personId, int listId)
        {
            return GetPersonalAddressList(storeId, personId, listId, null, null, null, null);
        }

        public static AddressBookEntryInfo[] GetPersonalAddressList(int? storeId, int personId, int listId, string firstName, string lastName, string city, string companyName)
        {
            List<AddressBookEntryInfo> list = new List<AddressBookEntryInfo>(0x10);
            StringBuilder builder = new StringBuilder("SELECT \n\tp.person_id, \n\tISNULL(p.first_name, '') AS first_name, \n\tISNULL(p.last_name, '') AS last_name, \n\tp.external_ID, \n\ta.address_id, \n\tISNULL(a.label, '') AS label, \n\tISNULL(a.city, '') AS city, \n\tISNULL(a.state, '') AS state, \n\tISNULL(a.company, '') AS company \nFROM person AS p \nINNER JOIN address AS a \n\tON (p.store_id = a.store_id) AND (p.person_id = a.person_id) AND (0 = a.address_id) \nWHERE \n\t(p.store_id = @store_id) \n\tAND (p.person_type = 'L') \n\tAND (p.person_id IN( \n\t\tSELECT member_id \n\t\tFROM user_list_members AS ulm \n\t\tWHERE \n\t\t\t(ulm.store_id = @store_id) \n\t\t\tAND (ulm.person_id = @person_id) \n\t\t\tAND (list_id = @list_id) \n\t)) \n\tAND (a.address_id = 0) \n");
            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName + "%";
                builder.Append("\tAND (p.first_name like @first_name) \n ");
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName + "%";
                builder.Append("\tAND (p.last_name like @last_name) \n ");
            }
            if (!string.IsNullOrEmpty(city))
            {
                city = city + "%";
                builder.Append("\tAND (a.city like @city) \n ");
            }
            if (!string.IsNullOrEmpty(companyName))
            {
                companyName = companyName + "%";
                builder.Append("\tAND (a.company like @company) \n ");
            }
            builder.Append("ORDER BY a.label \n");
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@first_name", SqlDbType.NVarChar, 160);
            parameter2.Value = firstName;
            SqlParameter parameter3 = new SqlParameter("@last_name", SqlDbType.NVarChar, 160);
            parameter3.Value = lastName;
            SqlParameter parameter4 = new SqlParameter("@city", SqlDbType.NVarChar, 100);
            parameter4.Value = city;
            SqlParameter parameter5 = new SqlParameter("@company", SqlDbType.NVarChar, 160);
            parameter5.Value = companyName;
            SqlParameter parameter6 = new SqlParameter("@person_id", SqlDbType.Int);
            parameter6.Value = personId;
            SqlParameter parameter7 = new SqlParameter("@list_id", SqlDbType.TinyInt);
            parameter7.Value = listId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("person_id");
                    int num2 = reader.GetOrdinal("first_name");
                    int num3 = reader.GetOrdinal("last_name");
                    int num4 = reader.GetOrdinal("external_ID");
                    int num5 = reader.GetOrdinal("address_id");
                    int num6 = reader.GetOrdinal("label");
                    int num7 = reader.GetOrdinal("city");
                    int num8 = reader.GetOrdinal("state");
                    int num9 = reader.GetOrdinal("company");
                    while (reader.Read())
                    {
                        int? nullable = DataAccess.NCI(reader[num5]);
                        int? nullable2 = DataAccess.NCI(reader[ordinal]);
                        AddressBookEntryInfo item = new AddressBookEntryInfo();
                        item.IsExternal = false;
                        item.AddressId = nullable;
                        item.PersonId = nullable2;
                        AddressInfo info = new AddressInfo();
                        PersonInfo info2 = new PersonInfo();
                        info2.PersonId = nullable2;
                        info2.FirstName = DataAccess.NCS(reader[num2]);
                        info2.LastName = DataAccess.NCS(reader[num3]);
                        info2.ExternalID = DataAccess.NCS(reader[num4]);
                        item.Person = info2;
                        info.AddressId = nullable;
                        info.Label = DataAccess.NCS(reader[num6]);
                        info.City = DataAccess.NCS(reader[num7]);
                        info.State = DataAccess.NCS(reader[num8]);
                        info.Company = DataAccess.NCS(reader[num9]);
                        item.Address = info;
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static AddressBookEntryInfo[] GetPersonList(int? storeId, int personId, int listId)
        {
            return GetPersonList(storeId, personId, listId, null, null);
        }

        public static AddressBookEntryInfo[] GetPersonList(int? storeId, int personId, int listId, string firstName, string lastName)
        {
            return GetPersonList(storeId, personId, listId, firstName, lastName, null, null);
        }

        public static AddressBookEntryInfo[] GetPersonList(int? storeId, int personId, int listId, string firstName, string lastName, string city, string companyName)
        {
            List<AddressBookEntryInfo> list = new List<AddressBookEntryInfo>(0x10);
            StringBuilder builder = new StringBuilder("SELECT \n\tp.person_id, \n\tISNULL(p.first_name, '') AS first_name, \n\tISNULL(p.last_name, '') AS last_name, \n\tp.external_ID, \n\ta.address_id, \n\tISNULL(a.label, '') AS label, \n\tISNULL(a.city, '') AS city, \n\tISNULL(a.state, '') AS state, \n\tISNULL(a.company, '') AS company \nFROM person AS p \nINNER JOIN address AS a \n\tON (p.store_id = a.store_id) AND (p.person_id = a.person_id) AND (0 = a.address_id) \nWHERE \n\t(p.store_id = @store_id) \n\tAND (p.external_ID IS NULL) \n\tAND (p.person_id IN( \n\t\tSELECT member_id \n\t\tFROM user_list_members AS ulm \n\t\tWHERE \n\t\t\t(ulm.store_id = @store_id) \n\t\t\tAND (ulm.person_id = @person_id) \n\t\t\tAND (list_id = @list_id) \n\t)) \n\tAND (a.address_id = 0) \n");
            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName + "%";
                builder.Append("\tAND (p.first_name like @first_name) \n ");
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName + "%";
                builder.Append("\tAND (p.last_name like @last_name) \n ");
            }
            if (!string.IsNullOrEmpty(city))
            {
                city = city + "%";
                builder.Append("\tAND (a.city like @city) \n ");
            }
            if (!string.IsNullOrEmpty(companyName))
            {
                companyName = companyName + "%";
                builder.Append("\tAND (a.company like @company) \n ");
            }
            if (storeId.Value == 0x120)
            {
                builder.Append("ORDER BY a.label \n");
            }
            else
            {
                builder.Append("ORDER BY p.last_name \n");
            }
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@first_name", SqlDbType.NVarChar, 160);
            parameter2.Value = firstName;
            SqlParameter parameter3 = new SqlParameter("@last_name", SqlDbType.NVarChar, 160);
            parameter3.Value = lastName;
            SqlParameter parameter4 = new SqlParameter("@city", SqlDbType.NVarChar, 100);
            parameter4.Value = city;
            SqlParameter parameter5 = new SqlParameter("@company", SqlDbType.NVarChar, 160);
            parameter5.Value = companyName;
            SqlParameter parameter6 = new SqlParameter("@person_id", SqlDbType.Int);
            parameter6.Value = personId;
            SqlParameter parameter7 = new SqlParameter("@list_id", SqlDbType.TinyInt);
            parameter7.Value = listId;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("person_id");
                    int num2 = reader.GetOrdinal("first_name");
                    int num3 = reader.GetOrdinal("last_name");
                    int num4 = reader.GetOrdinal("external_ID");
                    int num5 = reader.GetOrdinal("address_id");
                    int num6 = reader.GetOrdinal("label");
                    int num7 = reader.GetOrdinal("city");
                    int num8 = reader.GetOrdinal("state");
                    int num9 = reader.GetOrdinal("company");
                    while (reader.Read())
                    {
                        int? nullable = DataAccess.NCI(reader[num5]);
                        int? nullable2 = DataAccess.NCI(reader[ordinal]);
                        AddressBookEntryInfo item = new AddressBookEntryInfo();
                        item.IsExternal = false;
                        item.AddressId = nullable;
                        item.PersonId = nullable2;
                        AddressInfo info = new AddressInfo();
                        PersonInfo info2 = new PersonInfo();
                        info2.PersonId = nullable2;
                        info2.FirstName = DataAccess.NCS(reader[num2]);
                        info2.LastName = DataAccess.NCS(reader[num3]);
                        info2.ExternalID = DataAccess.NCS(reader[num4]);
                        item.Person = info2;
                        info.AddressId = nullable;
                        info.Label = DataAccess.NCS(reader[num6]);
                        info.City = DataAccess.NCS(reader[num7]);
                        info.State = DataAccess.NCS(reader[num8]);
                        info.Company = DataAccess.NCS(reader[num9]);
                        item.Address = info;
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }

        public static AddressBookEntryInfo[] GetStoreList(int? storeId, int personId, int listId, string personType)
        {
            return GetStoreList(storeId, personId, listId, personType, null, null);
        }

        public static AddressBookEntryInfo[] GetStoreList(int? storeId, int personId, int listId, string personType, string firstName, string lastName)
        {
            return GetStoreList(storeId, personId, listId, personType, firstName, lastName, null, null, null);
        }

        public static AddressBookEntryInfo[] GetStoreList(int? storeId, int personId, int listId, string personType, string firstName, string lastName, string city, string companyName, string customerCode)
        {
            List<AddressBookEntryInfo> list = new List<AddressBookEntryInfo>(0x10);
            int num = 0;
            string str = "address";
            string str2 = "person";
            string str3 = "p.last_name, a.address_id";
            personType = personType.ToLower();
            if (((personType == "b") || (personType == "c")) || (personType == "s"))
            {
                num = 1;
                str = "external_address";
                str2 = "external_person";
                if (storeId.Value == 0xee)
                {
                    str3 = "external_ID";
                }
                else
                {
                    str3 = "ISNULL(a.company, ''), a.city, a.address_1";
                }
            }
            StringBuilder builder = new StringBuilder("SELECT DISTINCT \n\tp.person_id, \n\tISNULL(p.first_name, '') AS first_name, \n\tISNULL(p.last_name, '') AS last_name, \n\tp.external_ID, \n\ta.address_id, \n\tISNULL(a.company, '') AS company, \n\ta.address_1, \n\tISNULL(a.city, '') AS city, \n\tISNULL(a.state, '') AS state, \n");
            builder.AppendFormat("\tCAST({0} AS bit) AS is_external \n", num);
            builder.AppendFormat("FROM {0} AS p \n", str2);
            builder.AppendFormat("INNER JOIN {0} AS a \n", str);
            builder.Append("\tON (p.store_id = a.store_id) AND (p.person_id = a.person_id) \nWHERE \n\t(p.store_id = @store_id) \n\tAND (p.person_type = @person_type) \n\tAND ((p.first_name IS NOT NULL) OR (p.last_name IS NOT NULL)) \n");
            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName + "%";
                builder.Append("\tAND (p.first_name like @first_name) \n ");
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName + "%";
                builder.Append("\tAND (p.last_name like @last_name) \n ");
            }
            if (!string.IsNullOrEmpty(city))
            {
                city = city + "%";
                builder.Append("\tAND (a.city like @city) \n ");
            }
            if (!string.IsNullOrEmpty(companyName))
            {
                companyName = companyName + "%";
                builder.Append("\tAND (a.company like @company) \n ");
            }
            int[] array = new int[] { 0xdb, 0xee, 0xff, 0x100, 0x106, 280 };
            Array.Sort<int>(array);
            if (Array.BinarySearch<int>(array, storeId.Value) > -1)
            {
                if (!(((!(personType == "b") && !(personType == "c")) && !(personType == "s")) || string.IsNullOrEmpty(customerCode)))
                {
                    customerCode = customerCode + "%";
                    builder.Append("\tAND (p.external_ID like @external_id) \n ");
                }
                else
                {
                    builder.Append("\tAND (p.external_ID IS NULL) \n ");
                }
            }
            builder.AppendFormat("ORDER BY {0} \n", str3);
            string commandText = builder.ToString();
            builder = null;
            SqlParameter parameter = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parameter.Value = storeId;
            SqlParameter parameter2 = new SqlParameter("@person_type", SqlDbType.Char, 1);
            parameter2.Value = personType;
            SqlParameter parameter3 = new SqlParameter("@first_name", SqlDbType.NVarChar, 160);
            parameter3.Value = firstName;
            SqlParameter parameter4 = new SqlParameter("@last_name", SqlDbType.NVarChar, 160);
            parameter4.Value = lastName;
            SqlParameter parameter5 = new SqlParameter("@city", SqlDbType.NVarChar, 100);
            parameter5.Value = city;
            SqlParameter parameter6 = new SqlParameter("@company", SqlDbType.NVarChar, 160);
            parameter6.Value = companyName;
            SqlParameter parameter7 = new SqlParameter("@external_id", SqlDbType.VarChar, 50);
            parameter7.Value = customerCode;
            SqlParameter[] commandParameters = new SqlParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(DataAccess.dbConnection, CommandType.Text, commandText, commandParameters))
            {
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal("person_id");
                    int num3 = reader.GetOrdinal("first_name");
                    int num4 = reader.GetOrdinal("last_name");
                    int num5 = reader.GetOrdinal("external_ID");
                    int num6 = reader.GetOrdinal("address_id");
                    int num7 = reader.GetOrdinal("company");
                    int num8 = reader.GetOrdinal("address_1");
                    int num9 = reader.GetOrdinal("city");
                    int num10 = reader.GetOrdinal("state");
                    int num11 = reader.GetOrdinal("is_external");
                    while (reader.Read())
                    {
                        int? nullable = DataAccess.NCI(reader[num6]);
                        int? nullable2 = DataAccess.NCI(reader[ordinal]);
                        AddressBookEntryInfo item = new AddressBookEntryInfo();
                        item.IsExternal = reader.GetBoolean(num11);
                        item.AddressId = nullable;
                        item.PersonId = nullable2;
                        AddressInfo info = new AddressInfo();
                        PersonInfo info2 = new PersonInfo();
                        info2.PersonId = nullable2;
                        info2.FirstName = DataAccess.NCS(reader[num3]);
                        info2.LastName = DataAccess.NCS(reader[num4]);
                        info2.ExternalID = DataAccess.NCS(reader[num5]);
                        item.Person = info2;
                        info.AddressId = nullable;
                        info.Company = DataAccess.NCS(reader[num7]);
                        info.Address1 = DataAccess.NCS(reader[num8]);
                        info.City = DataAccess.NCS(reader[num9]);
                        info.State = DataAccess.NCS(reader[num10]);
                        item.Address = info;
                        list.Add(item);
                    }
                }
                reader.Close();
            }
            return list.ToArray();
        }
    }
}

