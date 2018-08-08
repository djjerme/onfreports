using System;
using System.Web;
using System.Web.UI.WebControls;
using PBA.OnfInfo;
using PBA.OnfDAL;

public partial class CreditCardReport : System.Web.UI.Page
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
        bool lHeader = false;

        CreditCardReportInfo[] infos = CreditCardReportData.GetCreditCardReport(CalendarFromDate.SelectedDate, CalendarToDate.SelectedDate);

        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        mCells = worksheet.Cells;

        string dates = string.Format("Ship Date Range: From {0} to {1}",
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
            int currentstore = 0;
            int rowindx = 0;
            const int firstrowindx = 2;
            const int paymentcol = 7;
            const int salestaxcol = 8;
            foreach (CreditCardReportInfo info in infos)
            {
                int colindx;
                if (info.StoreId != currentstore)
                {
                    if (currentstore != 0)
                    {
                        mCells[rowindx, 0].Formula = "Total:";
                        mCells[rowindx, paymentcol].FormulaR1C1 =
                            string.Format("=SUM(R[{0}]C:R[{1}]C)",
                            firstrowindx - rowindx+1,
                            -1);
                        mCells[rowindx, salestaxcol].FormulaR1C1 =
                            string.Format("=SUM(R[{0}]C:R[{1}]C)",
                            firstrowindx - rowindx+1,
                            -1);
                        mCells[rowindx, 0].Font.Bold = true;
                        mCells[rowindx, paymentcol, rowindx, salestaxcol].Font.Bold = true;
                        mCells[rowindx, paymentcol, rowindx, salestaxcol].NumberFormat = "$#,##0.00";

                        worksheet.Name = currentstore.ToString();
                        mCells.Columns["A:I"].EntireColumn.AutoFit();

                        worksheet = workbook.Worksheets.Add();
                        mCells = worksheet.Cells;
                    }
                    mCells[0, 0].Formula =
                        string.Format("Credit Card Report for {0}", info.StoreName);

                    mCells[1, 0].Formula = dates;
                    currentstore = (int)info.StoreId;
                    lHeader = false;
                    rowindx = firstrowindx;
                }

                if (lHeader == false)
                {
                    colindx = 0;
                    mCells[rowindx, colindx++].Formula = "Order #";
                    mCells[rowindx, colindx++].Formula = "Order Date";
                    mCells[rowindx, colindx++].Formula = "Ship Date";
                    mCells[rowindx, colindx++].Formula = "User Name";
                    mCells[rowindx, colindx++].Formula = "Company";
                    mCells[rowindx, colindx++].Formula = "Invoice #";
                    mCells[rowindx, colindx++].Formula = "Transaction Id";
                    mCells[rowindx, colindx++].Formula = "Payment Amount";
                    mCells[rowindx, colindx++].Formula = "Sales Tax";
                    mCells[rowindx, colindx++].Formula = "Discount Amount";
                    mCells[rowindx, 0, rowindx, colindx - 1].Font.Bold = true;

                    rowindx++;

                    lHeader = true;
                }

                colindx = 0;
                mCells[rowindx, colindx++].Formula = string.Format("{0}-{1}", info.OrderId, info.OrderSuffix);
                mCells[rowindx, colindx++].Formula = ((DateTime)info.OrderWhen).ToShortDateString();
                mCells[rowindx, colindx++].Formula = ((DateTime)info.ShipDate).ToShortDateString();
                mCells[rowindx, colindx++].Formula = info.FullName;
                mCells[rowindx, colindx++].Formula = info.Company ?? "";
                mCells[rowindx, colindx++].Formula = info.QuoteId == null ? "" : 
                    string.Format("{0}-{1}", info.StoreId, info.QuoteId);
                mCells[rowindx, colindx++].Formula = info.TransactionId ?? "";
                mCells[rowindx, colindx].NumberFormat = "$#,##0.00";
                mCells[rowindx, colindx++].Formula = info.PaymentAmount.ToString();
                mCells[rowindx, colindx].NumberFormat = "$#,##0.00";
                mCells[rowindx, colindx++].Formula = info.SalesTax.ToString();
                mCells[rowindx, colindx].Formula = info.Discount.ToString();

                rowindx++;
            }

            if (currentstore != 0)
            {
                mCells[rowindx, 0].Formula = "Total:";
                mCells[rowindx, paymentcol].FormulaR1C1 =
                    string.Format("=SUM(R[{0}]C:R[{1}]C)",
                    firstrowindx - rowindx+1,
                    -1);
                mCells[rowindx, salestaxcol].FormulaR1C1 =
                    string.Format("=SUM(R[{0}]C:R[{1}]C)",
                    firstrowindx - rowindx+1,
                    -1);
                mCells[rowindx, 0].Font.Bold = true;
                mCells[rowindx, paymentcol, rowindx, salestaxcol].Font.Bold = true;
                mCells[rowindx, paymentcol, rowindx, salestaxcol].NumberFormat = "$#,##0.00";
                worksheet.Name = currentstore.ToString();
                mCells.Columns["A:I"].EntireColumn.AutoFit();

                worksheet = workbook.Worksheets.Add();
                mCells = worksheet.Cells;
            }

        }
        // Stream the Excel spreadsheet to the client
        // Setting the Content-Disposition attachment causes the data
        // to be saved or opened in Excel instead of the browser
        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=CreditCardReport.xls");
        Response.BinaryWrite(data);
        Response.End();

    }
}
