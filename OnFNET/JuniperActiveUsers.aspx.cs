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

public partial class JuniperActiveUsers : System.Web.UI.Page
{
    public static string mUserId;
    private static int mStoreId;

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
        JuniperActiveUserReportInfo[] reportdata = null;

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        workbook.Sheets[0].Name = "Active User Report";
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Active User Report"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Active Report";
        string filters = "";

        string dates = string.Format("Date Range: From {0} to {1}, SSO only: {2}",
            CalendarFromDate.SelectedDate.ToShortDateString(),
            CalendarToDate.SelectedDate.ToShortDateString(), chkboxSSO.Checked.ToString());

        cells[0, 0].Formula = string.Format("Juniper Active User Report");

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
        cells[5, HeaderCols++].Formula = "UserType";
        cells[5, HeaderCols++].Formula = "Count";

        cells[5, 0, 5, HeaderCols].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, 5, HeaderCols].Font.Bold = true;

        rowindx = 7;
        reportdata = PBA.OnfBLL.JuniperActiveUserReport.GetJuniperActiveUserReport(mStoreId, CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate.AddDays(1), chkboxSSO.Checked);
        foreach (JuniperActiveUserReportInfo cri in reportdata)
        {
            colindx = 0;
            cells[rowindx, colindx++].Formula = cri.UserType;
            cells[rowindx, colindx++].Formula = cri.Count.ToString();
            rowindx++;
        }

        cells[5, 0, rowindx, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, rowindx, 8].Columns.AutoFit();

        JuniperActiveUsersInfo[] reportdatadetail = PBA.OnfBLL.JuniperActiveUserReport.GetJuniperActiveUsers(mStoreId, CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate.AddDays(1), chkboxSSO.Checked);
        worksheet = workbook.Worksheets.Add();
        worksheet.Name = "User Details";
        cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "User Details";

        cells[0, 0].Formula = string.Format("Juniper Active User Report Details");

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
        HeaderCols = 0;
        cells[5, HeaderCols++].Formula = "Last Login";
        cells[5, HeaderCols++].Formula = "UserType";
        cells[5, HeaderCols++].Formula = "Last Name";
        cells[5, HeaderCols++].Formula = "First Name";
        cells[5, HeaderCols++].Formula = "Email";
        cells[5, HeaderCols++].Formula = "Company";
        cells[5, HeaderCols++].Formula = "Department";

        cells[5, HeaderCols++].Formula = "Address 1";
        cells[5, HeaderCols++].Formula = "City";
        cells[5, HeaderCols++].Formula = "State";
        cells[5, HeaderCols++].Formula = "Country";
        cells[5, HeaderCols++].Formula = "Zip";

        cells[5, 0, 5, HeaderCols].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, 5, HeaderCols].Font.Bold = true;

        rowindx = 6;
        foreach (JuniperActiveUsersInfo cri in reportdatadetail)
        {
            colindx = 0;
            cells[rowindx, colindx++].Formula = cri.LastLogin.ToString();
            cells[rowindx, colindx++].Formula = cri.UserType;
            cells[rowindx, colindx++].Formula = cri.LastName;
            cells[rowindx, colindx++].Formula = cri.FirstName;
            cells[rowindx, colindx++].Formula = cri.Email;
            cells[rowindx, colindx++].Formula = cri.Address.Company;
            cells[rowindx, colindx++].Formula = cri.Department;

            cells[rowindx, colindx++].Formula = cri.Address.Address1;
            cells[rowindx, colindx++].Formula = cri.Address.City;
            cells[rowindx, colindx++].Formula = cri.Address.State;
            cells[rowindx, colindx++].Formula = cri.Address.Country;
            cells[rowindx, colindx++].Formula = cri.Address.Zip;
            rowindx++;
        }
        cells[5, 0, rowindx, 11].Columns.AutoFit();
        workbook.Worksheets[0].Select();

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
