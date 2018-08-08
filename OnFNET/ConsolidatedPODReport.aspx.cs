using System;
using System.Web;
using System.Web.UI.WebControls;
using PBA.OnfBLL;
using PBA.OnfInfo;

public partial class ConsolidatedPODReport : System.Web.UI.Page
{
    private string mUserId;
    private SpreadsheetGear.IRange mCells;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];

            if (string.IsNullOrEmpty(mUserId))
            {
                Response.Redirect("unauthorized.htm");
            }
            Session["UserId"] = mUserId;

            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;
            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();

            DisplayDates();
            DisplayVisibleMonth(DateTime.Today);

        }

    }

    private void DisplayDates()
    {
        LabelFromDate.Text = string.Format("From: {0}", CalendarFromDate.SelectedDate.ToShortDateString());
        LabelToDate.Text = string.Format("To: {0}", CalendarToDate.SelectedDate.ToShortDateString());
    }

    private void DisplayVisibleMonth(DateTime date)
    {
        LinkButtonSelectMonth.Text = "Select entire month of " + date.ToString("MMMM, yyyy");
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
    protected void CalendarFromDate_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        DisplayVisibleMonth(e.NewDate);
        HiddenFieldDate.Value = e.NewDate.ToShortDateString();
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
    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        DateTime fromdate = CalendarFromDate.SelectedDate;
        DateTime todate = CalendarToDate.SelectedDate;

        GenericPODReportInfo[] infos = GenericPODReport.GetGenericPODReport(fromdate, todate);
        
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
        mCells = worksheet.Cells;

        string dates = string.Format("Date Range: From {0} to {1}",
           CalendarFromDate.SelectedDate.ToShortDateString(),
           CalendarToDate.SelectedDate.ToShortDateString());

        if (infos.Length == 0)
        {
            mCells[0, 0].Font.Bold = true;
            mCells[2, 0].Formula = "No data found for this date range.";
            mCells[2, 0].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        }
        else
        {
            int storeid = -1;

            int rowindx = 0;
            int colindx = 0;
            foreach (GenericPODReportInfo info in infos)
            {
                if (storeid != info.StoreId)
                {
                    rowindx = 0;
                    if (storeid == -1)
                    {
                        // first time through
                        worksheet.Name = info.StoreName;

                    }
                    else
                    {
                        mCells[1, 0, 1, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                        mCells[1, 0, 1, 8].Columns.AutoFit();
                        mCells.Cells[0, 0, 0, colindx].Columns.EntireColumn.AutoFit();

                        worksheet = workbook.Worksheets.Add();
                        worksheet.Name = info.StoreName;
                        mCells = worksheet.Cells;

                    }

                    mCells[rowindx, 0, rowindx, 8].Formula =
                        String.Format("Consolidated POD report for {0}", info.StoreName);
                    mCells[rowindx, 0, rowindx, 8].Merge();
                    mCells[rowindx, 0, rowindx, 8].Font.Bold = true;
                    mCells[rowindx, 0, rowindx, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

                    rowindx++;
                    mCells[rowindx, 0].Formula = dates;
                    mCells[rowindx, 0, rowindx, 8].Merge();
                    mCells[rowindx, 0, rowindx, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                    rowindx = 3;
                    // Load column titles and center.
                    int HeaderCols = 0;
                    mCells[rowindx, HeaderCols++].Formula = "Order ID";
                    mCells[rowindx, HeaderCols++].Formula = "Order Placed";
                    mCells[rowindx, HeaderCols++].Formula = "Order Shipped";
                    mCells[rowindx, HeaderCols++].Formula = "UserType";

                    mCells[rowindx, HeaderCols++].Formula = "Dept Code";

                    mCells[rowindx, HeaderCols++].Formula = "Last Name";
                    mCells[rowindx, HeaderCols++].Formula = "First Name";
                    mCells[rowindx, HeaderCols++].Formula = "Company";
                    mCells[rowindx, HeaderCols++].Formula = "Department";

                    mCells[rowindx, HeaderCols++].Formula = "Address 1";
                    mCells[rowindx, HeaderCols++].Formula = "City";
                    mCells[rowindx, HeaderCols++].Formula = "State";
                    mCells[rowindx, HeaderCols++].Formula = "Country";
                    mCells[rowindx, HeaderCols++].Formula = "Zip";

                    mCells[rowindx, HeaderCols++].Formula = "Item ID";
                    mCells[rowindx, HeaderCols++].Formula = "Qty Ordered";
                    mCells[rowindx, HeaderCols++].Formula = "Page Count";
                    mCells[rowindx, HeaderCols++].Formula = "Print Location";
                    mCells[rowindx, HeaderCols++].Formula = "Fulfillment Location";
                    mCells[rowindx, HeaderCols++].Formula = "Onf Cost"; // Current Onf Cost for item, dynamic and not historic
                    mCells[rowindx, HeaderCols++].Formula = "Print Location Multiplier";
                    mCells[rowindx, HeaderCols++].Formula = "Global Print Cost"; //Onf Cost from order line (should be the same as Base Cost * Multiplier), historical

                    mCells[rowindx, 0, rowindx, HeaderCols].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                    mCells[rowindx, 0, rowindx, HeaderCols].Font.Bold = true;

                    rowindx = 5;

                    storeid = (int) info.StoreId;
                }
                colindx = 0;
                mCells[rowindx, colindx++].Formula = info.OrderId.ToString();
                mCells[rowindx, colindx++].Formula = info.DateOrdered.Value.ToString();

                mCells[rowindx, colindx++].Formula = 
                    info.DateShipped.HasValue == false ? "" : info.DateShipped.Value.ToString();

                if (info.UserType.ToLower().Contains("partner"))
                {
                    info.Department = "partner - NA";
                }

                mCells[rowindx, colindx++].Formula = info.UserType;

                mCells[rowindx, colindx++].Formula = info.CustomerOrderNumber;

                mCells[rowindx, colindx++].Formula = info.LastName ?? "";
                mCells[rowindx, colindx++].Formula = info.FirstName ?? "";
                mCells[rowindx, colindx++].Formula = info.Address.Company ?? "";
                mCells[rowindx, colindx++].Formula = info.Department ?? "";

                mCells[rowindx, colindx++].Formula = info.Address.Address1 ?? "";
                mCells[rowindx, colindx++].Formula = info.Address.City ?? "";
                mCells[rowindx, colindx++].Formula = info.Address.State ?? "";
                mCells[rowindx, colindx++].Formula = info.Address.Country ?? "";
                mCells[rowindx, colindx++].Formula = info.Address.Zip ?? "";

                mCells[rowindx, colindx++].Formula = info.ItemID;
                mCells[rowindx, colindx++].Formula = info.QtyOrdered.ToString();
                mCells[rowindx, colindx++].Formula = info.PageCount.ToString();
                mCells[rowindx, colindx++].Formula = info.PrintLocationId;
                mCells[rowindx, colindx++].Formula = info.FulfillmentLocationId;
                mCells[rowindx, colindx++].Formula = info.OnfCostBase.ToString();

                mCells[rowindx, colindx++].Formula = 
                    info.OnfCostMultiplier.HasValue == false ? "1" : info.OnfCostMultiplier.ToString();

                mCells[rowindx, colindx].Formula = 
                    info.OnfCost.HasValue == false ? info.OnfCostBase.ToString() : info.OnfCost.ToString();
                rowindx++;
            }

            if (infos.Length > 0)
            {
                mCells[1, 0, rowindx, 1].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                mCells[1, 0, rowindx, 1].Columns.AutoFit();
                mCells.Cells[0, 0, 0, colindx].Columns.EntireColumn.AutoFit();
            }
            byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.Excel8);

            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=ConsolidatedPODReport.xls");
            Response.BinaryWrite(data);
            Response.End();
        }
    }
}
