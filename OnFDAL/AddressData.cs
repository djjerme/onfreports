using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL {
	/// <summary>
	/// Data Access Layer for AddressData
	/// </summary>
	public class AddressData : PBA.OnfDAL.DataAccess {
		public static void Delete(int? storeID, int? personID, int? addressID) {
			string sql;
			if(storeID.HasValue && personID.HasValue && addressID.HasValue) {
				sql = "DELETE from address "
				+ "WHERE store_id = " + Escape(storeID.ToString()) + " "
				+ "AND person_id = " + Escape(personID.ToString()) + " "
				+ "AND address_id = " + Escape(addressID.ToString()) + " ";

				SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql);
			}
		}

		public static void Delete(int? storeID, int? personID) {
			string sql;
			if(storeID.HasValue && personID.HasValue) {
				sql = "DELETE from address "
				+ "WHERE store_id = " + Escape(storeID.ToString()) + " "
				+ "AND person_id = " + Escape(personID.ToString()) + " ";

				SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql);
			}
		}

		public static void Delete(AddressInfo address) {
			int? storeID = address.StoreId;
			int? personID = address.PersonId;
			int? addressID = address.AddressId;

			Delete(storeID, personID, addressID);
		}


		public static AddressInfo GetAddress(int storeID, int personID, int addressID) {
			AddressInfo[] addresses = GetAddress(storeID, personID);
			AddressInfo returnAddress = null;

			foreach(AddressInfo address in addresses) {
				if(address.AddressId == addressID) {
					returnAddress = address;
				}
			}

			return returnAddress;
		}


		public static AddressInfo[] GetAddress(int storeID, int personID) {
			string sql = string.Empty;
			ArrayList c = new ArrayList();

			sql = "SELECT * "
			+ "FROM address "
			+ "WHERE store_id = " + Escape(storeID.ToString()) + " "
			+ "AND person_id = " + Escape(personID.ToString()) + " ";

			SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);


			while(d.Read()) {
				AddressInfo al = new AddressInfo();

				al.StoreId = NCI(d["store_id"]);
				al.PersonId = NCI(d["person_id"]);
				al.AddressId = NCI(d["address_id"]);
				al.Label = NCS(d["label"]);
				al.Company = NCS(d["company"]);
				al.Title = NCS(d["title"]);
				al.Address1 = NCS(d["address_1"]);
				al.Address2 = NCS(d["address_2"]);
				al.Address3 = NCS(d["address_3"]);
				al.City = NCS(d["city"]);
				al.State = NCS(d["state"]);
				al.Country = NCS(d["country"]);
				al.Zip = NCS(d["zip"]);
				al.BusPhone = NCS(d["bus_phone"]);
				al.HomePhone = NCS(d["home_phone"]);
				al.FaxPhone = NCS(d["fax_phone"]);


				c.Add(al);


			}

			d.Close();
			return (AddressInfo[])c.ToArray(typeof(AddressInfo));
		}


		public static AddressInfo SaveAddress(AddressInfo address) {
			string sql;
			int? addressId;

			//New person
			if(!address.AddressId.HasValue) {

				//Retrieve max address id from address
				sql = "SELECT max(address_id) "
				+ "FROM address "
				+ "WHERE store_id = " + Escape(address.StoreId.ToString()) + " "
				+ "AND person_id = " + Escape(address.PersonId.ToString()) + " ";


				addressId = NCI(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql));

				if(!addressId.HasValue) {
					addressId = 0;
				}
				else {
					addressId++;
				}

				address.AddressId = addressId;

				sql = "INSERT INTO address ("
					+ "store_id,"
					+ "person_id,"
					+ "address_id,"
					+ "label,"
					+ "company,"
					+ "title,"
					+ "address_1,"
					+ "address_2,"
					+ "address_3,"
					+ "city,"
					+ "state,"
					+ "country,"
					+ "zip,"
					+ "bus_phone,"
					+ "home_phone,"
					+ "fax_phone"
					+ ")"
					+ "VALUES("
					+ nullChk(address.StoreId) + ","
					+ nullChk(address.PersonId) + ","
					+ nullChk(address.AddressId) + ","
					+ nullChk(address.Label) + ","
					+ nullChk(address.Company) + ","
					+ nullChk(address.Title) + ","
					+ nullChk(address.Address1) + ","
					+ nullChk(address.Address2) + ","
					+ nullChk(address.Address3) + ","
					+ nullChk(address.City) + ","
					+ nullChk(address.State) + ","
					+ nullChk(address.Country) + ","
					+ nullChk(address.Zip) + ","
					+ nullChk(address.BusPhone) + ","
					+ nullChk(address.HomePhone) + ","
					+ nullChk(address.FaxPhone) + ""
					+ ")";

			}
			else //address already exists, do update.
            {
				sql = "UPDATE address SET "
					+ "store_id = " + nullChk(address.StoreId) + ","
					+ "person_id = " + nullChk(address.PersonId) + ","
					+ "address_id = " + nullChk(address.AddressId) + ","
					+ "label = " + nullChk(address.Label) + ","
					+ "company = " + nullChk(address.Company) + ","
					+ "title = " + nullChk(address.Title) + ","
					+ "address_1 = " + nullChk(address.Address1) + ","
					+ "address_2 = " + nullChk(address.Address2) + ","
					+ "address_3 = " + nullChk(address.Address3) + ","
					+ "city = " + nullChk(address.City) + ","
					+ "state = " + nullChk(address.State) + ","
					+ "country = " + nullChk(address.Country) + ","
					+ "zip = " + nullChk(address.Zip) + ","
					+ "bus_phone = " + nullChk(address.BusPhone) + ","
					+ "home_phone = " + nullChk(address.HomePhone) + ","
					+ "fax_phone = " + nullChk(address.FaxPhone) + " "
					+ "WHERE store_id = " + nullChk(address.StoreId) + " "
					+ "AND person_id = " + nullChk(address.PersonId) + " "
					+ "AND address_id = " + nullChk(address.AddressId) + " ";

			}

			SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql);

			return address;
		}
	}
}