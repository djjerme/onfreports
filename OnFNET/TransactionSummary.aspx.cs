using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.ApplicationBlocks.Data;

using PBA.OnfBLL;
using PBA.OnfDAL;
using PBA.OnfInfo;


public partial class TransactionSummary : System.Web.UI.Page
{
    public static int mStoreId;

    protected void Page_Load(object sender, EventArgs e)
    {
        mStoreId = int.Parse(HttpContext.Current.Request.QueryString["sid"]);
        if (!IsPostBack)
        {
            Session["StoreId"] = mStoreId.ToString();

            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();
            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;

            DisplayDates();
            DisplayVisibleMonth(CalendarFromDate.SelectedDate);
        }
    }

    protected void CalendarFromDate_SelectionChanged(object sender, EventArgs e)
    {
        if (CalendarToDate.SelectedDate < CalendarFromDate.SelectedDate)
        {
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;
            CalendarToDate.VisibleDate = CalendarToDate.SelectedDate;
        }
        DisplayDates();
        HiddenFieldDate.Value = CalendarFromDate.SelectedDate.ToShortDateString();
        DisplayVisibleMonth(CalendarFromDate.SelectedDate);
    }
    protected void CalendarToDate_SelectionChanged(object sender, EventArgs e)
    {
        if (CalendarToDate.SelectedDate < CalendarFromDate.SelectedDate)
        {
            CalendarFromDate.SelectedDate = CalendarToDate.SelectedDate;
            CalendarFromDate.VisibleDate = CalendarFromDate.SelectedDate;
        }
        DisplayDates();
        HiddenFieldDate.Value = CalendarToDate.SelectedDate.ToShortDateString();
        DisplayVisibleMonth(CalendarToDate.SelectedDate);
    }
    private void DisplayDates()
    {
        LabelFromDate.Text = string.Format("From: {0}", CalendarFromDate.SelectedDate.ToShortDateString());
        LabelToDate.Text = string.Format("To: {0}", CalendarToDate.SelectedDate.ToShortDateString());
    }
    protected void LinkButtonSelectMonth_Click(object sender, EventArgs e)
    {
        DateTime date = Convert.ToDateTime(HiddenFieldDate.Value);
        CalendarFromDate.SelectedDate = Convert.ToDateTime(date).AddDays((-1 * date.Day) + 1);
        CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate.AddMonths(1);
        CalendarToDate.SelectedDate = CalendarToDate.SelectedDate.AddDays(-1);
        CalendarFromDate.VisibleDate = CalendarFromDate.SelectedDate;
        CalendarToDate.VisibleDate = CalendarToDate.SelectedDate;
        DisplayDates();
    }
    protected void CalendarFromDate_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        DisplayVisibleMonth(e.NewDate);
        HiddenFieldDate.Value = e.NewDate.ToShortDateString();
    }

    private void DisplayVisibleMonth(DateTime date)
    {
        LinkButtonSelectMonth.Text = "Select entire month of " + date.ToString("MMMM, yyyy");
    }


    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        GenerateXLS();
    }

    private void GenerateXLS()
    {
        int rowindx, indx;
        DateTime? earliest = ((DateTime?)null);
        DateTime? latest = ((DateTime?)null);

        StoreInfo store = StoreData.GetStore(mStoreId);

        InventorySnapshotInfo[] snapshots = GetInventorySnapshot(mStoreId,
            CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate);


        string dateLo = CalendarFromDate.SelectedDate.Date.ToString("MM/dd/yyyy");
        string dateHi = CalendarToDate.SelectedDate.Date.AddDays(1).ToString("MM/dd/yyyy");

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["dbConnection"];
            conn.Open();

            foreach (InventorySnapshotInfo snap in snapshots)
            {
                foreach (InventoryTransactionInfo info in snap.Transactions)
                {
                    if (info.Action.ToLower().Equals("pick order"))
                    {   
                        info.Action = "Shipped Orders";
                        info.Qty = 0;

                        string sqlCount = string.Format(sqlShipCount, snap.StoreId,
                                                            dateLo, dateHi, snap.ItemId);
                        try
                        {
                            info.Qty = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.Text, sqlCount));
                        }
                        catch (Exception ex)
                        {
                            Response.Clear();
                            Response.Write(sqlCount);
                            Response.Write(ex.Message);
                            Response.End();
                        }

                        break;
                    }
                }
            }
            conn.Close();
        }



        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Transaction Summary Report";

        string dates = string.Format("Date Range: From {0} to {1}",
           CalendarFromDate.SelectedDate.ToShortDateString(),
           CalendarToDate.SelectedDate.ToShortDateString());

        cells[0, 0].Formula = string.Format("Transaction Summary Report for {0}", store.Name);
        cells[1, 0].Formula = dates;

        if (snapshots.Length == 0)
        {
            cells[0, 0].Font.Bold = true;
            cells[2, 0].Formula = "No data found for this date range for store " + mStoreId.ToString();
            cells[2, 0].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        }
        else
        {

            bool lHeader = true;
            rowindx = 6;
            indx = 5;

            foreach (InventorySnapshotInfo snapshot in snapshots)
            {
                bool exclude = true;
                if ((!((bool)snapshot.BegSnapshotExists)) && (!((bool)snapshot.EndSnapshotExists)))
                {
                    foreach (InventoryTransactionInfo transinfo in snapshot.Transactions)
                    {
                        if (transinfo.Qty != 0)
                        {
                            exclude = false;
                            break;
                        }
                    }

                    if (exclude)
                    {
                        continue;
                    }
                }

                if (earliest == (DateTime?)null)
                {
                    earliest = snapshot.BegDate;
                }
                else
                {
                    if (snapshot.BegDate < earliest)
                    {
                        earliest = snapshot.BegDate;
                    }
                }

                if (latest == (DateTime?)null)
                {
                    latest = snapshot.EndDate;
                }
                else
                {
                    if (snapshot.EndDate > latest)
                    {
                        latest = snapshot.EndDate;
                    }
                }

                if (lHeader)
                {
                    cells[5, 0].Formula = "Product Group";
                    cells[5, 1].Formula = "Raw / Finished";
                    cells[5, 2].Formula = "Product Name";
                    cells[5, 3].Formula = "Item Id";
                    cells[5, 4].Formula = "Beginning On Hand";

                    foreach (InventoryTransactionInfo transinfo in snapshot.Transactions)
                    {
                        switch (transinfo.Action.ToLower())
                        {
                            case "adjust add"       : cells[5, indx++].Formula = transinfo.Action; break;
                            case "adjust subtract"  : cells[5, indx++].Formula = transinfo.Action; break;
                            case "pick manual"      : cells[5, indx++].Formula = transinfo.Action; break;
                            //case "pick move"      : cells[5, indx++].Formula = transinfo.Action; break;
                            case "shipped orders"   : cells[5, indx++].Formula = transinfo.Action; break;
                            //case "put manual"     : cells[5, indx++].Formula = transinfo.Action; break;
                            case "put receipt"      : cells[5, indx++].Formula = transinfo.Action; break;
                            //case "put_move"       : cells[5, indx++].Formula = transinfo.Action; break;
                            //case "scrap"          : cells[5, indx++].Formula = transinfo.Action; break;
                            case "unship"           : cells[5, indx++].Formula = transinfo.Action; break;
                        }
                        //cells[5, indx++].Formula = transinfo.Action;
                    }

                    cells[5, indx].Formula = "Ending On Hand";
                    cells[5, 0, 5, indx].Font.Bold = true;

                    cells[0, 0, 0, indx].Merge();
                    cells[0, 0, 0, indx].Font.Bold = true;
                    cells[0, 0, 0, indx].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

                    cells[1, 0, 1, indx].Merge();
                    cells[1, 0, 1, indx].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                    cells[2, 0, 2, indx].Merge();
                    cells[2, 0, 2, indx].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                    cells[3, 0, 3, indx].Merge();
                    cells[3, 0, 3, indx].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                    lHeader = false;
                }

                cells[rowindx, 0].Formula = snapshot.DeptName;
                cells[rowindx, 1].Formula = snapshot.SubDeptName;
                cells[rowindx, 2].Formula = snapshot.ProductName;
                cells[rowindx, 3].Formula = snapshot.ItemId;
                cells[rowindx, 4].Formula = snapshot.BegQty.ToString();

                indx = 5;

                int discrepancy = (int)snapshot.BegQty;
                foreach (InventoryTransactionInfo transinfo in snapshot.Transactions)
                {
                    switch (transinfo.Action.ToLower())
                    {
                        case "adjust add"       : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        case "adjust subtract"  : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        case "pick manual"      : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        //case "pick move"      : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        case "shipped orders"   : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        //case "put manual"     : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        case "put receipt"      : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        //case "put_move"       : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        //case "scrap"          : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                        case "unship"           : cells[rowindx, indx++].Formula = transinfo.Qty.ToString(); break;
                    }

                    //cells[rowindx, indx++].Formula = transinfo.Qty.ToString();
                    discrepancy += (int)transinfo.Qty;
                }

                cells[rowindx, indx].Formula = snapshot.EndQty.ToString();

                discrepancy -= (int)snapshot.EndQty;
                rowindx++;
            }
            cells[2, 0].Formula = "Earliest snapshot date found: "
                + ((DateTime)earliest).ToShortDateString()
                + " "
                + ((DateTime)earliest).ToShortTimeString();

            cells[3, 0].Formula = "Latest snapshot date found: "
                + ((DateTime)latest).ToShortDateString()
                + " "
                + ((DateTime)latest).ToShortTimeString();


            cells[5, 5, rowindx, indx].HorizontalAlignment = SpreadsheetGear.HAlign.Right;
            cells[5, 0, rowindx, indx].Columns.AutoFit();
        }


        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=TransactionSummaryReport.xls");
        Response.BinaryWrite(data);
        Response.End();
    }

    private static string sqlShipCount
        = " select sum(ol.qty_shipped) as ShipCount	"
        + " from order_head OH	"
        + " join order_line OL on OH.store_id = OL.store_id	"
        + "                   and OH.order_id = OL.order_id	"
        + "                   and OH.order_suffix = OL.order_suffix	"
        + " where OL.store_id = {0}	"
        + " and   OH.ship_date >= '{1}' and OH.ship_date < '{2}'	"
        + " and   OL.item_id = '{3}'	"
        + " group by OL.item_id	"
        + " order by OL.item_id	";
 


    private InventorySnapshotInfo[] GetInventorySnapshot (int storeid, DateTime startdate, DateTime enddate)
    {
        string startdatestr = DataAccess.Escape(((DateTime)(startdate)).ToString("MM/dd/yyyy"));
        string enddatestr = DataAccess.Escape(((DateTime)(enddate)).ToString("MM/dd/yyyy"));

        string dateLo = startdate.Date.ToString("MM/dd/yyyy");
        string dateHi = enddate.Date.AddDays(1).ToString("MM/dd/yyyy");

        using (SqlConnection conn = new SqlConnection())
        {
            ArrayList c = new ArrayList();

            string sqlSnapshot 
                = "select i.store_id, i.item_id, p.name product_name, "
                + "coalesce(d.name, '') dept_name, "
                + "coalesce(sd.name, '') sub_dept_name, "
                + "coalesce(is1.qty_on_hand, 0) beg_qty, "
                + "case when is1.snapshot_date is null then 0 else 1 end beg_snapshot_exists, "
                + "case when is2.snapshot_date is null then 0 else 1 end end_snapshot_exists, "
                + "coalesce(is1.snapshot_date, p.created_date) beg_date, "
                + "coalesce(is2.qty_on_hand, 0) end_qty, "
                + "coalesce(is2.snapshot_date, " 
                + "         (select max(snapshot_date) "
                + "             from inv_snapshot "
                + "          where snapshot_date <= DateAdd(dd, 1, '" + enddatestr + "') " 
                + "             and store_id = " + DataAccess.Escape(storeid.ToString()) + ")) end_date "
                + "from item i "
                + "inner join product p on i.store_id = p.store_id "
                + "   and i.product_id = p.product_id "
                + "left outer join dept_product dp on p.store_id = dp.store_id "
                + "   and p.product_id = dp.product_id "
                + "left outer  join dept d on dp.store_id = d.store_id "
                + "   and dp.dept_id = d.dept_id "
                + "left outer join sub_dept sd on dp.store_id = sd.store_id "
                + "   and dp.sub_dept_id = sd.sub_dept_id "
                + "left outer join inv_snapshot is1 on i.store_id = is1.store_id "
                + "   and i.item_id = is1.item_id "
                + "   and is1.snapshot_date = "
                + "     (select max(snapshot_date) from inv_snapshot "
                + "      where snapshot_date <= DateAdd(dd, 1, '" + startdatestr + "') "
                + "        and store_id = " + DataAccess.Escape(storeid.ToString())  
                + "        and item_id = i.item_id) "
                + "left outer join inv_snapshot is2 on i.store_id = is2.store_id "
                + "   and i.item_id = is2.item_id "
                + "   and is2.snapshot_date = "
                + "     (select max(snapshot_date) from inv_snapshot "
                + "      where snapshot_date <= DateAdd(dd, 1, '" + enddatestr + "') "
                + "         and store_id = " + DataAccess.Escape(storeid.ToString()) 
                + "         and item_id = i.item_id) "
                + " where i.store_id = " + DataAccess.Escape(storeid.ToString()) + " "
                + " and  is1.snapshot_date is not null "
                + " and  is2.snapshot_date is not null "
                + " and (   is1.snapshot_date >= '{0}' and is1.snapshot_date < '{1}' "
                + "      or is2.snapshot_date >= '{0}' and is2.snapshot_date < '{1}' ) "
                + " order by i.item_id";


            conn.ConnectionString = ConfigurationManager.AppSettings["dbConnection"];

            string sql = string.Format(sqlSnapshot, dateLo, dateHi);
            SqlDataReader d = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);

            while (d.Read())
            {
                InventorySnapshotInfo al = new InventorySnapshotInfo();

                al.StoreId = DataAccess.NCI(d["store_id"]);
                al.ItemId = DataAccess.NCS(d["item_id"]);
                al.ProductName = DataAccess.NCS(d["product_name"]);
                al.DeptName = DataAccess.NCS(d["dept_name"]);
                al.SubDeptName = DataAccess.NCS(d["sub_dept_name"]);
                al.BegSnapshotExists = DataAccess.NCB(d["beg_snapshot_exists"]);
                al.BegQty = DataAccess.NCI(d["beg_qty"]);
                al.BegDate = DataAccess.NCD(d["beg_date"]);
                al.EndSnapshotExists = DataAccess.NCB(d["end_snapshot_exists"]);
                al.EndQty = DataAccess.NCI(d["end_qty"]);
                al.EndDate = DataAccess.NCD(d["end_date"]);

                al.Transactions = InventoryTransactionData.GetInventoryTransaction(storeid,
                    al.ItemId, (DateTime)al.BegDate, (DateTime)al.EndDate);


                c.Add(al);
            }

            d.Close();

            return (InventorySnapshotInfo[])c.ToArray(typeof(InventorySnapshotInfo));
        }
    }
}
