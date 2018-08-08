using System;
using System.Data;
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

public partial class InventorySnapshot : System.Web.UI.Page
{
    public static string mUserId;
    private static int mStoreId;
    private static bool mWhseUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        mWhseUser = ((HttpContext.Current.Request.QueryString["W"] != null) && (HttpContext.Current.Request.QueryString["W"].ToString() == "4964"));

        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];

            if (mWhseUser)
            {
                if ((mUserId == null) || (mUserId == ""))
                {
                    Response.Redirect("unauthorized.htm");
                }
                Session["UserId"] = mUserId;
                mStoreId = 0;
                try
                {
                    mStoreId = Convert.ToInt32(HttpContext.Current.Request.QueryString["s"]);

                }
                catch (Exception)
                {
                }
                if (mStoreId != 0)
                {
                    if (Authentication.ValidateHandler(mStoreId, mUserId) == false)
                    {
                        Response.Redirect("unauthorized.htm");
                    }
                }
                DropDownListStore.DataBind();
                if (mStoreId != 0)
                {
                    DropDownListStore.SelectedValue = mStoreId.ToString();
                }
                else
                {
                    mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
                }
            }
            else
            {
                mStoreId = Convert.ToInt32(HttpContext.Current.Request.QueryString["sid"]);
                DropDownListStore.Visible = false;
                LabelCustomer.Visible = false;
            }

            Session["StoreId"] = mStoreId.ToString();

            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;
            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();

            DisplayDates();
            DisplayVisibleMonth(CalendarFromDate.SelectedDate);
        }

        if (mWhseUser)
        {
            Control UserControl;
            UserControl = LoadControl("MenuBarNET2.ascx");

            PanelMenuBar.Controls.Add(UserControl);
        }
    }
    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        GenerateXLS();
    }

    private void GenerateXLS()
    {
        int rowindx, indx;
        DateTime? earliest = ((DateTime?) null);
        DateTime? latest = ((DateTime?) null);

        InventorySnapshotInfo[] snapshots = InventorySnapshotData.GetInventorySnapshot(mStoreId,
            CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate, CheckBoxArchive.Checked);

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Inventory Snapshot Report";

        string dates = string.Format("Date Range: From {0} to {1}",
           CalendarFromDate.SelectedDate.ToShortDateString(),
           CalendarToDate.SelectedDate.ToShortDateString());

        if (mWhseUser)
        {
            cells[0, 0].Formula =
                string.Format("Inventory Snapshot Report for {0}", DropDownListStore.SelectedItem.Text);
        }
        else
        {
            cells[0, 0].Formula = "Inventory Snapshot Report";
        }

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
                if ((!((bool) snapshot.BegSnapshotExists)) && (!((bool) snapshot.EndSnapshotExists)))
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
                        cells[5, indx++].Formula = transinfo.Action;
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
                    cells[rowindx, indx++].Formula = transinfo.Qty.ToString();
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
        Response.AddHeader("Content-Disposition", "attachment; filename=InventorySnapshotReport.xls");
        Response.BinaryWrite(data);
        Response.End();
    }

    private void GenerateCSV()
    {
        InventorySnapshotInfo[] snapshots = InventorySnapshotData.GetInventorySnapshot(mStoreId,
            CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate, CheckBoxArchive.Checked);

        Response.Clear();
        Response.ContentType = "text/comma-delimited";
        Response.AddHeader("Content-Disposition", "filename=Snapshot.csv");

        Response.Write("\"Inventory Snapshot Report for Date Range: ");
        Response.Write(CalendarFromDate.SelectedDate.ToShortDateString());
        Response.Write(" to ");
        Response.Write(CalendarToDate.SelectedDate.ToShortDateString());
        Response.Write("\"\n");

        if (snapshots.Length == 0)
        {
            Response.Write("\"No data found for this date range for store " + mStoreId.ToString() + "\"\n");
        }
        else
        {

            bool lHeader = true;
            foreach (InventorySnapshotInfo snapshot in snapshots)
            {
                if (lHeader)
                {
                    Response.Write("\"Earliest snapshot date found: ");
                    Response.Write(((DateTime)snapshot.BegDate).ToShortDateString());
                    Response.Write(" ");
                    Response.Write(((DateTime)snapshot.BegDate).ToShortTimeString());
                    Response.Write("\"\n");

                    Response.Write("\"Latest snapshot date found: ");
                    Response.Write(((DateTime)snapshot.EndDate).ToShortDateString());
                    Response.Write(" ");
                    Response.Write(((DateTime)snapshot.EndDate).ToShortTimeString());
                    Response.Write("\"\n\n");

                    Response.Write("\"Product Group\",\"Raw / Finished\",\"Product Name\",\"Item Id\",\"Beginning On Hand\"");
                    foreach (InventoryTransactionInfo transinfo in snapshot.Transactions)
                    {
                        Response.Write(",\"");
                        Response.Write(transinfo.Action);
                        Response.Write("\"");
                    }

                    //Response.Write(",\"Ending On Hand\",\"Discrepancy\"\n");
                    Response.Write(",\"Ending On Hand\"\n");
                    lHeader = false;
                }

                Response.Write("\"");
                Response.Write(snapshot.DeptName);
                Response.Write("\"");

                Response.Write(",\"");
                Response.Write(snapshot.SubDeptName);
                Response.Write("\"");

                Response.Write(",\"");
                Response.Write(snapshot.ProductName);
                Response.Write("\"");

                Response.Write(",\"");
                Response.Write(snapshot.ItemId);
                Response.Write("\"");

                Response.Write(",\"");
                Response.Write(snapshot.BegQty.ToString());
                Response.Write("\"");

                int discrepancy = (int)snapshot.BegQty;
                foreach (InventoryTransactionInfo transinfo in snapshot.Transactions)
                {
                    Response.Write(",\"");
                    Response.Write(transinfo.Qty.ToString());
                    Response.Write("\"");
                    discrepancy += (int)transinfo.Qty;
                }

                discrepancy -= (int)snapshot.EndQty;

                Response.Write(",\"");
                Response.Write(snapshot.EndQty.ToString());
                //Response.Write("\",\"");

                //if (discrepancy != 0)
                //{
                //    Response.Write(discrepancy.ToString());
                //}
                Response.Write("\"\n");
            }
        }

        Response.End();
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
    protected void DropDownListStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
        Session["StoreId"] = mStoreId.ToString();
    }
}
