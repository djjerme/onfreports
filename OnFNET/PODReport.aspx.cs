using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfBLL;
using PBA.OnfInfo;

public partial class PODReport : System.Web.UI.Page
{
    public static string mUserId;
    public static int mStoreId;
    private static bool mWhseUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        mWhseUser = ((HttpContext.Current.Request.QueryString["W"] != null) && (HttpContext.Current.Request.QueryString["W"].ToString() == "4964"));

        try
        {
            mStoreId = int.Parse(HttpContext.Current.Request.QueryString["sid"]);
        }
        catch
        {
        }

        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];
            Session["UserId"] = mUserId;
            Session["StoreId"] = mStoreId.ToString();

            DropDownListStore.DataBind();
            if (mStoreId != 0)
            {
                DropDownListStore.SelectedValue = mStoreId.ToString();
                Session["StoreId"] = mStoreId.ToString();
            }
            else
            {
                DropDownListStore.SelectedIndex = 0;
                mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
                Session["StoreId"] = mStoreId.ToString();
            }
            DropDownListDepartment.DataBind();

            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();
            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;

            DisplayDates();
            DisplayVisibleMonth(CalendarFromDate.SelectedDate);

        }
        if (mWhseUser)
        {
            Control UserControl;
            UserControl = LoadControl("MenuBarNET2.ascx");

            PanelMenuBar.Controls.Add(UserControl);
        }
        else
        {
            DropDownListStore.Visible = false;
            LabelCustomer.Visible = false;
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

        GenericPODReportInfo[] partreports = GenericPODReport.GetGenericPODReport(mStoreId, CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate.AddDays(1), Convert.ToInt32(DropDownListDepartment.SelectedValue), DropDownListUserType.SelectedValue == "(All)" ? "" : DropDownListUserType.SelectedValue);

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "POD Report";

        string filters = string.Format("Filters: Department = {0}, User type = {1}",
            DropDownListDepartment.SelectedItem.Text,
            DropDownListUserType.SelectedItem.Text);

        string dates = string.Format("Date Range: From {0} to {1}",
            CalendarFromDate.SelectedDate.ToShortDateString(),
            CalendarToDate.SelectedDate.ToShortDateString());

        if (mWhseUser)
        {
            cells[0, 0].Formula = string.Format("POD Report for {0}", DropDownListStore.SelectedItem.Text);
        }
        else
        {
            cells[0, 0].Formula = "POD Report";
        }
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
        cells[5, HeaderCols++].Formula = "Order Placed";
        cells[5, HeaderCols++].Formula = "Order Shipped";
        cells[5, HeaderCols++].Formula = "UserType";

        if (mStoreId == 318)
        {
            cells[5, HeaderCols++].Formula = "Dept Code";
        }

        cells[5, HeaderCols++].Formula = "Last Name";
        cells[5, HeaderCols++].Formula = "First Name";
        cells[5, HeaderCols++].Formula = "Company";
        cells[5, HeaderCols++].Formula = "Department";

        cells[5, HeaderCols++].Formula = "Address 1";
        cells[5, HeaderCols++].Formula = "City";
        cells[5, HeaderCols++].Formula = "State";
        cells[5, HeaderCols++].Formula = "Country";
        cells[5, HeaderCols++].Formula = "Zip";

        cells[5, HeaderCols++].Formula = "Ship To Country";
        cells[5, HeaderCols++].Formula = "Ship To State";

        cells[5, HeaderCols++].Formula = "Item ID";
        cells[5, HeaderCols++].Formula = "Qty Ordered";
        cells[5, HeaderCols++].Formula = "Page Count";
        cells[5, HeaderCols++].Formula = "Cost Center";
        cells[5, HeaderCols++].Formula = "Print Location ID";
        cells[5, HeaderCols++].Formula = "Fulfillment Location ID";

        cells[5, HeaderCols++].Formula = "Onf Cost"; // Current Onf Cost for item, dynamic and not historic
        cells[5, HeaderCols++].Formula = "Fulfillment Location Multiplier";
        cells[5, HeaderCols++].Formula = "Global Print Cost"; //Onf Cost from order line (should be the same as Base Cost * Multiplier), historical

        cells[5, 0, 5, HeaderCols].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        cells[5, 0, 5, HeaderCols].Font.Bold = true;

        rowindx = 6;
        foreach (GenericPODReportInfo cri in partreports)
        {
            colindx = 0;
            cells[rowindx, colindx++].Formula = cri.OrderId.ToString();
            cells[rowindx, colindx++].Formula = cri.DateOrdered.Value.ToString();

            if (cri.DateShipped.HasValue == false)
            {
                cells[rowindx, colindx++].Formula = "";
            }
            else
            {
                cells[rowindx, colindx++].Formula = cri.DateShipped.Value.ToString();
            }

            if (cri.UserType.ToLower().Contains("partner"))
            {
                cri.Department = "partner - NA";
            }

            cells[rowindx, colindx++].Formula = cri.UserType;

            if (mStoreId == 318)
            {
                cells[rowindx, colindx++].Formula = cri.CustomerOrderNumber;
            }

            cells[rowindx, colindx++].Formula = cri.LastName;
            cells[rowindx, colindx++].Formula = cri.FirstName;
            cells[rowindx, colindx++].Formula = cri.Address.Company;
            cells[rowindx, colindx++].Formula = cri.Department;

            cells[rowindx, colindx++].Formula = cri.Address.Address1;
            cells[rowindx, colindx++].Formula = cri.Address.City;
            cells[rowindx, colindx++].Formula = cri.Address.State;
            cells[rowindx, colindx++].Formula = cri.Address.Country;
            cells[rowindx, colindx++].Formula = cri.Address.Zip;

            cells[rowindx, colindx++].Formula = cri.ShipToCountry;
            cells[rowindx, colindx++].Formula = cri.ShipToState;

            cells[rowindx, colindx++].Formula = cri.ItemID;
            cells[rowindx, colindx++].Formula = cri.QtyOrdered.ToString();
            cells[rowindx, colindx++].Formula = cri.PageCount.ToString();
            cells[rowindx, colindx++].Formula = cri.CostCenter.ToString();
            cells[rowindx, colindx++].Formula = cri.PrintLocationId.ToString();
            cells[rowindx, colindx++].Formula = cri.FulfillmentLocationId.ToString();
            cells[rowindx, colindx++].Formula = cri.OnfCostBase.ToString();

            if (cri.OnfCostMultiplier.HasValue == false)
            {
                cells[rowindx, colindx++].Formula = "1";
            }
            else
            {
                cells[rowindx, colindx++].Formula = cri.OnfCostMultiplier.ToString();
            }

            if (cri.OnfCost.HasValue == false)
            {
                cells[rowindx, colindx++].Formula = cri.OnfCostBase.ToString();
            }
            else
            {
                cells[rowindx, colindx++].Formula = cri.OnfCost.ToString();
            }

           
            rowindx++;
        }

        rowindx++;

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

            htmlTable.Rows.AddRange(ReportFunctions.convertExcelToHTML(workbook, 19, rowindx));
        }
        else
        {
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=PODReport.xls");
            Response.BinaryWrite(data);
            Response.End();
        }
    }

    protected void DropDownListStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
        Session["StoreId"] = mStoreId.ToString();
        DropDownListDepartment.DataBind();
    }
    
}
