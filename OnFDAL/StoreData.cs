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
	/// Data Access Layer for Store
	/// </summary>
	public class StoreData : PBA.OnfDAL.DataAccess {
		public static PersonInfo GetStoreContactPerson(int? storeId) {
			int personId = Int32.MinValue;
			PersonInfo person = null;

			string sql = ""
				+ "SELECT contact_us_person \n"
				+ "FROM store \n"
				+ "WHERE (store_id = @store_id) \n"
			;

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
			parmStoreId.Value = storeId.Value;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

			object temp = SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, sql, cmdParms);
			if(temp != null) {
				if(!Int32.TryParse(temp.ToString(), out personId)) {
					personId = Int32.MinValue;
				}
			}

			if(personId != Int32.MinValue) {
				person = GetStoreContactPerson(storeId, personId);
			}

			return person;
		}


		public static PersonInfo GetStoreContactPerson(int? storeId, int personId) {
			PersonInfo[] person = null;
			if(storeId.HasValue) {
				person = PersonData.GetPerson(storeId.Value, personId);

                if (person != null && person.Length > 0)
                {
                    return person[0];
                }
			}
			return null;
		}


		public static StoreInfo GetStore(int? storeId) {
			StoreInfo store = new StoreInfo();

			string sql = ""
				+ "SELECT * \n"
				+ "FROM store \n"
				+ "WHERE (store_id = @store_id) \n"
			;

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
			parmStoreId.Value = storeId.Value;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

			using(SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms)) {
				if(reader.Read()) {
					store.StoreId = NCI(reader["store_id"]);
					store.WhseId = NCI(reader["whse_id"]);
					store.Name = NCS(reader["name"]);
					store.Title = NCS(reader["title"]);
					store.PublicAccessFlag = NCB(reader["public_access_flag"]);
					store.ActiveFlag = NCB(reader["active_flag"]);
					store.LogoAlign = NCS(reader["logo_align"]);
					store.CartBg = NCS(reader["cart_bg"]);
					store.CartWidth = NCI(reader["cart_width"]);
					store.StoreBg = NCS(reader["store_bg"]);
					store.Search = NCB(reader["search"]);
					store.Status = NCS(reader["status"]);
					store.StorePath = NCS(reader["store_path"]);
					store.LoginPage = NCS(reader["login_page"]);
					store.StartPage = NCS(reader["start_page"]);
					store.HomePage = NCS(reader["home_page"]);
					store.StartDept = NCS(reader["start_dept"]);
					store.TopFrameHeight = NCI(reader["top_frame_height"]);
					store.TopBgColor = NCS(reader["top_bg_color"]);
					store.TopBorderColor = NCS(reader["top_border_color"]);
					store.TopGraphicHeight = NCI(reader["top_graphic_height"]);
					store.TopGraphicWidth = NCI(reader["top_graphic_width"]);
					store.TopDeptRefresh = NCB(reader["top_dept_refresh"]);
					store.BtnCheckout = NCS(reader["btn_checkout"]);
					store.BtnModify = NCS(reader["btn_modify"]);
					store.LinkColor = NCS(reader["link_color"]);
					store.VlinkColor = NCS(reader["vlink_color"]);
					store.CartLinkColor = NCS(reader["cart_link_color"]);
					store.CartVlinkColor = NCS(reader["cart_vlink_color"]);
					store.CartAlinkColor = NCS(reader["cart_alink_color"]);
					store.CartFontColor = NCS(reader["cart_font_color"]);
					store.CartTableFontColor = NCS(reader["cart_table_font_color"]);
					store.CartBgColor = NCS(reader["cart_bg_color"]);
					store.CartBorderColor = NCS(reader["cart_border_color"]);
					store.FontFace = NCS(reader["font_face"]);
					store.FontSize = NCI(reader["font_size"]);
					store.FontColor = NCS(reader["font_color"]);
					store.TdBgColor = NCS(reader["td_bg_color"]);
					store.TdColor = NCS(reader["td_color"]);
					store.ThBgColor = NCS(reader["th_bg_color"]);
					store.ThColor = NCS(reader["th_color"]);
					store.DeptLabel = NCS(reader["dept_label"]);
					store.SubDeptLabel = NCS(reader["sub_dept_label"]);
					store.OverCommitRule = NCS(reader["over_commit_rule"]);
					store.IntroMsg = NCS(reader["intro_msg"]);
					store.LoginMsgBottom = NCS(reader["login_msg_bottom"]);
					store.ItemLabel = NCS(reader["item_label"]);
					store.ItemNameLabel = NCS(reader["item_name_label"]);
					store.ItemGraphicWidth = NCI(reader["item_graphic_width"]);
					store.LineHandlingFee = NCDcm(reader["line_handling_fee"]);
					store.OrderShippingCharge = NCDcm(reader["order_shipping_charge"]);
					store.OrderCanadaShippingCharge = NCDcm(reader["order_Canada_shipping_charge"]);
					store.OrderInternationalShippingCharge = NCDcm(reader["order_International_shipping_charge"]);
					store.OrderConfirmMsg = NCS(reader["order_confirm_msg"]);
					store.MaxWidth = NCI(reader["max_width"]);
					store.ProductTypeLabel = NCS(reader["product_type_label"]);
					store.UserRegions = NCB(reader["user_regions"]);
					store.UserRegionsLabel = NCS(reader["user_regions_label"]);
					store.CostCenterLabel = NCS(reader["cost_center_label"]);
					store.DivisionCostCenterLabel = NCS(reader["division_cost_center_label"]);
					store.UserDeptLabel = NCS(reader["user_dept_label"]);
					store.ProductLabel = NCS(reader["product_label"]);
					store.BundleLabel = NCS(reader["bundle_label"]);
					store.ProductSubtypeLabel = NCS(reader["product_subtype_label"]);
					store.CustomerContactEmail = NCS(reader["customer_contact_email"]);
					store.CertiTaxID = NCS(reader["CertiTaxID"]);
					store.CertiTaxNexus = NCS(reader["CertiTaxNexus"]);
					store.LeadAdminEmail = NCS(reader["lead_admin_email"]);
					store.ContactUsPerson = NCI(reader["contact_us_person"]);
					store.EmailShipConfirmTemplate = NCS(reader["email_ship_confirm_template"]);
					store.EmailOrderConfirmTemplate = NCS(reader["email_order_confirm_template"]);
					store.DeletedFlag = NCB(reader["deleted_flag"]);
                    store.BackorderCreation = NCB(reader["backorder_creation"]);
                    store.AutoGen = NCB(reader["autogen_flag"]);
                    store.NoCommentPrinterID = NCI(reader["printer_id_nocomments"]);
                    store.CommentPrinterID = NCI(reader["printer_id_comments"]);
				}
				reader.Close();
			}

			return store;
		}

        public static StoreInfo[] GetAllStores()
        {

            List<StoreInfo> storeList = new List<StoreInfo>();

            string sql = ""
                + "SELECT * \n"
                + "FROM store order by name \n";

            SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql);
            if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StoreInfo store = new StoreInfo();
                        store.StoreId = NCI(reader["store_id"]);
                        store.WhseId = NCI(reader["whse_id"]);
                        store.Name = NCS(reader["name"]);
                        store.Title = NCS(reader["title"]);
                        store.PublicAccessFlag = NCB(reader["public_access_flag"]);
                        store.ActiveFlag = NCB(reader["active_flag"]);
                        store.LogoAlign = NCS(reader["logo_align"]);
                        store.CartBg = NCS(reader["cart_bg"]);
                        store.CartWidth = NCI(reader["cart_width"]);
                        store.StoreBg = NCS(reader["store_bg"]);
                        store.Search = NCB(reader["search"]);
                        store.Status = NCS(reader["status"]);
                        store.StorePath = NCS(reader["store_path"]);
                        store.LoginPage = NCS(reader["login_page"]);
                        store.StartPage = NCS(reader["start_page"]);
                        store.HomePage = NCS(reader["home_page"]);
                        store.StartDept = NCS(reader["start_dept"]);
                        store.TopFrameHeight = NCI(reader["top_frame_height"]);
                        store.TopBgColor = NCS(reader["top_bg_color"]);
                        store.TopBorderColor = NCS(reader["top_border_color"]);
                        store.TopGraphicHeight = NCI(reader["top_graphic_height"]);
                        store.TopGraphicWidth = NCI(reader["top_graphic_width"]);
                        store.TopDeptRefresh = NCB(reader["top_dept_refresh"]);
                        store.BtnCheckout = NCS(reader["btn_checkout"]);
                        store.BtnModify = NCS(reader["btn_modify"]);
                        store.LinkColor = NCS(reader["link_color"]);
                        store.VlinkColor = NCS(reader["vlink_color"]);
                        store.CartLinkColor = NCS(reader["cart_link_color"]);
                        store.CartVlinkColor = NCS(reader["cart_vlink_color"]);
                        store.CartAlinkColor = NCS(reader["cart_alink_color"]);
                        store.CartFontColor = NCS(reader["cart_font_color"]);
                        store.CartTableFontColor = NCS(reader["cart_table_font_color"]);
                        store.CartBgColor = NCS(reader["cart_bg_color"]);
                        store.CartBorderColor = NCS(reader["cart_border_color"]);
                        store.FontFace = NCS(reader["font_face"]);
                        store.FontSize = NCI(reader["font_size"]);
                        store.FontColor = NCS(reader["font_color"]);
                        store.TdBgColor = NCS(reader["td_bg_color"]);
                        store.TdColor = NCS(reader["td_color"]);
                        store.ThBgColor = NCS(reader["th_bg_color"]);
                        store.ThColor = NCS(reader["th_color"]);
                        store.DeptLabel = NCS(reader["dept_label"]);
                        store.SubDeptLabel = NCS(reader["sub_dept_label"]);
                        store.OverCommitRule = NCS(reader["over_commit_rule"]);
                        store.IntroMsg = NCS(reader["intro_msg"]);
                        store.LoginMsgBottom = NCS(reader["login_msg_bottom"]);
                        store.ItemLabel = NCS(reader["item_label"]);
                        store.ItemNameLabel = NCS(reader["item_name_label"]);
                        store.ItemGraphicWidth = NCI(reader["item_graphic_width"]);
                        store.LineHandlingFee = NCDcm(reader["line_handling_fee"]);
                        store.OrderShippingCharge = NCDcm(reader["order_shipping_charge"]);
                        store.OrderCanadaShippingCharge = NCDcm(reader["order_Canada_shipping_charge"]);
                        store.OrderInternationalShippingCharge = NCDcm(reader["order_International_shipping_charge"]);
                        store.OrderConfirmMsg = NCS(reader["order_confirm_msg"]);
                        store.MaxWidth = NCI(reader["max_width"]);
                        store.ProductTypeLabel = NCS(reader["product_type_label"]);
                        store.UserRegions = NCB(reader["user_regions"]);
                        store.UserRegionsLabel = NCS(reader["user_regions_label"]);
                        store.CostCenterLabel = NCS(reader["cost_center_label"]);
                        store.DivisionCostCenterLabel = NCS(reader["division_cost_center_label"]);
                        store.UserDeptLabel = NCS(reader["user_dept_label"]);
                        store.ProductLabel = NCS(reader["product_label"]);
                        store.BundleLabel = NCS(reader["bundle_label"]);
                        store.ProductSubtypeLabel = NCS(reader["product_subtype_label"]);
                        store.CustomerContactEmail = NCS(reader["customer_contact_email"]);
                        store.CertiTaxID = NCS(reader["CertiTaxID"]);
                        store.CertiTaxNexus = NCS(reader["CertiTaxNexus"]);
                        store.LeadAdminEmail = NCS(reader["lead_admin_email"]);
                        store.ContactUsPerson = NCI(reader["contact_us_person"]);
                        store.EmailShipConfirmTemplate = NCS(reader["email_ship_confirm_template"]);
                        store.EmailOrderConfirmTemplate = NCS(reader["email_order_confirm_template"]);
                        store.DeletedFlag = NCB(reader["deleted_flag"]);
                        store.BackorderCreation = NCB(reader["backorder_creation"]);
                        store.AutoGen = NCB(reader["autogen_flag"]);
                        store.NoCommentPrinterID = NCI(reader["printer_id_nocomments"]);
                        store.CommentPrinterID = NCI(reader["printer_id_comments"]);
                        storeList.Add(store);
                    }
                }
                reader.Close();
            

            return storeList.ToArray();
        }


        //****
        public static StoreInfo[] GetAllActiveStores()
        { 

            List<StoreInfo> storeList = new List<StoreInfo>();

            string sql = ""
                + "SELECT * \n"
                + "FROM store where active_flag = @flagval order by name \n";

            SqlParameter flagval = new SqlParameter("@flagval", SqlDbType.Bit);
            flagval.Value = true;

            SqlParameter[] cmdParms = new SqlParameter[]{flagval };


            SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StoreInfo store = new StoreInfo();
                    store.StoreId = NCI(reader["store_id"]);
                    store.WhseId = NCI(reader["whse_id"]);
                    store.Name = NCS(reader["name"]);
                    store.Title = NCS(reader["title"]);
                    store.PublicAccessFlag = NCB(reader["public_access_flag"]);
                    store.ActiveFlag = NCB(reader["active_flag"]);
                    store.LogoAlign = NCS(reader["logo_align"]);
                    store.CartBg = NCS(reader["cart_bg"]);
                    store.CartWidth = NCI(reader["cart_width"]);
                    store.StoreBg = NCS(reader["store_bg"]);
                    store.Search = NCB(reader["search"]);
                    store.Status = NCS(reader["status"]);
                    store.StorePath = NCS(reader["store_path"]);
                    store.LoginPage = NCS(reader["login_page"]);
                    store.StartPage = NCS(reader["start_page"]);
                    store.HomePage = NCS(reader["home_page"]);
                    store.StartDept = NCS(reader["start_dept"]);
                    store.TopFrameHeight = NCI(reader["top_frame_height"]);
                    store.TopBgColor = NCS(reader["top_bg_color"]);
                    store.TopBorderColor = NCS(reader["top_border_color"]);
                    store.TopGraphicHeight = NCI(reader["top_graphic_height"]);
                    store.TopGraphicWidth = NCI(reader["top_graphic_width"]);
                    store.TopDeptRefresh = NCB(reader["top_dept_refresh"]);
                    store.BtnCheckout = NCS(reader["btn_checkout"]);
                    store.BtnModify = NCS(reader["btn_modify"]);
                    store.LinkColor = NCS(reader["link_color"]);
                    store.VlinkColor = NCS(reader["vlink_color"]);
                    store.CartLinkColor = NCS(reader["cart_link_color"]);
                    store.CartVlinkColor = NCS(reader["cart_vlink_color"]);
                    store.CartAlinkColor = NCS(reader["cart_alink_color"]);
                    store.CartFontColor = NCS(reader["cart_font_color"]);
                    store.CartTableFontColor = NCS(reader["cart_table_font_color"]);
                    store.CartBgColor = NCS(reader["cart_bg_color"]);
                    store.CartBorderColor = NCS(reader["cart_border_color"]);
                    store.FontFace = NCS(reader["font_face"]);
                    store.FontSize = NCI(reader["font_size"]);
                    store.FontColor = NCS(reader["font_color"]);
                    store.TdBgColor = NCS(reader["td_bg_color"]);
                    store.TdColor = NCS(reader["td_color"]);
                    store.ThBgColor = NCS(reader["th_bg_color"]);
                    store.ThColor = NCS(reader["th_color"]);
                    store.DeptLabel = NCS(reader["dept_label"]);
                    store.SubDeptLabel = NCS(reader["sub_dept_label"]);
                    store.OverCommitRule = NCS(reader["over_commit_rule"]);
                    store.IntroMsg = NCS(reader["intro_msg"]);
                    store.LoginMsgBottom = NCS(reader["login_msg_bottom"]);
                    store.ItemLabel = NCS(reader["item_label"]);
                    store.ItemNameLabel = NCS(reader["item_name_label"]);
                    store.ItemGraphicWidth = NCI(reader["item_graphic_width"]);
                    store.LineHandlingFee = NCDcm(reader["line_handling_fee"]);
                    store.OrderShippingCharge = NCDcm(reader["order_shipping_charge"]);
                    store.OrderCanadaShippingCharge = NCDcm(reader["order_Canada_shipping_charge"]);
                    store.OrderInternationalShippingCharge = NCDcm(reader["order_International_shipping_charge"]);
                    store.OrderConfirmMsg = NCS(reader["order_confirm_msg"]);
                    store.MaxWidth = NCI(reader["max_width"]);
                    store.ProductTypeLabel = NCS(reader["product_type_label"]);
                    store.UserRegions = NCB(reader["user_regions"]);
                    store.UserRegionsLabel = NCS(reader["user_regions_label"]);
                    store.CostCenterLabel = NCS(reader["cost_center_label"]);
                    store.DivisionCostCenterLabel = NCS(reader["division_cost_center_label"]);
                    store.UserDeptLabel = NCS(reader["user_dept_label"]);
                    store.ProductLabel = NCS(reader["product_label"]);
                    store.BundleLabel = NCS(reader["bundle_label"]);
                    store.ProductSubtypeLabel = NCS(reader["product_subtype_label"]);
                    store.CustomerContactEmail = NCS(reader["customer_contact_email"]);
                    store.CertiTaxID = NCS(reader["CertiTaxID"]);
                    store.CertiTaxNexus = NCS(reader["CertiTaxNexus"]);
                    store.LeadAdminEmail = NCS(reader["lead_admin_email"]);
                    store.ContactUsPerson = NCI(reader["contact_us_person"]);
                    store.EmailShipConfirmTemplate = NCS(reader["email_ship_confirm_template"]);
                    store.EmailOrderConfirmTemplate = NCS(reader["email_order_confirm_template"]);
                    store.DeletedFlag = NCB(reader["deleted_flag"]);
                    store.BackorderCreation = NCB(reader["backorder_creation"]);
                    store.AutoGen = NCB(reader["autogen_flag"]);
                    store.NoCommentPrinterID = NCI(reader["printer_id_nocomments"]);
                    store.CommentPrinterID = NCI(reader["printer_id_comments"]);
                    storeList.Add(store);
                }
            }
            reader.Close();


            return storeList.ToArray();
        }

        //****

        static public int UpdateStore(StoreInfo Store)
        {
            string sql;
            int rc;
            sql = "UPDATE store SET "
                  + " backorder_creation = @backorder_creation,"
                  + " autogen_flag = @autogen_flag,"
                  + " printer_id_nocomments = @printer_id_nocomments,"
                  + " printer_id_comments = @printer_id_comments"
                  + " WHERE store_id = @store_id";

            SqlParameter backordercreation = new SqlParameter("@backorder_creation", SqlDbType.Bit);
            backordercreation.Value = Store.BackorderCreation;

            SqlParameter autogenflag = new SqlParameter("@autogen_flag", SqlDbType.Bit);
            autogenflag.Value = Store.AutoGen;

            SqlParameter printeridnocomments = new SqlParameter("@printer_id_nocomments", SqlDbType.Int);
            printeridnocomments.Value = Store.NoCommentPrinterID;

            SqlParameter printeridcomments = new SqlParameter("@printer_id_comments", SqlDbType.Int);
            printeridcomments.Value = Store.CommentPrinterID;

            SqlParameter storeid = new SqlParameter("@store_id", SqlDbType.Int);
            storeid.Value = Store.StoreId;


            SqlParameter[] cmdParms = new SqlParameter[] { backordercreation, autogenflag, printeridnocomments, printeridcomments, storeid };
            try
            {
               SqlHelper.ExecuteNonQuery(dbConnection, CommandType.Text, sql, cmdParms);
               rc = 0;
            }
            catch (Exception)
            {
                rc = -1;
            }

            return rc;
        }


		public static Dictionary<string, bool> GetFeatures(int? storeId) {
			Dictionary<string, bool> features = new Dictionary<string, bool>();

			string sql = ""
				+ "SELECT \n"
				+ "		code, \n"
				+ "		flag \n"
				+ "FROM code \n"
				+ "WHERE \n"
				+ "		(store_id = @store_id) \n"
				+ "		AND (class = 'feature') \n"
				+ "		AND (flag = 1) \n"
				+ "ORDER BY code"
			;

			SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
			parmStoreId.Value = storeId.Value;

			SqlParameter[] cmdParms = new SqlParameter[]{
				parmStoreId
			};

			using(SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms)) {
				if(reader.HasRows) {
					int idxCode = reader.GetOrdinal("code");
					int idxFlag = reader.GetOrdinal("flag");

					while(reader.Read()) {
						features[reader.GetString(idxCode).ToLower()] = reader.GetBoolean(idxFlag);
					}
				}
				reader.Close();
			}

			return features;
		}

        public static bool IsVirtualFulfillmentItem(int? storeid, string itemid)
        {
            bool result = false;
            string sql = "SELECT ISNULL(virtual_fulfillment,0) AS virtual_fulfillment FROM " +
                "(SELECT * FROM item WHERE store_id = @store_id and item_id = @item_id) i " +
                "INNER JOIN (SELECT * FROM product) p ON i.store_id = p.store_id AND i.product_id = p.product_id ";

            SqlParameter parmStoreId = new SqlParameter("@store_id", SqlDbType.Int);
            parmStoreId.Value = storeid.Value;

            SqlParameter parmItemId = new SqlParameter("@item_id", SqlDbType.VarChar);
            parmItemId.Value = itemid;

            SqlParameter[] cmdParms = new SqlParameter[]{parmStoreId, parmItemId };
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);

                while (reader.Read())
                {
                    bool val = (bool)reader["virtual_fulfillment"];
                    if (val == true)
                    { result = true; }
                    else
                    { result = false; }
                }
                reader.Close();

            }
            catch (Exception e)
            {
                result = true; // even though none found but because of error set to true;
            }
            return result;
        }





//sql = "INSERT INTO Store ("
//    + "store_id,"
//    + "whse_id,"
//    + "name,"
//    + "title,"
//    + "public_access_flag,"
//    + "active_flag,"
//    + "logo_align,"
//    + "cart_bg,"
//    + "cart_width,"
//    + "store_bg,"
//    + "search,"
//    + "status,"
//    + "store_path,"
//    + "login_page,"
//    + "start_page,"
//    + "home_page,"
//    + "start_dept,"
//    + "top_frame_height,"
//    + "top_bg_color,"
//    + "top_border_color,"
//    + "top_graphic_height,"
//    + "top_graphic_width,"
//    + "top_dept_refresh,"
//    + "btn_checkout,"
//    + "btn_modify,"
//    + "link_color,"
//    + "vlink_color,"
//    + "cart_link_color,"
//    + "cart_vlink_color,"
//    + "cart_alink_color,"
//    + "cart_font_color,"
//    + "cart_table_font_color,"
//    + "cart_bg_color,"
//    + "cart_border_color,"
//    + "font_face,"
//    + "font_size,"
//    + "font_color,"
//    + "td_bg_color,"
//    + "td_color,"
//    + "th_bg_color,"
//    + "th_color,"
//    + "dept_label,"
//    + "sub_dept_label,"
//    + "over_commit_rule,"
//    + "intro_msg,"
//    + "login_msg_bottom,"
//    + "item_label,"
//    + "item_name_label,"
//    + "item_graphic_width,"
//    + "line_handling_fee,"
//    + "order_shipping_charge,"
//    + "order_Canada_shipping_charge,"
//    + "order_International_shipping_charge,"
//    + "order_confirm_msg,"
//    + "max_width,"
//    + "product_type_label,"
//    + "user_regions,"
//    + "user_regions_label,"
//    + "cost_center_label,"
//    + "division_cost_center_label,"
//    + "user_dept_label,"
//    + "product_label,"
//    + "bundle_label,"
//    + "product_subtype_label,"
//    + "customer_contact_email,"
//    + "CertiTaxID,"
//    + "CertiTaxNexus,"
//    + "lead_admin_email,"
//    + "contact_us_person,"
//    + "email_ship_confirm_template,"
//    + "email_order_confirm_template,"
//    + "deleted_flag"
//    + ")"
//    + "VALUES("
//    + nullChk(store.StoreId) + ","
//    + nullChk(store.WhseId) + ","
//    + nullChk(store.Name) + ","
//    + nullChk(store.Title) + ","
//    + nullChk(store.PublicAccessFlag) + ","
//    + nullChk(store.ActiveFlag) + ","
//    + nullChk(store.LogoAlign) + ","
//    + nullChk(store.CartBg) + ","
//    + nullChk(store.CartWidth) + ","
//    + nullChk(store.StoreBg) + ","
//    + nullChk(store.Search) + ","
//    + nullChk(store.Status) + ","
//    + nullChk(store.StorePath) + ","
//    + nullChk(store.LoginPage) + ","
//    + nullChk(store.StartPage) + ","
//    + nullChk(store.HomePage) + ","
//    + nullChk(store.StartDept) + ","
//    + nullChk(store.TopFrameHeight) + ","
//    + nullChk(store.TopBgColor) + ","
//    + nullChk(store.TopBorderColor) + ","
//    + nullChk(store.TopGraphicHeight) + ","
//    + nullChk(store.TopGraphicWidth) + ","
//    + nullChk(store.TopDeptRefresh) + ","
//    + nullChk(store.BtnCheckout) + ","
//    + nullChk(store.BtnModify) + ","
//    + nullChk(store.LinkColor) + ","
//    + nullChk(store.VlinkColor) + ","
//    + nullChk(store.CartLinkColor) + ","
//    + nullChk(store.CartVlinkColor) + ","
//    + nullChk(store.CartAlinkColor) + ","
//    + nullChk(store.CartFontColor) + ","
//    + nullChk(store.CartTableFontColor) + ","
//    + nullChk(store.CartBgColor) + ","
//    + nullChk(store.CartBorderColor) + ","
//    + nullChk(store.FontFace) + ","
//    + nullChk(store.FontSize) + ","
//    + nullChk(store.FontColor) + ","
//    + nullChk(store.TdBgColor) + ","
//    + nullChk(store.TdColor) + ","
//    + nullChk(store.ThBgColor) + ","
//    + nullChk(store.ThColor) + ","
//    + nullChk(store.DeptLabel) + ","
//    + nullChk(store.SubDeptLabel) + ","
//    + nullChk(store.OverCommitRule) + ","
//    + nullChk(store.IntroMsg) + ","
//    + nullChk(store.LoginMsgBottom) + ","
//    + nullChk(store.ItemLabel) + ","
//    + nullChk(store.ItemNameLabel) + ","
//    + nullChk(store.ItemGraphicWidth) + ","
//    + nullChk(store.LineHandlingFee) + ","
//    + nullChk(store.OrderShippingCharge) + ","
//    + nullChk(store.OrderCanadaShippingCharge) + ","
//    + nullChk(store.OrderInternationalShippingCharge) + ","
//    + nullChk(store.OrderConfirmMsg) + ","
//    + nullChk(store.MaxWidth) + ","
//    + nullChk(store.ProductTypeLabel) + ","
//    + nullChk(store.UserRegions) + ","
//    + nullChk(store.UserRegionsLabel) + ","
//    + nullChk(store.CostCenterLabel) + ","
//    + nullChk(store.DivisionCostCenterLabel) + ","
//    + nullChk(store.UserDeptLabel) + ","
//    + nullChk(store.ProductLabel) + ","
//    + nullChk(store.BundleLabel) + ","
//    + nullChk(store.ProductSubtypeLabel) + ","
//    + nullChk(store.CustomerContactEmail) + ","
//    + nullChk(store.CertiTaxID) + ","
//    + nullChk(store.CertiTaxNexus) + ","
//    + nullChk(store.LeadAdminEmail) + ","
//    + nullChk(store.ContactUsPerson) + ","
//    + nullChk(store.EmailShipConfirmTemplate) + ","
//    + nullChk(store.EmailOrderConfirmTemplate) + ","
//    + nullChk(store.DeletedFlag) + ""
//    + ")";

//sql = "UPDATE Store SET "
//    + "store_id = " + nullChk(store.StoreId) + ","
//    + "whse_id = " + nullChk(store.WhseId) + ","
//    + "name = " + nullChk(store.Name) + ","
//    + "title = " + nullChk(store.Title) + ","
//    + "public_access_flag = " + nullChk(store.PublicAccessFlag) + ","
//    + "active_flag = " + nullChk(store.ActiveFlag) + ","
//    + "logo_align = " + nullChk(store.LogoAlign) + ","
//    + "cart_bg = " + nullChk(store.CartBg) + ","
//    + "cart_width = " + nullChk(store.CartWidth) + ","
//    + "store_bg = " + nullChk(store.StoreBg) + ","
//    + "search = " + nullChk(store.Search) + ","
//    + "status = " + nullChk(store.Status) + ","
//    + "store_path = " + nullChk(store.StorePath) + ","
//    + "login_page = " + nullChk(store.LoginPage) + ","
//    + "start_page = " + nullChk(store.StartPage) + ","
//    + "home_page = " + nullChk(store.HomePage) + ","
//    + "start_dept = " + nullChk(store.StartDept) + ","
//    + "top_frame_height = " + nullChk(store.TopFrameHeight) + ","
//    + "top_bg_color = " + nullChk(store.TopBgColor) + ","
//    + "top_border_color = " + nullChk(store.TopBorderColor) + ","
//    + "top_graphic_height = " + nullChk(store.TopGraphicHeight) + ","
//    + "top_graphic_width = " + nullChk(store.TopGraphicWidth) + ","
//    + "top_dept_refresh = " + nullChk(store.TopDeptRefresh) + ","
//    + "btn_checkout = " + nullChk(store.BtnCheckout) + ","
//    + "btn_modify = " + nullChk(store.BtnModify) + ","
//    + "link_color = " + nullChk(store.LinkColor) + ","
//    + "vlink_color = " + nullChk(store.VlinkColor) + ","
//    + "cart_link_color = " + nullChk(store.CartLinkColor) + ","
//    + "cart_vlink_color = " + nullChk(store.CartVlinkColor) + ","
//    + "cart_alink_color = " + nullChk(store.CartAlinkColor) + ","
//    + "cart_font_color = " + nullChk(store.CartFontColor) + ","
//    + "cart_table_font_color = " + nullChk(store.CartTableFontColor) + ","
//    + "cart_bg_color = " + nullChk(store.CartBgColor) + ","
//    + "cart_border_color = " + nullChk(store.CartBorderColor) + ","
//    + "font_face = " + nullChk(store.FontFace) + ","
//    + "font_size = " + nullChk(store.FontSize) + ","
//    + "font_color = " + nullChk(store.FontColor) + ","
//    + "td_bg_color = " + nullChk(store.TdBgColor) + ","
//    + "td_color = " + nullChk(store.TdColor) + ","
//    + "th_bg_color = " + nullChk(store.ThBgColor) + ","
//    + "th_color = " + nullChk(store.ThColor) + ","
//    + "dept_label = " + nullChk(store.DeptLabel) + ","
//    + "sub_dept_label = " + nullChk(store.SubDeptLabel) + ","
//    + "over_commit_rule = " + nullChk(store.OverCommitRule) + ","
//    + "intro_msg = " + nullChk(store.IntroMsg) + ","
//    + "login_msg_bottom = " + nullChk(store.LoginMsgBottom) + ","
//    + "item_label = " + nullChk(store.ItemLabel) + ","
//    + "item_name_label = " + nullChk(store.ItemNameLabel) + ","
//    + "item_graphic_width = " + nullChk(store.ItemGraphicWidth) + ","
//    + "line_handling_fee = " + nullChk(store.LineHandlingFee) + ","
//    + "order_shipping_charge = " + nullChk(store.OrderShippingCharge) + ","
//    + "order_Canada_shipping_charge = " + nullChk(store.OrderCanadaShippingCharge) + ","
//    + "order_International_shipping_charge = " + nullChk(store.OrderInternationalShippingCharge) + ","
//    + "order_confirm_msg = " + nullChk(store.OrderConfirmMsg) + ","
//    + "max_width = " + nullChk(store.MaxWidth) + ","
//    + "product_type_label = " + nullChk(store.ProductTypeLabel) + ","
//    + "user_regions = " + nullChk(store.UserRegions) + ","
//    + "user_regions_label = " + nullChk(store.UserRegionsLabel) + ","
//    + "cost_center_label = " + nullChk(store.CostCenterLabel) + ","
//    + "division_cost_center_label = " + nullChk(store.DivisionCostCenterLabel) + ","
//    + "user_dept_label = " + nullChk(store.UserDeptLabel) + ","
//    + "product_label = " + nullChk(store.ProductLabel) + ","
//    + "bundle_label = " + nullChk(store.BundleLabel) + ","
//    + "product_subtype_label = " + nullChk(store.ProductSubtypeLabel) + ","
//    + "customer_contact_email = " + nullChk(store.CustomerContactEmail) + ","
//    + "CertiTaxID = " + nullChk(store.CertiTaxID) + ","
//    + "CertiTaxNexus = " + nullChk(store.CertiTaxNexus) + ","
//    + "lead_admin_email = " + nullChk(store.LeadAdminEmail) + ","
//    + "contact_us_person = " + nullChk(store.ContactUsPerson) + ","
//    + "email_ship_confirm_template = " + nullChk(store.EmailShipConfirmTemplate) + ","
//    + "email_order_confirm_template = " + nullChk(store.EmailOrderConfirmTemplate) + ","
//    + "deleted_flag = " + nullChk(store.DeletedFlag) + ""
//[INSERT WHERE CLAUSE HERE];
	}
}
