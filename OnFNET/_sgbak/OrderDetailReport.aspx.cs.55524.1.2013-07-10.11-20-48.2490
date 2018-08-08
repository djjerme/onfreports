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

public partial class OrderDetailReport : System.Web.UI.Page
{
    public static string mUserId;
    private static int mStoreId;
    private static bool mWhseUser;
    private int mMaxrow = 65535;

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
        //HiddenFieldDate.Value = DropDownListDepartment.SelectedValue;
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
        int rowindx = 0;
        DateTime? earliest = ((DateTime?)null);
        DateTime? latest = ((DateTime?)null);
        string daterange;
        bool newpage = true;
        int pageno = 0;

        OrderDetailReportInfo[] orderdetails = PBA.OnfBLL.OrderDetailReport.GetOrderDetailReport(mStoreId,
                CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate,
                DropDownListItem.SelectedValue == "(All)" ? "" : DropDownListItem.SelectedValue,
                Convert.ToInt32(DropDownListDepartment.SelectedValue),
                Convert.ToInt32(DropDownListSubDepartment.SelectedValue),
                DropDownListUserType.SelectedValue == "(All)" ? "" : DropDownListUserType.SelectedValue,
                CheckBoxSnapshotSync.Checked, CheckBoxArchive.Checked);


        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        string filters = string.Format("Filters: Department = {0}, Subdepartment = {1}, Item = {2}, User type = {3}",
            DropDownListDepartment.SelectedItem.Text, DropDownListSubDepartment.SelectedItem.Text,
            DropDownListItem.SelectedItem.Text, DropDownListUserType.SelectedItem.Text);
        string dates = string.Format("Date Range: From {0} to {1}",
            CalendarFromDate.SelectedDate.ToShortDateString(),
            CalendarToDate.SelectedDate.ToShortDateString());

        foreach (OrderDetailReportInfo orderdetail in orderdetails)
        {
            if (newpage)
            {
                pageno++;

                if (pageno > 1)
                {
                    worksheet = workbook.Worksheets.Add();
                    cells = worksheet.Cells;
                }

                worksheet.Name = string.Format("Order Detail Report, page {0}", pageno);
                if (mWhseUser)
                {
                    cells[0, 0].Formula =
                        string.Format("Order Detail Report for {0}", DropDownListStore.SelectedItem.Text);
                }
                else
                {
                    cells[0, 0].Formula = "Order Detail Report";
                }
                cells[0, 0, 0, 12].Merge();
                cells[0, 0, 0, 12].Font.Bold = true;
                cells[0, 0, 0, 12].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

                cells[1, 0].Formula = filters;
                cells[1, 0, 1, 12].Merge();
                cells[1, 0, 1, 12].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                cells[2, 0].Formula = dates;
                cells[2, 0, 2, 12].Merge();
                cells[2, 0, 2, 12].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                // Load column titles and center.
                cells[5, 0].Formula = "Customer Order Number";
                cells[5, 1].Formula = "External Order Id";
                cells[5, 2].Formula = "Customer Name";
                cells[5, 3].Formula = "User Type";
                cells[5, 4].Formula = "Order Received";
                cells[5, 5].Formula = "Order Shipped";
                cells[5, 6].Formula = "SKU";
                cells[5, 7].Formula = "Product Name";
                cells[5, 8].Formula = "Quantity Shipped";
                cells[5, 9].Formula = "Quantity Ordered Before";
                cells[5, 10].Formula = "Quantity Not Shipped";

                cells[5, 0, 5, 10].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
                cells[5, 0, 5, 10].Font.Bold = true;

                rowindx = 6;
                newpage = false;
            }

            if (earliest == (DateTime?)null)
            {
                earliest = orderdetail.BegSnapshot;
            }
            else
            {
                if (orderdetail.BegSnapshot < earliest)
                {
                    earliest = orderdetail.BegSnapshot;
                }
            }

            if (latest == (DateTime?)null)
            {
                latest = orderdetail.EndSnapshot;
            }
            else
            {
                if (orderdetail.EndSnapshot > latest)
                {
                    latest = orderdetail.EndSnapshot;
                }
            }
            cells[rowindx, 0].Formula = 
                orderdetail.CustOrderNo == null ? "" : orderdetail.CustOrderNo;
            cells[rowindx, 1].Formula = 
                orderdetail.ExternalOrderId == null ? "" : orderdetail.ExternalOrderId;
            cells[rowindx, 2].Formula =
                orderdetail.FirstName == "" ? orderdetail.LastName :
                    orderdetail.FirstName + " " + orderdetail.LastName;
            cells[rowindx, 3].Formula = orderdetail.UserType;
            cells[rowindx, 4].Formula = ((DateTime)orderdetail.OrderWhen).ToString("MM/dd/yyyy hh:mm:ss");
            cells[rowindx, 5].Formula = 
                orderdetail.ShipDate != (DateTime?) null ? 
                ((DateTime)orderdetail.ShipDate).ToString("MM/dd/yyyy hh:mm:ss") :
                "";
            cells[rowindx, 6].Formula = orderdetail.ItemId;
            cells[rowindx, 7].Formula = orderdetail.ProductName;
            cells[rowindx, 8].Formula = orderdetail.QtyPicked.ToString();
            cells[rowindx, 9].Formula = orderdetail.QtyOrderedPrior.ToString();
            cells[rowindx, 10].Formula = orderdetail.QtyNotShipped.ToString();
            rowindx++;

            if (rowindx >= mMaxrow)
            {
                cells[5, 0, rowindx, 10].Columns.AutoFit();

                if (orderdetails.Length > 0)
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
                cells[3, 0, 3, 10].Merge();
                cells[3, 0, 3, 10].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

                newpage = true;
            }
        }

        cells[5, 0, (rowindx < 5 ? 5 : rowindx), 10].Columns.AutoFit();

        if (earliest == null)
        {
            earliest = CalendarFromDate.SelectedDate;
        }

        if (latest == null)
        {
            latest = CalendarToDate.SelectedDate;
        }

        if (orderdetails.Length > 0)
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
        cells[3, 0, 3, 10].Merge();
        cells[3, 0, 3, 10].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=OrderDetailReport.xls");
        Response.BinaryWrite(data);
        Response.End();

    }
}
