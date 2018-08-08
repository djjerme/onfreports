using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PBA.OnfBLL;
using PBA.OnfDAL;
using PBA.OnfInfo;

public partial class FreightReport : System.Web.UI.Page
{
    public static string mUserId;
    private static int mStoreId;
    private static bool mWhseUser;
    private const int cLineCol = 6;
    private const int cItemCol = 7;
    private const int cShippingCol = 8;
    private const int cPackageCol = 10;
    private SpreadsheetGear.IRange mCells;
    private int mTotalUnits, mSubtotalUnits;
    private int mTotalPackages, mSubtotalPackages;
    private int mTotalOrders, mSubtotalOrders;
    private int mTotalLines, mSubtotalLines;
    private double mTotalShipping, mSubtotalShipping;

    protected void Page_Load(object sender, EventArgs e)
    {
        mWhseUser = ((HttpContext.Current.Request.QueryString["W"] != null) && (HttpContext.Current.Request.QueryString["W"].ToString() == "4964"));

        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];

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

            Session["StoreId"] = mStoreId.ToString();

            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;
            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();

            DisplayDates();
            DisplayVisibleMonth(DateTime.Today);

            if (mStoreId > 0)
            {
                PopulateItemList();
            }
            else
            {
                ClearItemList();
            }
        }

        if (mWhseUser)
        {
            Control UserControl;
            UserControl = LoadControl("MenuBarNET2.ascx");

            PanelMenuBar.Controls.Add(UserControl);
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
    protected void CalendarFromDate_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        DisplayVisibleMonth(e.NewDate);
        HiddenFieldDate.Value = e.NewDate.ToShortDateString();
    }

    private void DisplayVisibleMonth(DateTime date)
    {
        LinkButtonSelectMonth.Text = "Select entire month of " + date.ToString("MMMM, yyyy");
    }

    private void DisplayDates()
    {
        LabelFromDate.Text = string.Format("From: {0}", CalendarFromDate.SelectedDate.ToShortDateString());
        LabelToDate.Text = string.Format("To: {0}", CalendarToDate.SelectedDate.ToShortDateString());
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
    protected void DropDownListStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
        Session["StoreId"] = mStoreId.ToString();

        if (mStoreId > 0)
        {
            PopulateItemList();
        }
        else
        {
            ClearItemList();
        }
    }

    private void PopulateItemList()
    {
        ListBoxAvailableItems.Items.Clear();
        ListBoxSelectedItems.Items.Clear();

        ItemInfo[] items = ItemData.GetItem(mStoreId);
        ArrayList itemarray = new ArrayList();
        foreach (ItemInfo item in items)
        {
            itemarray.Add(item.ItemId);
        }

        itemarray.Sort();
        ListBoxAvailableItems.DataSource = itemarray;
        ListBoxAvailableItems.DataBind();

        ListBoxAvailableItems.Enabled = ListBoxSelectedItems.Enabled =
            ButtonAddAll.Enabled = ButtonAddSelected.Enabled =
            ButtonRemoveAll.Enabled = ButtonRemoveSelected.Enabled = true;
    }

    private void ClearItemList()
    {
        ListBoxAvailableItems.Items.Clear();
        ListBoxSelectedItems.Items.Clear();

        ListBoxAvailableItems.Enabled = ListBoxSelectedItems.Enabled =
            ButtonAddAll.Enabled = ButtonAddSelected.Enabled =
            ButtonRemoveAll.Enabled = ButtonRemoveSelected.Enabled = false;
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
        bool lHeader;
        int colindx;
        int currentstore = 0;
        FreightReportInfo[] infos;
        int maxcol = 0;
        string currentbreak = "";
        DateTime currentshipdate;

        currentshipdate = DateTime.Parse("01/01/1900");

        if (mStoreId == 0)
        {
            infos = FreightReportData.GetFreightReport(mUserId,
                CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate, 
                DropDownListSubtotalBy.SelectedValue == "none" ? "" : DropDownListSubtotalBy.SelectedValue);
        }
        else
        {
            if (ListBoxSelectedItems.Items.Count == 0)
            {
                infos = FreightReportData.GetFreightReport(mStoreId,
                    CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate,
                    DropDownListSubtotalBy.SelectedValue == "none" ? "" : DropDownListSubtotalBy.SelectedValue);
            }
            else
            {
                ArrayList itemlist = new ArrayList();
                foreach (ListItem item in ListBoxSelectedItems.Items)
                {
                    itemlist.Add(item.Text);
                }

                infos = FreightReportData.GetFreightReport(mStoreId,
                    CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate,
                    DropDownListSubtotalBy.SelectedValue == "none" ? "" : DropDownListSubtotalBy.SelectedValue, itemlist);
            }
        }
        
        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        mCells = worksheet.Cells;

        string dates = string.Format("Date Range: From {0} to {1}",
           CalendarFromDate.SelectedDate.ToShortDateString(),
           CalendarToDate.SelectedDate.ToShortDateString());

        StringBuilder sb = new StringBuilder();
        if (ListBoxSelectedItems.Items.Count > 0)
        {
            foreach (ListItem item in ListBoxSelectedItems.Items)
            {
                if (sb.Length == 0)
                {
                    sb.Append("For orders with the following items: ");
                    sb.Append(item.Text);
                }
                else
                {
                    sb.Append(", ");
                    sb.Append(item.Text);
                }
            }
        }
        if (infos.Length == 0)
        {
            mCells[0, 0].Font.Bold = true;
            mCells[2, 0].Formula = "No data found for this date range for store " + mStoreId.ToString();
            mCells[2, 0].HorizontalAlignment = SpreadsheetGear.HAlign.Left;
        }
        else
        {
            lHeader = false;

            foreach (FreightReportInfo info in infos)
            {
                if (info.StoreId != currentstore)
                {
                    if (currentstore != 0)
                    {
                        // Subtotal out
                        switch (DropDownListSubtotalBy.SelectedValue)
                        {
                            case "ship_date":
                                // Subtotal
                                rowindx++;
                                Subtotal(currentshipdate.ToShortDateString(), rowindx);
                                rowindx++;
                                rowindx++;
                                Total(rowindx);
                                rowindx++;
                                rowindx++;
                                currentshipdate = DateTime.Parse("01/01/1900");
                                break;
                            case "carrier_code":
                                // Subtotal
                                rowindx++;
                                Subtotal(currentbreak, rowindx);
                                rowindx++;
                                rowindx++;
                                Total(rowindx);
                                rowindx++;
                                rowindx++;
                                currentbreak = "";
                                break;
                            case "user_type":
                                // Subtotal
                                rowindx++;
                                Subtotal(currentbreak, rowindx);
                                rowindx++;
                                rowindx++;
                                Total(rowindx);
                                rowindx++;
                                rowindx++;
                                currentbreak = "";
                                break;
                            default:
                                break;
                        }




                        worksheet.Name = currentstore.ToString();
                        mCells.Columns["A:R"].EntireColumn.AutoFit();
                        mCells[3, cShippingCol, rowindx, cShippingCol].NumberFormat = "$#,##0.00";

                        worksheet = workbook.Worksheets.Add();
                        mCells = worksheet.Cells;
                    }
                    mCells[0, 0].Formula =
                        string.Format("Freight Report for {0}", info.StoreName);

                    mCells[1, 0].Formula = dates;
                    currentstore = (int) info.StoreId;
                    lHeader = false;
                    rowindx = 2;

                    if (sb.Length > 0)
                    {
                        mCells[2, 0].Formula = sb.ToString();
                        rowindx = 3;
                    }

                    mTotalUnits = mSubtotalUnits = 0;
                    mTotalShipping = mSubtotalShipping = 0;
                    mTotalPackages = mSubtotalPackages = 0;
                    mTotalOrders = mSubtotalOrders = 0;
                    mTotalLines = mSubtotalLines = 0;
                }

                if (lHeader == false)
                {
                    colindx = 0;
                    mCells[rowindx, colindx++].Formula = "Order Id";
                    mCells[rowindx, colindx++].Formula = "Order When";
                    mCells[rowindx, colindx++].Formula = "Ship Date";
                    mCells[rowindx, colindx++].Formula = "Payment Method";
                    mCells[rowindx, colindx++].Formula = "Transaction Id";
                    mCells[rowindx, colindx++].Formula = "Ship To";
                    mCells[rowindx, colindx++].Formula = "Order Line Count";
                    mCells[rowindx, colindx++].Formula = "Item Count";
                    mCells[rowindx, colindx++].Formula = "Shipping Charge";
                    mCells[rowindx, colindx++].Formula = "Carrier Code";
                    mCells[rowindx, colindx++].Formula = "Number of Packages";
                    mCells[rowindx, colindx++].Formula = "Third Party Shipper Flag";
                    mCells[rowindx, colindx++].Formula = "Order Reason";
                    mCells[rowindx, colindx++].Formula = "User Type";
                    mCells[rowindx, colindx++].Formula = "User Name";
                    mCells[rowindx, colindx++].Formula = "Product Group";
                    mCells[rowindx, colindx++].Formula = "Tracking Number";
                    mCells[rowindx, colindx++].Formula = "Country";
                    mCells[rowindx, colindx++].Formula = "Manual Update";
                    maxcol = colindx - 1;
                    mCells[rowindx, 0, rowindx, maxcol].Font.Bold = true;

                    rowindx++;

                    lHeader = true;
                }

                switch (DropDownListSubtotalBy.SelectedValue)
                {
                    case "ship_date":
                        if ((currentshipdate != info.ShipDate) && (currentshipdate != DateTime.Parse("01/01/1900")))
                        {
                            // Subtotal
                            rowindx++;
                            Subtotal(currentshipdate.ToShortDateString(), rowindx);
                            rowindx++;
                            rowindx++;
                        }
                        currentshipdate = (DateTime) info.ShipDate;
                        break;
                    case "carrier_code":
                        if ((currentbreak != info.CarrierCode) && (currentbreak != ""))
                        {
                            // Subtotal
                            rowindx++;
                            Subtotal(currentbreak, rowindx);
                            rowindx++;
                            rowindx++;
                        }
                        currentbreak = info.CarrierCode;
                        break;
                    case "user_type":
                        if ((currentbreak != info.UserType) && (currentbreak != ""))
                        {
                            // Subtotal
                            rowindx++;
                            Subtotal(currentbreak, rowindx);
                            rowindx++;
                            rowindx++;
                        }
                        currentbreak = info.UserType;
                        break;
                    default:
                        break;
                }

                colindx = 0;
                mCells[rowindx, colindx++].Formula = string.Format("{0}-{1}", info.OrderId, info.OrderSuffix);
                mCells[rowindx, colindx++].Formula = ((DateTime) info.OrderWhen).ToShortDateString();
                mCells[rowindx, colindx++].Formula = ((DateTime) info.ShipDate).ToShortDateString();
                mCells[rowindx, colindx++].Formula = info.PaymentMethod == null ? "" : info.PaymentMethod;
                mCells[rowindx, colindx++].Formula = info.TransactionId == null ? "" : info.TransactionId;
                mCells[rowindx, colindx++].Formula = (info.ShipFirstName == null ? "" : info.ShipFirstName + " ")
                                                     +
                                                     (info.ShipLastName == null ? "" : info.ShipLastName);
                mCells[rowindx, colindx++].Formula = info.LineCount.ToString();
                mCells[rowindx, colindx++].Formula = info.UnitCount.ToString();
                mCells[rowindx, colindx++].Formula = info.PublishedRate.ToString();
                mCells[rowindx, colindx++].Formula = info.CarrierCode;
                mCells[rowindx, colindx++].Formula = info.NumberOfPackages.ToString();
                mCells[rowindx, colindx++].Formula =
                    (info.ThirdPartyShipperFlag == (bool?) null)
                        ? "no"
                        : (((bool) info.ThirdPartyShipperFlag) ? "yes" : "no");
                mCells[rowindx, colindx++].Formula = info.OrderReason == null ? "" : info.OrderReason;
                mCells[rowindx, colindx++].Formula = info.UserType == null ? "" : info.UserType;
                mCells[rowindx, colindx++].Formula = (info.FirstName == null ? "" : info.FirstName + " ")
                                                     +
                                                     (info.LastName == null ? "" : info.LastName);
                mCells[rowindx, colindx++].Formula = info.ProductFamily == null ? "" : info.ProductFamily;
                mCells[rowindx, colindx++].Formula = info.TrackingNo == null ? "" : "'" + info.TrackingNo;
                mCells[rowindx, colindx++].Formula = info.Country == null ? "" : info.Country;
                mCells[rowindx, colindx++].Formula = (info.BatchUpdate == null || (bool) info.BatchUpdate == false)
                                                         ? "yes"
                                                         : "";

                // accumulate
                mTotalOrders++;
                mSubtotalOrders++;
                mTotalLines += (info.LineCount == (int?) null ? 0 : (int) info.LineCount);
                mSubtotalLines += (info.LineCount == (int?) null ? 0 : (int) info.LineCount);
                mTotalPackages += (info.NumberOfPackages == (int?) null ? 0 : (int) info.NumberOfPackages);
                mSubtotalPackages += (info.NumberOfPackages == (int?) null ? 0 : (int) info.NumberOfPackages);
                mTotalUnits += (info.UnitCount == (int?) null ? 0 : (int) info.UnitCount);
                mSubtotalUnits += (info.UnitCount == (int?) null ? 0 : (int) info.UnitCount);
                mTotalShipping += (info.ActualShipping == (double?) null ? 0 : (double) info.ActualShipping);
                mSubtotalShipping += (info.ActualShipping == (double?) null ? 0 : (double) info.ActualShipping);


                rowindx++;
            }

            // Subtotal out
            switch (DropDownListSubtotalBy.SelectedValue)
            {
                case "ship_date":
                    // Subtotal
                    rowindx++;
                    Subtotal(currentshipdate.ToShortDateString(), rowindx);
                    rowindx++;
                    rowindx++;
                    Total(rowindx);
                    rowindx++;
                    rowindx++;
                    break;
                case "carrier_code":
                    // Subtotal
                    rowindx++;
                    Subtotal(currentbreak, rowindx);
                    rowindx++;
                    rowindx++;
                    Total(rowindx);
                    rowindx++;
                    rowindx++;
                    break;
                case "user_type":
                    // Subtotal
                    rowindx++;
                    Subtotal(currentbreak, rowindx);
                    rowindx++;
                    rowindx++;
                    Total(rowindx);
                    rowindx++;
                    rowindx++;
                    break;
                default:
                    break;
            }
            worksheet.Name = currentstore.ToString();
            mCells.Columns["A:S"].EntireColumn.AutoFit();
            mCells[3, cShippingCol, rowindx, cShippingCol].NumberFormat = "$#,##0.00";

        }

        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        if (mStoreId != 0)
        {
            Response.AddHeader("Content-Disposition",
                string.Format("attachment; filename=FreightReport_{0}.xls", mStoreId));
        }
        else
        {
            Response.AddHeader("Content-Disposition", "attachment; filename=FreightReport.xls");
        }
        Response.BinaryWrite(data);
        Response.End();
    }

    private void Subtotal(string breakfield, int rowindx)
    {
        
        mCells[rowindx,0].Formula = string.Format("Totals for {0} {1} for {2}:",
            mSubtotalOrders.ToString(), 
            (mSubtotalOrders == 1 ? "order" : "orders"),
            breakfield);
        mCells[rowindx,cLineCol].Formula = mSubtotalLines.ToString();
        mCells[rowindx,cItemCol].Formula = mSubtotalUnits.ToString();
        mCells[rowindx,cShippingCol].Formula = mSubtotalShipping.ToString();
        mCells[rowindx,cPackageCol].Formula = mSubtotalPackages.ToString();
        mSubtotalUnits = 0;
        mSubtotalShipping = 0;
        mSubtotalPackages = 0;
        mSubtotalOrders = 0;
        mSubtotalLines = 0;
    }

    private void Total(int rowindx)
    {
        mCells[rowindx, 0].Formula = string.Format("Totals for {0} {1}:",
            mTotalOrders.ToString(),
            (mTotalOrders == 1 ? "order" : "orders"));
        mCells[rowindx, cLineCol].Formula = mTotalLines.ToString();
        mCells[rowindx, cItemCol].Formula = mTotalUnits.ToString();
        mCells[rowindx, cShippingCol].Formula = mTotalShipping.ToString();
        mCells[rowindx, cPackageCol].Formula = mTotalPackages.ToString();
        mTotalUnits = 0;
        mTotalShipping = 0;
        mTotalPackages = 0;
        mTotalOrders = 0;
        mTotalLines = 0;
    }
    protected void ButtonAddAll_Click(object sender, EventArgs e)
    {
        ArrayList itemarray = new ArrayList();

        foreach (ListItem item in ListBoxSelectedItems.Items)
        {
            itemarray.Add(item.Text);
        }

        foreach (ListItem item in ListBoxAvailableItems.Items)
        {
            itemarray.Add(item.Text);
        }

        itemarray.Sort();
        ListBoxAvailableItems.Items.Clear();
        ListBoxSelectedItems.DataSource = itemarray;
        ListBoxSelectedItems.DataBind();
    }
    protected void ButtonAddSelected_Click(object sender, EventArgs e)
    {
        ArrayList itemarray1 = new ArrayList();
        ArrayList itemarray2 = new ArrayList();

        foreach (ListItem item in ListBoxSelectedItems.Items)
        {
            itemarray2.Add(item.Text);
        }

        foreach (ListItem item in ListBoxAvailableItems.Items)
        {
            if (item.Selected)
            {
                itemarray2.Add(item.Text);
            }
            else
            {
                itemarray1.Add(item.Text);
            }
        }

        itemarray1.Sort();
        itemarray2.Sort();
        ListBoxAvailableItems.Items.Clear();
        ListBoxSelectedItems.Items.Clear();

        ListBoxAvailableItems.DataSource = itemarray1;
        ListBoxSelectedItems.DataSource = itemarray2;

        ListBoxAvailableItems.DataBind();
        ListBoxSelectedItems.DataBind();

    }
    protected void ButtonRemoveSelected_Click(object sender, EventArgs e)
    {
        ArrayList itemarray1 = new ArrayList();
        ArrayList itemarray2 = new ArrayList();

        foreach (ListItem item in ListBoxAvailableItems.Items)
        {
            itemarray2.Add(item.Text);
        }

        foreach (ListItem item in ListBoxSelectedItems.Items)
        {
            if (item.Selected)
            {
                itemarray2.Add(item.Text);
            }
            else
            {
                itemarray1.Add(item.Text);
            }
        }

        itemarray1.Sort();
        itemarray2.Sort();
        ListBoxAvailableItems.Items.Clear();
        ListBoxSelectedItems.Items.Clear();

        ListBoxSelectedItems.DataSource = itemarray1;
        ListBoxAvailableItems.DataSource = itemarray2;

        ListBoxAvailableItems.DataBind();
        ListBoxSelectedItems.DataBind();

    }
    protected void ButtonRemoveAll_Click(object sender, EventArgs e)
    {
        ArrayList itemarray = new ArrayList();

        foreach (ListItem item in ListBoxAvailableItems.Items)
        {
            itemarray.Add(item.Text);
        }

        foreach (ListItem item in ListBoxSelectedItems.Items)
        {
            itemarray.Add(item.Text);
        }

        itemarray.Sort();
        ListBoxSelectedItems.Items.Clear();
        ListBoxAvailableItems.DataSource = itemarray;
        ListBoxAvailableItems.DataBind();

    }
}
