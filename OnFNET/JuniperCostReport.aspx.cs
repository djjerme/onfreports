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


public partial class JuniperCostReport : System.Web.UI.Page
{
    public static string mUserId;
    private static int mStoreId;
    private static bool mWhseUser;

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

            DropDownListDepartment.DataBind();

            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();
            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;

            DisplayDates();
            DisplayVisibleMonth(CalendarFromDate.SelectedDate);
        }
    }

    protected void DropDownListDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenFieldDate.Value = DropDownListDepartment.SelectedValue;
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

        JuniperCostReportInfo[] costreports = PBA.OnfBLL.JuniperCostReport.GetJuniperCostReport(mStoreId, CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate.AddDays(1), Convert.ToInt32(DropDownListDepartment.SelectedValue), DropDownListUserType.SelectedValue == "(All)" ? "" : DropDownListUserType.SelectedValue);

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        workbook.Sheets[0].Name = "Cost Report";
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Cost Report"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Juniper Cost Report";

        string filters = string.Format("Filters: Department = {0}, User type = {1}",
            DropDownListDepartment.SelectedItem.Text,
            DropDownListUserType.SelectedItem.Text);

        string dates = string.Format("Date Range: From {0} to {1}",
            CalendarFromDate.SelectedDate.ToShortDateString(),
            CalendarToDate.SelectedDate.ToShortDateString());

        cells[0, 0].Formula = string.Format("Juniper Cost Report");

        decimal GrandTotalValue = 0m;
        decimal GrandTotalCost = 0m;

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
        cells[5, HeaderCols++].Formula = "Order ID";
        cells[5, HeaderCols++].Formula = "Date Ordered";
        cells[5, HeaderCols++].Formula = "User Type";
        cells[5, HeaderCols++].Formula = "Region";
        cells[5, HeaderCols++].Formula = "Last Name";
        cells[5, HeaderCols++].Formula = "First Name";
        cells[5, HeaderCols++].Formula = "Company";
        cells[5, HeaderCols++].Formula = "Department";

        cells[5, HeaderCols++].Formula = "Address 1";
        cells[5, HeaderCols++].Formula = "City";
        cells[5, HeaderCols++].Formula = "State";
        cells[5, HeaderCols++].Formula = "Country";
        cells[5, HeaderCols++].Formula = "Zip";

        cells[5, HeaderCols++].Formula = "Ship Date";
        cells[5, HeaderCols++].Formula = "Status";
        cells[5, HeaderCols++].Formula = "Item ID";
        cells[5, HeaderCols++].Formula = "Qty";
        cells[5, HeaderCols++].Formula = "Value";
        cells[5, HeaderCols++].Formula = "Cost";

        cells[5, 0, 5, HeaderCols].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, 5, HeaderCols].Font.Bold = true;

        rowindx = 6;
        int maxColIndx = 0;
        foreach (JuniperCostReportInfo cri in costreports)
        {
            if (cri.UserType.ToLower().Contains("partner"))
            {
                cri.Department = "partner - NA";
            }

            colindx = 0;
            cells[rowindx, colindx++].Formula = cri.OrderId.ToString();
            cells[rowindx, colindx++].Formula = cri.DateOrdered.Value.ToString();
            cells[rowindx, colindx++].Formula = cri.UserType;
            cells[rowindx, colindx++].Formula = cri.Region;
            cells[rowindx, colindx++].Formula = cri.LastName;
            cells[rowindx, colindx++].Formula = cri.FirstName;
            cells[rowindx, colindx++].Formula = cri.Address.Company;
            cells[rowindx, colindx++].Formula = cri.Department;

            cells[rowindx, colindx++].Formula = cri.Address.Address1;
            cells[rowindx, colindx++].Formula = cri.Address.City;
            cells[rowindx, colindx++].Formula = cri.Address.State;
            cells[rowindx, colindx++].Formula = cri.Address.Country;
            cells[rowindx, colindx++].Formula = cri.Address.Zip;

            if (cri.ShipDate.HasValue)
            {
                cells[rowindx, colindx++].Formula = cri.ShipDate.Value.ToString();
            }
            else
            {
                cells[rowindx, colindx++].Formula = "";
            }

            cells[rowindx, colindx++].Formula = cri.Status;
            rowindx++;

            // lets add the order lines to the report now

            decimal totalOLValue = 0m;
            decimal totalOLCost = 0m;

            foreach (JuniperCostReportLineInfo crli in cri.OrderLines)
            {
                int orderLineColIndx = colindx;
                int QtyShipped = crli.Qty.Value;
                if (crli.QtyShipped.HasValue)
                {
                    QtyShipped = crli.QtyShipped.Value;
                }

                totalOLValue += QtyShipped * crli.Value.Value;
                totalOLCost += QtyShipped * crli.Cost.Value;

                cells[rowindx, orderLineColIndx++].Formula = crli.ItemId;
                cells[rowindx, orderLineColIndx++].Formula = QtyShipped.ToString();
                cells[rowindx, orderLineColIndx++].Formula = crli.Value.Value.ToString();
                cells[rowindx, orderLineColIndx++].Formula = crli.Cost.Value.ToString();
                rowindx++;
            }

            // print out the order line total summaries
            cells[rowindx, colindx + 2].Formula = totalOLValue.ToString();
            cells[rowindx, colindx + 2].Font.Bold = true;
            cells[rowindx, colindx + 2].Borders[SpreadsheetGear.BordersIndex.EdgeTop].LineStyle = SpreadsheetGear.LineStyle.Continuous;
            cells[rowindx, colindx + 3].Formula = totalOLCost.ToString();
            cells[rowindx, colindx + 3].Font.Bold = true;
            cells[rowindx, colindx + 3].Borders[SpreadsheetGear.BordersIndex.EdgeTop].LineStyle = SpreadsheetGear.LineStyle.Continuous;
            rowindx++;
            rowindx++;

            GrandTotalCost += totalOLCost;
            GrandTotalValue += totalOLValue;
            maxColIndx = colindx;
        }

        cells[rowindx, maxColIndx + 1].Formula = "Total:";
        cells[rowindx, maxColIndx + 1].Font.Bold = true;
        cells[rowindx, maxColIndx + 1].Borders[SpreadsheetGear.BordersIndex.EdgeTop].LineStyle = SpreadsheetGear.LineStyle.Double;

        cells[rowindx, maxColIndx + 2].Formula = GrandTotalValue.ToString();
        cells[rowindx, maxColIndx + 2].Font.Bold = true;
        cells[rowindx, maxColIndx + 2].Borders[SpreadsheetGear.BordersIndex.EdgeTop].LineStyle = SpreadsheetGear.LineStyle.Double;

        cells[rowindx, maxColIndx + 3].Formula = GrandTotalCost.ToString();
        cells[rowindx, maxColIndx + 3].Font.Bold = true;
        cells[rowindx, maxColIndx + 3].Borders[SpreadsheetGear.BordersIndex.EdgeTop].LineStyle = SpreadsheetGear.LineStyle.Double;

        cells[5, 0, rowindx, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, rowindx, 8].Columns.AutoFit();

        // below two needed? dont think so...
        cells[3, 0, 3, 8].Merge();
        cells[3, 0, 3, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

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

            /*
            DataSet dataSet = workbook.GetDataSet(SpreadsheetGear.Data.GetDataFlags.FormattedText);
            DataGrid1.DataSource = dataSet;
            DataGrid1.DataBind();
            */
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
