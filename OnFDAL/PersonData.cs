using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL {
	public class PersonData : PBA.OnfDAL.DataAccess {
		public static void Delete(PersonInfo person) {
			int? storeId = person.StoreId;
			int? personId = person.PersonId;

			Delete(storeId, personId);
		}

		public static void Delete(int? storeId, int? personId) {
			AddressData.Delete(storeId, personId);

			string sql = ""
				+ "DELETE FROM person \n"
				+ "WHERE \n"
				+ "	(store_id = @store_id) \n"
				+ "	AND (person_id = @person_id) \n"
			;

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
			parmStoreId.Value = storeId;

			SqlParameter parmPersonId = new SqlParameter("@person_id", SqlDbType.Int);
			parmPersonId.Value = personId;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
				parmPersonId
			};

			SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql, cmdParms);
		}


		public static PersonInfo[] GetPerson(int storeId, string loginId) 
        {
            PersonInfo[] persons = null;

			string sql = ""
				+ "SELECT person_id \n"
				+ "FROM person \n"
				+ "WHERE \n"
				+ "	(store_id = @store_id) \n"
				+ "	AND (login_id = @login_id) \n"
			;

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
			parmStoreId.Value = storeId;

			SqlParameter parmLoginId = new SqlParameter("@login_id", SqlDbType.VarChar, 255);
			parmLoginId.Value = loginId;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
				parmLoginId
			};

            object personid = SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql, cmdParms);
            if (personid != null)
            {
                persons = GetPerson(storeId, (int)personid);
            }

            return persons;
		}


        public static PersonInfo[] GetPerson(int storeId, string loginIdAndEmail, bool loginUsersOnly)
        {
            PersonInfo[] persons = null;

            string sql = ""
                + "SELECT person_id \n "
                + "FROM person \n "
                + "WHERE \n "
                + "	(store_id = @store_id) \n "
                + "	AND (login_id = @login_id_and_email) \n ";

            if (loginUsersOnly)
            {
                sql += "AND user_type is not null \n ";
            }

            sql += " UNION \n "
                + "SELECT person_id \n "
                + "FROM person \n "
                + "WHERE \n "
                + "	(store_id = @store_id) \n "
                + "	AND (email = @login_id_and_email) \n ";

            if (loginUsersOnly)
            {
                sql += "AND user_type is not null \n ";
            }


            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId;

            SqlParameter parmLoginIdAndEmail = new SqlParameter("@login_id_and_email", SqlDbType.VarChar, 255);
            parmLoginIdAndEmail.Value = loginIdAndEmail;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
				parmLoginIdAndEmail
			};

            object personid = SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql, cmdParms);
            if (personid != null)
            {
                persons = GetPerson(storeId, (int)personid);
            }

            return persons;
        }

        public static PersonInfo[] GetUserTypePersons(int? storeId, UserTypeInfo[] usertypes, bool includeAddress)
        {
            List<PersonInfo> personList = new List<PersonInfo>();

            string uTypesStr = "";
            foreach (UserTypeInfo uti in usertypes)
            {
                if (string.IsNullOrEmpty(uti.UserType)) { continue; }
                if (uTypesStr != "") { uTypesStr += ","; }
                uTypesStr += "'" + uti.UserType + "'";
            }

            if (string.IsNullOrEmpty(uTypesStr)) { return personList.ToArray(); }
            string sql = ""
                + "SELECT * \n"
                + "FROM person \n"
                + "WHERE \n"
                + "	(store_id = @store_id) \n"
                + "	AND (active_flag = 1) \n"
                + "	AND (user_type in (" + uTypesStr + ")) \n"
            ;

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId.Value;

            // SqlParameter parmUTypes = new SqlParameter("@utypes", SqlDbType.VarChar, 255);
            // parmUTypes.Value = uTypesStr;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
                {
                    if (reader.HasRows)
                    {
                        int idxStoreId = reader.GetOrdinal("store_id");
                        int idxPersonId = reader.GetOrdinal("person_id");
                        int idxNamePrefix = reader.GetOrdinal("name_prefix");
                        int idxNameSuffix = reader.GetOrdinal("name_suffix");
                        int idxFirstName = reader.GetOrdinal("first_name");
                        int idxMiddleName = reader.GetOrdinal("middle_name");
                        int idxLastName = reader.GetOrdinal("last_name");
                        int idxBusPhone = reader.GetOrdinal("bus_phone");
                        int idxHomePhone = reader.GetOrdinal("home_phone");
                        int idxCellPhone = reader.GetOrdinal("cell_phone");
                        int idxFaxPhone = reader.GetOrdinal("fax_phone");
                        int idxEmail = reader.GetOrdinal("email");
                        int idxUrl = reader.GetOrdinal("url");
                        int idxUserType = reader.GetOrdinal("user_type");
                        int idxLoginId = reader.GetOrdinal("login_id");
                        int idxPassword = reader.GetOrdinal("password");
                        int idxRepresentative = reader.GetOrdinal("representative");
                        int idxCostCenter = reader.GetOrdinal("cost_center");
                        int idxDepartment = reader.GetOrdinal("department");
                        int idxActiveFlag = reader.GetOrdinal("active_flag");
                        int idxLabel = reader.GetOrdinal("label");
                        int idxITemp = reader.GetOrdinal("iTemp");
                        int idxPersonType = reader.GetOrdinal("person_type");
                        int idxRegion = reader.GetOrdinal("region");
                        int idxSentInviteFlag = reader.GetOrdinal("SentInvite_flag");
                        int idxSiteTermsFlag = reader.GetOrdinal("site_terms_flag");
                        int idxExternalID = reader.GetOrdinal("external_ID");
                        int idxLastLoginTime = reader.GetOrdinal("last_login_time");
                        int idxCurrentLoginTime = reader.GetOrdinal("current_login_time");
                        int idxLoginSource = reader.GetOrdinal("login_source");
                        int idxStoreRepresentativeName = reader.GetOrdinal("store_representative_name");

                        while (reader.Read())
                        {
                            PersonInfo pi = new PersonInfo();

                            pi.StoreId = NCI(reader[idxStoreId]);
                            pi.PersonId = NCI(reader[idxPersonId]);
                            pi.NamePrefix = NCS(reader[idxNamePrefix]);
                            pi.NameSuffix = NCS(reader[idxNameSuffix]);
                            pi.FirstName = NCS(reader[idxFirstName]);
                            pi.MiddleName = NCS(reader[idxMiddleName]);
                            pi.LastName = NCS(reader[idxLastName]);
                            pi.BusPhone = NCS(reader[idxBusPhone]);
                            pi.HomePhone = NCS(reader[idxHomePhone]);
                            pi.CellPhone = NCS(reader[idxCellPhone]);
                            pi.FaxPhone = NCS(reader[idxFaxPhone]);
                            pi.Email = NCS(reader[idxEmail]);
                            pi.Url = NCS(reader[idxUrl]);
                            pi.UserType = NCS(reader[idxUserType]);
                            pi.LoginId = NCS(reader[idxLoginId]);
                            pi.Password = NCS(reader[idxPassword]);
                            pi.Representative = NCI(reader[idxRepresentative]);
                            pi.CostCenter = NCS(reader[idxCostCenter]);
                            pi.Department = NCS(reader[idxDepartment]);
                            pi.ActiveFlag = NCB(reader[idxActiveFlag]);
                            pi.Label = NCS(reader[idxLabel]);
                            pi.ITemp = NCI(reader[idxITemp]);
                            pi.PersonType = NCS(reader[idxPersonType]);
                            pi.Region = NCS(reader[idxRegion]);
                            pi.SentInviteFlag = NCB(reader[idxSentInviteFlag]);
                            pi.SiteTermsFlag = NCB(reader[idxSiteTermsFlag]);
                            pi.ExternalID = NCS(reader[idxExternalID]);
                            pi.LastLoginTime = NCD(reader[idxLastLoginTime]);
                            pi.CurrentLoginTime = NCD(reader[idxCurrentLoginTime]);
                            pi.LoginSource = NCS(reader[idxLoginSource]);
                            pi.StoreRepresentativeName = NCS(reader[idxStoreRepresentativeName]);

                            if (includeAddress)
                            {
                                pi.Addresses = AddressData.GetAddress(storeId.Value, pi.PersonId.Value);
                            }

                            personList.Add(pi);
                        }
                    }
                    reader.Close();
                }
            }
            catch { }
            return personList.ToArray();
        }

        public static PersonInfo[] GetActivePerson(int storeId, string loginId)
        {
            PersonInfo[] persons = null;

            string sql = ""
                + "SELECT person_id \n"
                + "FROM person \n"
                + "WHERE \n"
                + "	(store_id = @store_id) \n"
                + "	AND (login_id = @login_id) \n"
                + " AND (active_flag = 1) \n"
            ;

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId;

            SqlParameter parmLoginId = new SqlParameter("@login_id", SqlDbType.VarChar, 255);
            parmLoginId.Value = loginId;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
				parmLoginId
			};

            object personid = SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql, cmdParms);
            if (personid != null)
            {
                persons = GetPerson(storeId, (int)personid);
            }

            return persons;
        }

		public static PersonInfo[] GetPerson(int storeId, int personId) {
			List<PersonInfo> personList = new List<PersonInfo>();

			string sql = ""
				+ "SELECT * \n"
				+ "FROM person \n"
				+ "WHERE \n"
				+ "	(store_id = @store_id) \n"
				+ "	AND (person_id = @person_id) \n"
			;

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
			parmStoreId.Value = storeId;

			SqlParameter parmPersonId = new SqlParameter("@person_id", SqlDbType.Int);
			parmPersonId.Value = personId;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId,
				parmPersonId
			};

			using(SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms)) {
				if(reader.HasRows) {
					int idxStoreId = reader.GetOrdinal("store_id");
					int idxPersonId = reader.GetOrdinal("person_id");
					int idxNamePrefix = reader.GetOrdinal("name_prefix");
					int idxNameSuffix = reader.GetOrdinal("name_suffix");
					int idxFirstName = reader.GetOrdinal("first_name");
					int idxMiddleName = reader.GetOrdinal("middle_name");
					int idxLastName = reader.GetOrdinal("last_name");
					int idxBusPhone = reader.GetOrdinal("bus_phone");
					int idxHomePhone = reader.GetOrdinal("home_phone");
					int idxCellPhone = reader.GetOrdinal("cell_phone");
					int idxFaxPhone = reader.GetOrdinal("fax_phone");
					int idxEmail = reader.GetOrdinal("email");
					int idxUrl = reader.GetOrdinal("url");
					int idxUserType = reader.GetOrdinal("user_type");
					int idxLoginId = reader.GetOrdinal("login_id");
					int idxPassword = reader.GetOrdinal("password");
					int idxRepresentative = reader.GetOrdinal("representative");
					int idxCostCenter = reader.GetOrdinal("cost_center");
					int idxDepartment = reader.GetOrdinal("department");
					int idxActiveFlag = reader.GetOrdinal("active_flag");
					int idxLabel = reader.GetOrdinal("label");
					int idxITemp = reader.GetOrdinal("iTemp");
					int idxPersonType = reader.GetOrdinal("person_type");
					int idxRegion = reader.GetOrdinal("region");
                    int idxSentInviteFlag = reader.GetOrdinal("SentInvite_flag");
                    int idxSiteTermsFlag = reader.GetOrdinal("site_terms_flag");
					int idxExternalID = reader.GetOrdinal("external_ID");
					int idxLastLoginTime = reader.GetOrdinal("last_login_time");
                    int idxCurrentLoginTime = reader.GetOrdinal("current_login_time");
                    int idxLoginSource = reader.GetOrdinal("login_source");
                    int idxStoreRepresentativeName = reader.GetOrdinal("store_representative_name");

					while(reader.Read()) {
						PersonInfo pi = new PersonInfo();

						pi.StoreId = NCI(reader[idxStoreId]);
						pi.PersonId = NCI(reader[idxPersonId]);
						pi.NamePrefix = NCS(reader[idxNamePrefix]);
						pi.NameSuffix = NCS(reader[idxNameSuffix]);
						pi.FirstName = NCS(reader[idxFirstName]);
						pi.MiddleName = NCS(reader[idxMiddleName]);
						pi.LastName = NCS(reader[idxLastName]);
						pi.BusPhone = NCS(reader[idxBusPhone]);
						pi.HomePhone = NCS(reader[idxHomePhone]);
						pi.CellPhone = NCS(reader[idxCellPhone]);
						pi.FaxPhone = NCS(reader[idxFaxPhone]);
						pi.Email = NCS(reader[idxEmail]);
						pi.Url = NCS(reader[idxUrl]);
						pi.UserType = NCS(reader[idxUserType]);
						pi.LoginId = NCS(reader[idxLoginId]);
						pi.Password = NCS(reader[idxPassword]);
						pi.Representative = NCI(reader[idxRepresentative]);
						pi.CostCenter = NCS(reader[idxCostCenter]);
						pi.Department = NCS(reader[idxDepartment]);
						pi.ActiveFlag = NCB(reader[idxActiveFlag]);
						pi.Label = NCS(reader[idxLabel]);
						pi.ITemp = NCI(reader[idxITemp]);
						pi.PersonType = NCS(reader[idxPersonType]);
						pi.Region = NCS(reader[idxRegion]);
                        pi.SentInviteFlag = NCB(reader[idxSentInviteFlag]);
                        pi.SiteTermsFlag = NCB(reader[idxSiteTermsFlag]);
						pi.ExternalID = NCS(reader[idxExternalID]);
						pi.LastLoginTime = NCD(reader[idxLastLoginTime]);
						pi.CurrentLoginTime = NCD(reader[idxCurrentLoginTime]);
                        pi.LoginSource = NCS(reader[idxLoginSource]);
                        pi.StoreRepresentativeName = NCS(reader[idxStoreRepresentativeName]);

						pi.Addresses = AddressData.GetAddress(storeId, personId);

						personList.Add(pi);
					}
				}
				reader.Close();
			}

			return personList.ToArray();
		}

        public static PersonInfo[] GetPerson(int storeId)
        {
            List<PersonInfo> personList = new List<PersonInfo>();

            string sql = ""
                + "SELECT * \n"
                + "FROM person \n"
                + "WHERE \n"
                + "	(store_id = @store_id) \n"
                + " AND coalesce(first_name, '') <> '' \n"
                + " AND coalesce(last_name, '') <> ''";
            ;

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxStoreId = reader.GetOrdinal("store_id");
                    int idxPersonId = reader.GetOrdinal("person_id");
                    int idxNamePrefix = reader.GetOrdinal("name_prefix");
                    int idxNameSuffix = reader.GetOrdinal("name_suffix");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxMiddleName = reader.GetOrdinal("middle_name");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxBusPhone = reader.GetOrdinal("bus_phone");
                    int idxHomePhone = reader.GetOrdinal("home_phone");
                    int idxCellPhone = reader.GetOrdinal("cell_phone");
                    int idxFaxPhone = reader.GetOrdinal("fax_phone");
                    int idxEmail = reader.GetOrdinal("email");
                    int idxUrl = reader.GetOrdinal("url");
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxLoginId = reader.GetOrdinal("login_id");
                    int idxPassword = reader.GetOrdinal("password");
                    int idxRepresentative = reader.GetOrdinal("representative");
                    int idxCostCenter = reader.GetOrdinal("cost_center");
                    int idxDepartment = reader.GetOrdinal("department");
                    int idxActiveFlag = reader.GetOrdinal("active_flag");
                    int idxLabel = reader.GetOrdinal("label");
                    int idxITemp = reader.GetOrdinal("iTemp");
                    int idxPersonType = reader.GetOrdinal("person_type");
                    int idxRegion = reader.GetOrdinal("region");
                    int idxSentInviteFlag = reader.GetOrdinal("SentInvite_flag");
                    int idxSiteTermsFlag = reader.GetOrdinal("site_terms_flag");
                    int idxExternalID = reader.GetOrdinal("external_ID");
                    int idxLastLoginTime = reader.GetOrdinal("last_login_time");
                    int idxCurrentLoginTime = reader.GetOrdinal("current_login_time");
                    int idxLoginSource = reader.GetOrdinal("login_source");
                    int idxStoreRepresentativeName = reader.GetOrdinal("store_representative_name");

                    while (reader.Read())
                    {
                        PersonInfo pi = new PersonInfo();

                        pi.StoreId = NCI(reader[idxStoreId]);
                        pi.PersonId = NCI(reader[idxPersonId]);
                        pi.NamePrefix = NCS(reader[idxNamePrefix]);
                        pi.NameSuffix = NCS(reader[idxNameSuffix]);
                        pi.FirstName = NCS(reader[idxFirstName]);
                        pi.MiddleName = NCS(reader[idxMiddleName]);
                        pi.LastName = NCS(reader[idxLastName]);
                        pi.BusPhone = NCS(reader[idxBusPhone]);
                        pi.HomePhone = NCS(reader[idxHomePhone]);
                        pi.CellPhone = NCS(reader[idxCellPhone]);
                        pi.FaxPhone = NCS(reader[idxFaxPhone]);
                        pi.Email = NCS(reader[idxEmail]);
                        pi.Url = NCS(reader[idxUrl]);
                        pi.UserType = NCS(reader[idxUserType]);
                        pi.LoginId = NCS(reader[idxLoginId]);
                        pi.Password = NCS(reader[idxPassword]);
                        pi.Representative = NCI(reader[idxRepresentative]);
                        pi.CostCenter = NCS(reader[idxCostCenter]);
                        pi.Department = NCS(reader[idxDepartment]);
                        pi.ActiveFlag = NCB(reader[idxActiveFlag]);
                        pi.Label = NCS(reader[idxLabel]);
                        pi.ITemp = NCI(reader[idxITemp]);
                        pi.PersonType = NCS(reader[idxPersonType]);
                        pi.Region = NCS(reader[idxRegion]);
                        pi.SentInviteFlag = NCB(reader[idxSentInviteFlag]);
                        pi.SiteTermsFlag = NCB(reader[idxSiteTermsFlag]);
                        pi.ExternalID = NCS(reader[idxExternalID]);
                        pi.LastLoginTime = NCD(reader[idxLastLoginTime]);
                        pi.CurrentLoginTime = NCD(reader[idxCurrentLoginTime]);
                        pi.LoginSource = NCS(reader[idxLoginSource]);
                        pi.StoreRepresentativeName = NCS(reader[idxStoreRepresentativeName]);

                        pi.Addresses = AddressData.GetAddress(storeId, (int) pi.PersonId);

                        personList.Add(pi);
                    }
                }
                reader.Close();
            }

            return personList.ToArray();
        }

        public static PersonInfo[] GetPersonListForPickList(int storeId, string excludelist)
        {
            List<PersonInfo> personList = new List<PersonInfo>();

            string sql = ""
                + "SELECT store_id, person_id, first_name, last_name, user_type, \n"
                + "department, active_flag, region \n"
                + "FROM person \n"
                + "WHERE \n"
                + "	(store_id = @store_id) \n"
                + " AND coalesce(first_name, '') <> '' \n"
                + " AND coalesce(last_name, '') <> '' \n"
                + " AND user_type not in (" + excludelist + ")";

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxStoreId = reader.GetOrdinal("store_id");
                    int idxPersonId = reader.GetOrdinal("person_id");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxDepartment = reader.GetOrdinal("department");
                    int idxActiveFlag = reader.GetOrdinal("active_flag");
                    int idxRegion = reader.GetOrdinal("region");

                    while (reader.Read())
                    {
                        Object[] values = new Object[reader.FieldCount];

                        int fieldCount = reader.GetValues(values);

                        PersonInfo pi = new PersonInfo();

                        pi.StoreId = NCI(values[idxStoreId]);
                        pi.PersonId = NCI(values[idxPersonId]);
                        pi.FirstName = NCS(values[idxFirstName]);
                        pi.LastName = NCS(values[idxLastName]);
                        pi.UserType = NCS(values[idxUserType]);
                        pi.Department = NCS(values[idxDepartment]);
                        pi.ActiveFlag = NCB(values[idxActiveFlag]);
                        pi.Region = NCS(values[idxRegion]);

                        personList.Add(pi);
                    }
                }
                reader.Close();
            }

            return personList.ToArray();
        }

        public static PersonInfo[] GetActivePersonListForPickList(int storeId, string excludelist)
        {
            List<PersonInfo> personList = new List<PersonInfo>();

            string sql = ""
                + "SELECT store_id, person_id, first_name, last_name, user_type, \n"
                + "department, active_flag, region \n"
                + "FROM person \n"
                + "WHERE \n"
                + "	(store_id = @store_id) \n"
                + " AND (active_flag = 1) \n"
                + " AND coalesce(first_name, '') <> '' \n"
                + " AND coalesce(last_name, '') <> '' \n"
                + " AND user_type not in (" + excludelist + ")";

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId;

            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxStoreId = reader.GetOrdinal("store_id");
                    int idxPersonId = reader.GetOrdinal("person_id");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxDepartment = reader.GetOrdinal("department");
                    int idxActiveFlag = reader.GetOrdinal("active_flag");
                    int idxRegion = reader.GetOrdinal("region");

                    while (reader.Read())
                    {
                        Object[] values = new Object[reader.FieldCount];

                        int fieldCount = reader.GetValues(values);

                        PersonInfo pi = new PersonInfo();

                        pi.StoreId = NCI(values[idxStoreId]);
                        pi.PersonId = NCI(values[idxPersonId]);
                        pi.FirstName = NCS(values[idxFirstName]);
                        pi.LastName = NCS(values[idxLastName]);
                        pi.UserType = NCS(values[idxUserType]);
                        pi.Department = NCS(values[idxDepartment]);
                        pi.ActiveFlag = NCB(values[idxActiveFlag]);
                        pi.Region = NCS(values[idxRegion]);

                        personList.Add(pi);
                    }
                }
                reader.Close();
            }

            return personList.ToArray();
        }

        public static PersonInfo[] GetPersonListForPickList(int storeId)
        {
            List<PersonInfo> personList = new List<PersonInfo>();

            string sql = ""
                + "SELECT store_id, person_id, first_name, last_name, user_type, \n"
                + "department, active_flag, region \n"
                + "FROM person \n"
                + "WHERE \n"
                + "	(store_id = @store_id) \n"
                + " AND coalesce(first_name, '') <> '' \n"
                + " AND coalesce(last_name, '') <> ''";

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.SmallInt);
            parmStoreId.Value = storeId;
            
            SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

            using (SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms))
            {
                if (reader.HasRows)
                {
                    int idxStoreId = reader.GetOrdinal("store_id");
                    int idxPersonId = reader.GetOrdinal("person_id");
                    int idxFirstName = reader.GetOrdinal("first_name");
                    int idxLastName = reader.GetOrdinal("last_name");
                    int idxUserType = reader.GetOrdinal("user_type");
                    int idxDepartment = reader.GetOrdinal("department");
                    int idxActiveFlag = reader.GetOrdinal("active_flag");
                    int idxRegion = reader.GetOrdinal("region");

                    while (reader.Read())
                    {
                        Object[] values = new Object[reader.FieldCount];

                        int fieldCount = reader.GetValues(values);

                        PersonInfo pi = new PersonInfo();

                        pi.StoreId = NCI(values[idxStoreId]);
                        pi.PersonId = NCI(values[idxPersonId]);
                        pi.FirstName = NCS(values[idxFirstName]);
                        pi.LastName = NCS(values[idxLastName]);
                        pi.UserType = NCS(values[idxUserType]);
                        pi.Department = NCS(values[idxDepartment]);
                        pi.ActiveFlag = NCB(values[idxActiveFlag]);
                        pi.Region = NCS(values[idxRegion]);

                        personList.Add(pi);
                    }
                }
                reader.Close();
            }

            return personList.ToArray();
        }


		public static PersonInfo SavePerson(PersonInfo person) {
			string sql;
			int? personId;

			//New person
			if(!person.PersonId.HasValue) {

                // person records are required to have a person type
                if (string.IsNullOrEmpty(person.PersonType))
                {
                    return person;
                }

				//Retrieve max person number from person
				sql = "SELECT max(person_id) "
				+ "FROM person "
				+ "WHERE store_id = " + Escape(person.StoreId.ToString()) + " ";


				personId = NCI(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql));

				if(!personId.HasValue) {
					personId = 1;
				}
				else {
					personId++;
				}

				person.PersonId = personId;

                if (person.Addresses != null)
                {
                    foreach (AddressInfo address in person.Addresses)
                    {
                        address.PersonId = person.PersonId;
                    }
                }

				sql = "INSERT INTO person ("
					+ "store_id,"
					+ "person_id,"
					+ "name_prefix,"
					+ "name_suffix,"
					+ "first_name,"
					+ "middle_name,"
					+ "last_name,"
					+ "bus_phone,"
					+ "home_phone,"
					+ "cell_phone,"
					+ "fax_phone,"
					+ "email,"
					+ "url,"
					+ "user_type,"
					+ "login_id,"
					+ "password,"
					+ "representative,"
					+ "cost_center,"
					+ "department,"
					+ "active_flag,"
					+ "label,"
					+ "iTemp,"
					+ "person_type,"
					+ "region,"
					+ "SentInvite_flag,"
                    + "site_terms_flag,"
					+ "external_ID,"
					+ "last_login_time,"
					+ "current_login_time,"
                    + "login_source,"
                    + "store_representative_name"
					+ ")"
					+ "VALUES("
					+ nullChk(person.StoreId) + ","
					+ nullChk(person.PersonId) + ","
					+ nullChk(person.NamePrefix) + ","
					+ nullChk(person.NameSuffix) + ","
					+ nullChk(person.FirstName) + ","
					+ nullChk(person.MiddleName) + ","
					+ nullChk(person.LastName) + ","
					+ nullChk(person.BusPhone) + ","
					+ nullChk(person.HomePhone) + ","
					+ nullChk(person.CellPhone) + ","
					+ nullChk(person.FaxPhone) + ","
					+ nullChk(person.Email) + ","
					+ nullChk(person.Url) + ","
					+ nullChk(person.UserType) + ","
					+ nullChk(person.LoginId) + ","
					+ nullChk(person.Password) + ","
					+ nullChk(person.Representative) + ","
					+ nullChk(person.CostCenter) + ","
					+ nullChk(person.Department) + ","
					+ nullChk(person.ActiveFlag) + ","
					+ nullChk(person.Label) + ","
					+ nullChk(person.ITemp) + ","
					+ nullChk(person.PersonType) + ","
					+ nullChk(person.Region) + ","
                    + nullChk(person.SentInviteFlag) + ","
                    + nullChk(person.SiteTermsFlag) + ","
					+ nullChk(person.ExternalID) + ","
					+ nullChk(person.LastLoginTime) + ","
					+ nullChk(person.CurrentLoginTime) + ","
                    + nullChk(person.LoginSource) + ","
                    + nullChk(person.StoreRepresentativeName) + ""
					+ ")";


			}
			else //Person already exists, do update.
            {

				sql = "UPDATE person SET "
					+ "store_id = " + nullChk(person.StoreId) + ","
					+ "person_id = " + nullChk(person.PersonId) + ","
					+ "name_prefix = " + nullChk(person.NamePrefix) + ","
					+ "name_suffix = " + nullChk(person.NameSuffix) + ","
					+ "first_name = " + nullChk(person.FirstName) + ","
					+ "middle_name = " + nullChk(person.MiddleName) + ","
					+ "last_name = " + nullChk(person.LastName) + ","
					+ "bus_phone = " + nullChk(person.BusPhone) + ","
					+ "home_phone = " + nullChk(person.HomePhone) + ","
					+ "cell_phone = " + nullChk(person.CellPhone) + ","
					+ "fax_phone = " + nullChk(person.FaxPhone) + ","
					+ "email = " + nullChk(person.Email) + ","
					+ "url = " + nullChk(person.Url) + ","
					+ "user_type = " + nullChk(person.UserType) + ","
					+ "login_id = " + nullChk(person.LoginId) + ","
					+ "password = " + nullChk(person.Password) + ","
					+ "representative = " + nullChk(person.Representative) + ","
					+ "cost_center = " + nullChk(person.CostCenter) + ","
					+ "department = " + nullChk(person.Department) + ","
					+ "active_flag = " + nullChk(person.ActiveFlag) + ","
					+ "label = " + nullChk(person.Label) + ","
					+ "iTemp = " + nullChk(person.ITemp) + ","
					+ "person_type = " + nullChk(person.PersonType) + ","
					+ "region = " + nullChk(person.Region) + ","
					+ "SentInvite_flag = " + nullChk(person.SentInviteFlag) + ","
                    + "site_terms_flag = " + nullChk(person.SiteTermsFlag) + ","
                    + "external_ID = " + nullChk(person.ExternalID) + ","
					+ "last_login_time = " + nullChk(person.LastLoginTime) + ","
					+ "current_login_time = " + nullChk(person.CurrentLoginTime) + ","
                    + "login_source = " + nullChk(person.LoginSource) + ","
                    + "store_representative_name = " + nullChk(person.StoreRepresentativeName) + " "
					+ "WHERE store_id = " + nullChk(person.StoreId) + " "
					+ "AND person_id = " + nullChk(person.PersonId) + " ";


			}


			SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql);

            if (person.Addresses != null)
            {
                foreach (AddressInfo address in person.Addresses)
                {
                    address.PersonId = person.PersonId;
                    AddressData.SaveAddress(address);
                }
            }


			return person;
		}
	}
}