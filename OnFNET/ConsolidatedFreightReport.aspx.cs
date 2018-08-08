using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PBA.OnfBLL;
using PBA.OnfDAL;
using PBA.OnfInfo;
using PBA.OnfList;

public partial class ConsolidatedFreightReport : System.Web.UI.Page
{
    private string mUserId;
    private SpreadsheetGear.IRange mCells;
    private int mTotalUnits, mSubtotalUnits;
    private int mTotalPackages, mSubtotalPackages;
    private int mTotalOrders, mSubtotalOrders;
    private int mTotalLines, mSubtotalLines;
    private double mTotalShipping, mSubtotalShipping;
    private double mInternationalFreightMultiplier = 
        Convert.ToDouble(ConfigurationManager.AppSettings["InternationalFreightMultiplier"]);
    private double mDomesticFreightMultiplier =
        Convert.ToDouble(ConfigurationManager.AppSettings["DomesticFreightMultiplier"]);
    private List<CarrierInfo> mCarriers;
    private CollectionView mCarrierList;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mUserId = HttpContext.Current.Request.QueryString["u"];

            if ((mUserId == null) || (mUserId == ""))
            {
                Response.Redirect("unauthorized.htm");
            }
            Session["UserId"] = mUserId;

            CalendarFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            CalendarToDate.SelectedDate = CalendarFromDate.SelectedDate;
            HiddenFieldDate.Value = DateTime.Today.ToShortDateString();

            LoadCarriers();

            DisplayDates();
            DisplayVisibleMonth(DateTime.Today);

        }

    }

    private void LoadCarriers()
    {
        DropDownListCarrier.DataSourceID = null;

        mCarriers = CarrierList.GetCarrierList();
        mCarrierList = new CollectionView(mCarriers);

        DropDownListCarrier.DataSource = mCarrierList;
        DropDownListCarrier.DataBind();
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
    private void DisplayDates()
    {
        LabelFromDate.Text = string.Format("From: {0}", CalendarFromDate.SelectedDate.ToShortDateString());
        LabelToDate.Text = string.Format("To: {0}", CalendarToDate.SelectedDate.ToShortDateString());
    }
    private void DisplayVisibleMonth(DateTime date)
    {
        LinkButtonSelectMonth.Text = "Select entire month of " + date.ToString("MMMM, yyyy");
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
        FreightReportInfo[] infos;
        string billto;
        int publishedratecol, invoiceamtcol;
        int rowindx, colindx, maxcol;
        int discountcol = 0;

        infos = FreightReportData.GetFreightReport(CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate, Convert.ToInt32(DropDownListCarrier.SelectedValue), "");

        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
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
            mTotalUnits = mSubtotalUnits = 0;
            mTotalShipping = mSubtotalShipping = 0;
            mTotalPackages = mSubtotalPackages = 0;
            mTotalOrders = mSubtotalOrders = 0;
            mTotalLines = mSubtotalLines = 0;
            
            rowindx = 2;
            colindx = 0;
            mCells[rowindx, colindx++].Formula = "Tracking Number";
            mCells[rowindx, colindx++].Formula = "Bill To";
            mCells[rowindx, colindx++].Formula = "Bill to Account #";
            publishedratecol = colindx;
            mCells[rowindx, colindx++].Formula = "Published Rate";
            invoiceamtcol = colindx;
            mCells[rowindx, colindx++].Formula = "Invoice Amount";
            discountcol = colindx;
            mCells[rowindx, colindx++].Formula = "Discount";
            mCells[rowindx, colindx++].Formula = "Reference";
            mCells[rowindx, colindx++].Formula = "Ship Date";
            mCells[rowindx, colindx++].Formula = "Carrier Code";
            mCells[rowindx, colindx++].Formula = "Actual Ship Method";
            mCells[rowindx, colindx++].Formula = "Number of Packages";
            mCells[rowindx, colindx++].Formula = "Ship To";
            mCells[rowindx, colindx++].Formula = "Address Line 1";
            mCells[rowindx, colindx++].Formula = "Address Line 2";
            mCells[rowindx, colindx++].Formula = "Address Line 3";
            mCells[rowindx, colindx++].Formula = "City";
            mCells[rowindx, colindx++].Formula = "State";
            mCells[rowindx, colindx++].Formula = "Zip";
            mCells[rowindx, colindx++].Formula = "Country";

            maxcol = colindx - 1;
            mCells[rowindx, 0, rowindx, maxcol].Font.Bold = true;

            rowindx++;

            foreach (FreightReportInfo info in infos)
            {
                colindx = 0;
                mCells[rowindx, colindx++].Formula = info.TrackingNo == null ? "" : "'" + info.TrackingNo;

                if (info.ThirdPartyShipperFlag == false)
                {
                    if (info.ActualShipMethod.ToUpper().IndexOf("COLLECT") >= 0)
                    {
                        billto = "Collect";
                    }
                    else
                    {
                        billto = "Sender";
                    }
                }
                else
                {
                    billto = "Third Party";
                }
                mCells[rowindx, colindx++].Formula = billto;
                mCells[rowindx, colindx++].Formula = info.ThirdPartyShipperInfo == null ? "" : "'" + info.ThirdPartyShipperInfo;

                if (billto == "Sender")
                {
                    mCells[rowindx, colindx++].Formula = info.PublishedRate.ToString();
                }
                else
                {
                    mCells[rowindx, colindx++].Formula = "0";
                }

                mCells[rowindx, colindx++].Formula = info.InternalShippingCost.ToString();
                if (billto == "Sender")
                {
                    mCells[rowindx, colindx++].Formula =
                        ((bool)info.International ?
                        (info.InternationalDiscount == null ? "" : ((double)(info.InternationalDiscount / 100.0)).ToString()) :
                        (info.DomesticDiscount == null ? "" : ((double)(info.DomesticDiscount / 100.0)).ToString()));
                }
                else
                {
                    mCells[rowindx, colindx++].Formula = "";

                }
                mCells[rowindx, colindx++].Formula = string.Format("{0}/{1}-{2}-{3}",
                    info.StoreName, info.StoreId, info.OrderId, info.OrderSuffix);

                mCells[rowindx, colindx++].Formula = ((DateTime)info.ShipDate).ToShortDateString();
                mCells[rowindx, colindx++].Formula = info.CarrierCode;
                mCells[rowindx, colindx++].Formula = info.ActualShipMethod;
                mCells[rowindx, colindx++].Formula = info.NumberOfPackages.ToString();
                mCells[rowindx, colindx++].Formula = (info.ShipFirstName == null ? "" : info.ShipFirstName + " ")
                    +
                    (info.ShipLastName == null ? "" : info.ShipLastName);
                mCells[rowindx, colindx++].Formula = info.Address1 == null ? "" : info.Address1;
                mCells[rowindx, colindx++].Formula = info.Address2 == null ? "" : info.Address2;
                mCells[rowindx, colindx++].Formula = info.Address3 == null ? "" : info.Address3;
                mCells[rowindx, colindx++].Formula = info.City == null ? "" : info.City;
                mCells[rowindx, colindx++].Formula = info.State == null ? "" : info.State;
                mCells[rowindx, colindx++].Formula = info.Zip == null ? "" : info.Zip;
                mCells[rowindx, colindx++].Formula = info.Country == null ? "" : info.Country;

                rowindx++;

            }
            mCells.Cells[0, 0, 0, maxcol].Columns.EntireColumn.AutoFit();
            mCells[3, publishedratecol, rowindx, publishedratecol].NumberFormat = "$#,##0.00";
            mCells[3, invoiceamtcol, rowindx, invoiceamtcol].NumberFormat = "$#,##0.00";
            mCells[3, discountcol, rowindx, discountcol].NumberFormat = "0.00%";
            mCells[0, 0, 0, maxcol].Merge();
            mCells[0, 0, 0, maxcol].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            mCells[0, 0, 0, maxcol].Font.Bold = true;


        }
        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=FreightReport.xls");
        Response.BinaryWrite(data);
        Response.End();

    }
    protected void DropDownListCarrier_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
