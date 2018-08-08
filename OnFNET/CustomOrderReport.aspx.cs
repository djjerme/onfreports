using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PBA.OnfBLL;
using PBA.OnfDAL;
using PBA.OnfInfo;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

public partial class CustomOrderReport : System.Web.UI.Page
{
    public static string mUserId;
    public static int mStoreId;
    protected static string dbConnection = ConfigurationManager.AppSettings["dbConnection"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mStoreId = int.Parse(HttpContext.Current.Request.QueryString["sid"]);
        }
        catch
        {
            Response.End();
        }

        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];
            Session["UserId"] = mUserId;
            Session["StoreId"] = mStoreId.ToString();

        }
    }

    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    protected void dgReport_Sort(object sender, EventArgs e)
    {
    }

    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
    }


    protected void LoadReport()
    {

        DataSet results = GetData();

        if (results.Tables[0].Rows.Count == 0)
        {
            dgReport.Visible = false;
        }
        else
        {
            dgReport.DataSource = results;
            dgReport.DataBind();
            dgReport.Visible = true;
        }



    }

    protected DataSet GetData()
    {
        string sqlQuery;
        DataSet dsResults;

        sqlQuery = @"SELECT 
        CAST(o.order_id AS varchar) + '-' + CAST(o.order_suffix AS varchar) AS order_number,
        o.*,
        p.first_name AS billing_first_name,
        p.last_name AS billing_last_name,
        p.email AS billing_email,
        a.company AS billing_company,
        a.address_1 AS billing_address_1,
        a.address_2 AS billing_address_2,
        a.city AS billing_city,
        a.state AS billing_state,
        a.zip AS billing_zip,
        a.country AS billing_country,
        a.bus_phone AS billing_bus_phone,
        a.home_phone AS billing_home_phone,
        p2.first_name AS shipping_first_name,
        p2.last_name AS shipping_last_name,
        p2.email AS shipping_email,
        a2.company AS shipping_company,
        a2.address_1 AS shipping_address_1,
        a2.address_2 AS shipping_address_2,
        a2.city AS shipping_city,
        a2.state AS shipping_state,
        a2.zip AS shipping_zip,
        a2.country AS shipping_country,
        a2.bus_phone AS shipping_bus_phone,
        a2.home_phone AS shipping_home_phone
        FROM order_head o  
        LEFT OUTER JOIN person p ON o.store_id = p.store_id and o.person_id = p.person_id  
        LEFT OUTER JOIN person p2 ON o.store_id = p2.store_id and o.send_to_person = p2.person_id  
        LEFT OUTER JOIN address a ON a.store_id = p.store_id and a.person_id = p.person_id and a.address_id = 0  
        LEFT OUTER JOIN address a2 ON a2.store_id = p2.store_id and a2.person_id = p2.person_id and a2.address_id = o.send_to_address  
        WHERE o.store_id = @store_id";

        sqlQuery += " ORDER BY order_when DESC";

        dsResults = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, sqlQuery);

        return dsResults;

    }


}
