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

public partial class JuniperOrderedItemsReport : System.Web.UI.Page
{
    public static string mUserId;
    private static int mStoreId = 240;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];
            Session["UserId"] = mUserId;
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

    protected void CalendarToDate_SelectionChanged(object sender, EventArgs e)
    {
        if (CalendarToDate.SelectedDate < CalendarFromDate.SelectedDate)
        {
            CalendarFromDate.SelectedDate = CalendarToDate.SelectedDate;
            CalendarFromDate.VisibleDate = CalendarFromDate.SelectedDate;
        }
        DisplayDates();
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

    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        int rowindx, colindx;
        JuniperOrderedItemsInfo[] reportdata = null;

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        workbook.Sheets[0].Name = "Ordered Items Report";
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Ordered Items Report"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Ordered Items Report";
        string filters = "";

        string dates = string.Format("Date Range: From {0} to {1}",
            CalendarFromDate.SelectedDate.ToShortDateString(),
            CalendarToDate.SelectedDate.ToShortDateString());

        cells[0, 0].Formula = string.Format("Juniper Most Ordered Items Report");

        cells[0, 0, 0, 8].Merge();
        cells[0, 0, 0, 8].Font.Bold = true;
        cells[0, 0, 0, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

        cells[1, 0].Formula = filters;
        cells[1, 0, 1, 8].Merge();
        cells[1, 0, 1, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

        cells[2, 0].Formula = dates;
        cells[2, 0, 2, 8].Merge();
        cells[2, 0, 2, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

        // Load column titles and center.
        int HeaderCols = 0;
        cells[5, HeaderCols++].Formula = "Item ID";
        cells[5, HeaderCols++].Formula = "Product Name";
        cells[5, HeaderCols++].Formula = "Total Orders";
        cells[5, HeaderCols++].Formula = "Total Qty";
        cells[5, HeaderCols++].Formula = "Total Price";

        cells[5, 0, 5, HeaderCols].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, 5, HeaderCols].Font.Bold = true;

        rowindx = 7;
        reportdata = PBA.OnfBLL.JuniperOrderedItemsReport.GetJuniperOrderedItems(mStoreId, CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate.AddDays(1));
        foreach (JuniperOrderedItemsInfo cri in reportdata)
        {
            colindx = 0;
            cells[rowindx, colindx++].Formula = cri.ItemID;
            cells[rowindx, colindx++].Formula = cri.ProductName;
            cells[rowindx, colindx++].Formula = cri.ItemCount.ToString();
            cells[rowindx, colindx++].Formula = cri.TotalQty.ToString();
            cells[rowindx, colindx++].Formula = cri.TotalPrice.ToString();
            rowindx++;
        }

        cells[5, 0, rowindx, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, rowindx, 8].Columns.AutoFit();

        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);

        if (chkboxOutputHTML.Checked)
        {
            // we need to output HTML!
            pnlGenerateReport.Visible = false;
            pnlHTMLReport.Visible = true;

            htmlTable.Rows.AddRange(ReportFunctions.convertExcelToHTML(workbook, 17, rowindx));
        }
        else
        {
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=CostReport.xls");
            Response.BinaryWrite(data);
            Response.End();
        }
    }
}
