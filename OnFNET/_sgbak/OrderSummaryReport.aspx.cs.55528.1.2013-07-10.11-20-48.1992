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


public partial class OrderSummaryReport : System.Web.UI.Page
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

            DropDownListDepartment.DataBind();

            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();
            DropDownListSubDepartment.DataBind();

            DropDownListItem.DataBind();

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
    }

    protected void DropDownListStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
        Session["StoreId"] = mStoreId.ToString();
        DropDownListDepartment.DataBind();
        HiddenFieldDate.Value = DropDownListDepartment.SelectedValue;
        DropDownListSubDepartment.DataBind();
        DropDownListItem.DataBind();
    }
    protected void DropDownListDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenFieldDate.Value = DropDownListDepartment.SelectedValue;
        DropDownListSubDepartment.DataBind();
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
    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        int rowindx;
        DateTime? earliest = ((DateTime?)null);
        DateTime? latest = ((DateTime?)null);
        string daterange;

        OrderSummaryReportInfo[] ordersums = PBA.OnfBLL.OrderSummaryReport.GetOrderSummaryReport(mStoreId,
                CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate, 
                DropDownListItem.SelectedValue == "(All)" ? "" : DropDownListItem.SelectedValue,
                Convert.ToInt32(DropDownListDepartment.SelectedValue),
                Convert.ToInt32(DropDownListSubDepartment.SelectedValue),
                DropDownListUserType.SelectedValue == "(All)" ? "" : DropDownListUserType.SelectedValue,
                DropDownListGrouping.SelectedValue,
                CheckBoxSnapshotSync.Checked,
                CheckBoxArchive.Checked);


        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Order Summary Report";

        string filters = string.Format("Filters: Department = {0}, Subdepartment = {1}, Item = {2}, User type = {3}",
            DropDownListDepartment.SelectedItem.Text, DropDownListSubDepartment.SelectedItem.Text,
            DropDownListItem.SelectedItem.Text, DropDownListUserType.SelectedItem.Text);
        string dates = string.Format("Date Range: From {0} to {1}",
            CalendarFromDate.SelectedDate.ToShortDateString(), 
            CalendarToDate.SelectedDate.ToShortDateString());

        switch (DropDownListGrouping.SelectedValue)
        {
            case "By Item":
                if (mWhseUser)
                {
                    cells[0, 0].Formula =
                        string.Format("Order Summary Report for {0} - By Item", DropDownListStore.SelectedItem.Text);
                }
                else
                {
                    cells[0, 0].Formula = "Order Summary Report - By Item";
                }
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
                cells[5, 0].Formula = "Item";
                cells[5, 1].Formula = "Product Name";
                cells[5, 2].Formula = "Department";
                cells[5, 3].Formula = "Sub-Department";
                cells[5, 4].Formula = "User Type";
                cells[5, 5].Formula = "Quantity Ordered";
                cells[5, 6].Formula = "Quantity Shipped";
                cells[5, 7].Formula = "Quantity Ordered Before";
                cells[5, 8].Formula = "Quantity not Shipped";

                cells[5, 0, 5, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                cells[5, 0, 5, 8].Font.Bold = true;

                rowindx = 6;
                foreach (OrderSummaryReportInfo ordersum in ordersums)
                {
                    if (earliest == (DateTime?)null)
                    {
                        earliest = ordersum.BegSnapshot;
                    }
                    else
                    {
                        if (ordersum.BegSnapshot < earliest)
                        {
                            earliest = ordersum.BegSnapshot;
                        }
                    }

                    if (latest == (DateTime?)null)
                    {
                        latest = ordersum.EndSnapshot;
                    }
                    else
                    {
                        if (ordersum.EndSnapshot > latest)
                        {
                            latest = ordersum.EndSnapshot;
                        }
                    }
                    cells[rowindx, 0].Formula = ordersum.ItemId;
                    cells[rowindx, 1].Formula = ordersum.ProductName;
                    cells[rowindx, 2].Formula = ordersum.DeptName;
                    cells[rowindx, 3].Formula = ordersum.SubDeptName;
                    cells[rowindx, 4].Formula = ordersum.UserType;
                    cells[rowindx, 5].Formula = ordersum.QtyOrdered.ToString();
                    cells[rowindx, 6].Formula = (-1 * ordersum.PickQty).ToString();
                    cells[rowindx, 7].Formula = ordersum.QtyOrderedBefore.ToString();
                    cells[rowindx, 8].Formula = ordersum.QtyNotPickedDuring.ToString();
                    rowindx++;
                }

                if (earliest == null)
                {
                    earliest = CalendarFromDate.SelectedDate;
                }

                if (latest == null)
                {
                    latest = CalendarToDate.SelectedDate;
                }

                cells[5, 0, rowindx, 8].Columns.AutoFit();

                if (ordersums.Length > 0)
                {
                    daterange = string.Format("Includes activity between {0} {1} and {2} {3}",
                        ((DateTime)earliest).ToShortDateString(),
                        ((DateTime)earliest).ToShortTimeString(),
                        ((DateTime)latest).ToShortDateString(),
                        ((DateTime)latest).ToShortTimeString());
                    cells[3, 0].Formula = daterange;
                }
                else
                {
                    cells[3, 0].Formula = "No data found for specified date range.";
                }
                cells[3, 0, 3, 8].Merge();
                cells[3, 0, 3, 8].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                break;
            case "By Date":
                if (mWhseUser)
                {
                    cells[0, 0].Formula =
                        string.Format("Order Summary Report for {0} - By Date", DropDownListStore.SelectedItem.Text);
                }
                else
                {
                    cells[0, 0].Formula = "Order Summary Report - By Date";
                }
                cells[0, 0, 0, 9].Merge();
                cells[0, 0, 0, 9].Font.Bold = true;
                cells[0, 0, 0, 9].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

                cells[1, 0].Formula = filters;
                cells[1, 0, 1, 9].Merge();
                cells[1, 0, 1, 9].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                cells[2, 0].Formula = dates;
                cells[2, 0, 2, 9].Merge();
                cells[2, 0, 2, 9].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                // Load column titles and center.
                cells[5, 0].Formula = "Pick Date";
                cells[5, 1].Formula = "Item";
                cells[5, 2].Formula = "Product Name";
                cells[5, 3].Formula = "Department";
                cells[5, 4].Formula = "Sub-Department";
                cells[5, 5].Formula = "User Type";
                cells[5, 6].Formula = "Quantity Ordered";
                cells[5, 7].Formula = "Quantity Shipped";
                cells[5, 8].Formula = "Quantity Ordered Before";
                cells[5, 9].Formula = "Quantity not Shipped";

                cells[5, 0, 5, 9].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                cells[5, 0, 5, 9].Font.Bold = true;

                rowindx = 6;
                DateTime? curdate = null;
                System.Drawing.Color cellcolor = Color.White;

                foreach (OrderSummaryReportInfo ordersum in ordersums)
                {
                    if (earliest == (DateTime?)null)
                    {
                        earliest = ordersum.BegSnapshot;
                    }
                    else
                    {
                        if (ordersum.BegSnapshot < earliest)
                        {
                            earliest = ordersum.BegSnapshot;
                        }
                    }

                    if (latest == (DateTime?)null)
                    {
                        latest = ordersum.EndSnapshot;
                    }
                    else
                    {
                        if (ordersum.EndSnapshot > latest)
                        {
                            latest = ordersum.EndSnapshot;
                        }
                    }
                    if ((curdate == null) || (curdate != ordersum.TransDate))
                    {
                        cells[rowindx, 0].Formula = ((DateTime)ordersum.TransDate).ToString("MM/dd/yyyy");
                        cellcolor = (cellcolor == Color.White) ? Color.Silver : Color.White;
                        curdate = ordersum.TransDate;
                    }
                    else
                    {
                        cells[rowindx, 0].Formula = "";
                    }
                    cells[rowindx, 1].Formula = ordersum.ItemId;
                    cells[rowindx, 2].Formula = ordersum.ProductName;
                    cells[rowindx, 3].Formula = ordersum.DeptName;
                    cells[rowindx, 4].Formula = ordersum.SubDeptName;
                    cells[rowindx, 5].Formula = ordersum.UserType;
                    cells[rowindx, 6].Formula = ordersum.QtyOrdered.ToString();
                    cells[rowindx, 7].Formula = (-1 * ordersum.PickQty).ToString();
                    cells[rowindx, 8].Formula = ordersum.QtyOrderedBefore.ToString();
                    cells[rowindx, 9].Formula = ordersum.QtyNotPickedDuring.ToString();
                    cells[rowindx, 0, rowindx, 9].Interior.Color = cellcolor;
                    cells[rowindx, 0, rowindx, 9].Borders.Color = Color.Gray;
                    rowindx++;
                }

                cells[2, 0, rowindx, 9].Columns.AutoFit();

                if (earliest == null)
                {
                    earliest = CalendarFromDate.SelectedDate;
                }

                if (latest == null)
                {
                    latest = CalendarToDate.SelectedDate;
                }

                if (ordersums.Length > 0)
                {
                    daterange = string.Format("Includes activity between {0} {1} and {2} {3}",
                        ((DateTime)earliest).ToShortDateString(),
                        ((DateTime)earliest).ToShortTimeString(),
                        ((DateTime)latest).ToShortDateString(),
                        ((DateTime)latest).ToShortTimeString());
                    cells[3, 0].Formula = daterange;
                }
                else
                {
                    cells[3, 0].Formula = "No data found for specified date range.";
                }
                cells[3, 0, 3, 9].Merge();
                cells[3, 0, 3, 9].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                break;
            default:
                break;
        }
        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=OrderSummaryReport.xls");
        Response.BinaryWrite(data);
        Response.End();

    }
}
