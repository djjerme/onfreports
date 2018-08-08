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
using PBA.OnfInfo;
using PBA.OnfDAL;
using PBA.OnfBLL;

public partial class SynderoReconciliationReport : System.Web.UI.Page
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

            RadDateTimePickerFromDate.SelectedDate = DateTime.Today.AddDays(-1);
            RadDateTimePickerToDate.SelectedDate = DateTime.Today;
            DisplayDates();
        }
        if (mWhseUser)
        {
            Control UserControl;
            UserControl = LoadControl("MenuBarNET2.ascx");

            PanelMenuBar.Controls.Add(UserControl);
        }
    }
    private void DisplayDates()
    {
        LabelFromDate.Text = string.Format("Import Date: {0}, {1}", 
            ((DateTime) RadDateTimePickerFromDate.SelectedDate).ToShortTimeString(),
            ((DateTime) RadDateTimePickerFromDate.SelectedDate).ToShortDateString());
        LabelToDate.Text = string.Format("As of Date: {0}, {1}", 
            ((DateTime) RadDateTimePickerToDate.SelectedDate).ToShortTimeString(),
            ((DateTime)RadDateTimePickerToDate.SelectedDate).ToShortDateString());
    }

    protected void ButtonGenerateReport_Click(object sender, EventArgs e)
    {
        if (CheckBoxShowIntermediateDates.Checked)
        {
            GenerateMulti();
        }
        else
        {
            GenerateSingle();
        }
    }

    private void GenerateMulti()
    {
        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Reconciliation Report";

        cells[0, 0].Formula =
            string.Format("Reconciliation Report for orders received after {0}, {1}.", 
                ((DateTime) RadDateTimePickerFromDate.SelectedDate).ToShortTimeString(),
                ((DateTime) RadDateTimePickerFromDate.SelectedDate).ToShortDateString());
        cells[0, 0, 0, 5].Merge();
        cells[0, 0, 0, 5].Font.Bold = true;
        cells[0, 0, 0, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
        cells[1, 0, 1, 5].Merge();
        cells[1, 0, 1, 5].Font.Bold = true;
        cells[1, 0, 1, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

        DateTime runningdate = ((DateTime) RadDateTimePickerFromDate.SelectedDate).AddDays(1);
        int row = 3;

        while (runningdate <= RadDateTimePickerToDate.SelectedDate)
        {
            SynderoReconciliationReportInfo[] recinfo =
              SynderoReconciliation.GetSynderoReconciliationReport(ReportNetDefs.SynderoStoreId,
                  ((DateTime) RadDateTimePickerFromDate.SelectedDate), runningdate);
            
            cells[row, 0].Formula =
                string.Format("Order Status as of {0}, {1}.", 
                    runningdate.ToShortTimeString(),
                    runningdate.ToShortDateString());
            cells[row, 0, row, 5].Merge();
            cells[row, 0, row, 5].Font.Bold = true;
            cells[row, 0, row, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
            row++;
            row++;

            cells[row, 0].Formula = "Item";
            cells[row, 1].Formula = "Converted Item";
            cells[row, 2].Formula = "Quantity Ordered";
            cells[row, 3].Formula = "Quantity Shipped";
            cells[row, 4].Formula = "Dropout Quantity";
            cells[row, 5].Formula = "Quantity not yet shipped";
            cells[row, 0, row, 5].Font.Bold = true;
            cells[row, 2, row, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Right;

            row++;
            int qtyimported = 0;
            int qtyshipped = 0;
            int qtydropped = 0;
            int qtyunresolved = 0;

            foreach (SynderoReconciliationReportInfo info in recinfo)
            {
                cells[row, 0].Formula = info.ItemId;
                cells[row, 1].Formula = info.ConvertedItemId;
                cells[row, 2].Formula = ((int)info.QtyImported).ToString();
                cells[row, 3].Formula = ((int)info.QtyShipped).ToString();
                cells[row, 4].Formula = ((int)info.QtyDropped).ToString();
                cells[row, 5].Formula = ((int)info.QtyUnresolved).ToString();

                qtyimported += ((int)info.QtyImported);
                qtyshipped += ((int)info.QtyShipped);
                qtydropped += ((int)info.QtyDropped);
                qtyunresolved += ((int)info.QtyUnresolved);

                row++;
            }

            cells[row, 0].Formula = "Total";
            cells[row, 2].Formula = qtyimported.ToString();
            cells[row, 3].Formula = qtyshipped.ToString();
            cells[row, 4].Formula = qtydropped.ToString();
            cells[row, 5].Formula = qtyunresolved.ToString();
            cells[row, 0, row, 5].Font.Bold = true;

            row++;
            row++;
            runningdate = runningdate.AddDays(1);
        }
        cells[3, 0, row, 5].Columns.AutoFit();

        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=ReconciliationReport.xls");
        Response.BinaryWrite(data);
        Response.End();

    }

    private void GenerateSingle()
    {
        SynderoReconciliationReportInfo[] recinfo =
            SynderoReconciliation.GetSynderoReconciliationReport(ReportNetDefs.SynderoStoreId,
                ((DateTime) RadDateTimePickerFromDate.SelectedDate), 
                ((DateTime) RadDateTimePickerToDate.SelectedDate));

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Reconciliation Report";

        cells[0, 0].Formula =
            string.Format("Reconciliation Report for orders received after {0}, {1}.", 
                ((DateTime) RadDateTimePickerFromDate.SelectedDate).ToShortTimeString(),
                ((DateTime) RadDateTimePickerFromDate.SelectedDate).ToShortDateString());
        cells[1, 0].Formula =
            string.Format("Order Status as of {0}, {1}.", 
                ((DateTime) RadDateTimePickerToDate.SelectedDate).ToShortTimeString(),
                ((DateTime) RadDateTimePickerToDate.SelectedDate).ToShortDateString());
        cells[0, 0, 0, 5].Merge();
        cells[0, 0, 0, 5].Font.Bold = true;
        cells[0, 0, 0, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
        cells[1, 0, 1, 5].Merge();
        cells[1, 0, 1, 5].Font.Bold = true;
        cells[1, 0, 1, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

        cells[3, 0].Formula = "Item";
        cells[3, 1].Formula = "Converted Item";
        cells[3, 2].Formula = "Quantity Ordered";
        cells[3, 3].Formula = "Quantity Shipped";
        cells[3, 4].Formula = "Dropout Quantity";
        cells[3, 5].Formula = "Quantity not yet shipped";
        cells[3, 0, 3, 5].Font.Bold = true;
        cells[3, 2, 3, 5].HorizontalAlignment = SpreadsheetGear.HAlign.Right;

        int row = 4;
        int qtyimported = 0;
        int qtyshipped = 0;
        int qtydropped = 0;
        int qtyunresolved = 0;

        foreach (SynderoReconciliationReportInfo info in recinfo)
        {
            cells[row, 0].Formula = info.ItemId;
            cells[row, 1].Formula = info.ConvertedItemId;
            cells[row, 2].Formula = ((int) info.QtyImported).ToString();
            cells[row, 3].Formula = ((int) info.QtyShipped).ToString();
            cells[row, 4].Formula = ((int) info.QtyDropped).ToString();
            cells[row, 5].Formula = ((int) info.QtyUnresolved).ToString();

            qtyimported += ((int) info.QtyImported);
            qtyshipped += ((int) info.QtyShipped);
            qtydropped += ((int) info.QtyDropped);
            qtyunresolved += ((int) info.QtyUnresolved);

            row++;
        }

        cells[row, 0].Formula = "Total";
        cells[row, 2].Formula = qtyimported.ToString();
        cells[row, 3].Formula = qtyshipped.ToString();
        cells[row, 4].Formula = qtydropped.ToString();
        cells[row, 5].Formula = qtyunresolved.ToString();
        cells[row, 0, row, 5].Font.Bold = true;

        cells[3, 0, row, 5].Columns.AutoFit();

        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=ReconciliationReport.xls");
        Response.BinaryWrite(data);
        Response.End();
      
    }
    protected void DropDownListStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        mStoreId = Convert.ToInt32(DropDownListStore.SelectedItem.Value);
        Session["StoreId"] = mStoreId.ToString();
    }
    protected void RadDateTimePickerFromDate_SelectedDateChanged1(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (RadDateTimePickerToDate.SelectedDate <= RadDateTimePickerFromDate.SelectedDate)
        {
            RadDateTimePickerToDate.SelectedDate = ((DateTime)RadDateTimePickerFromDate.SelectedDate).AddDays(1);
        }
        DisplayDates();
    }
    protected void RadDateTimePickerToDate_SelectedDateChanged1(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (RadDateTimePickerFromDate.SelectedDate >= RadDateTimePickerToDate.SelectedDate)
        {
            RadDateTimePickerFromDate.SelectedDate = ((DateTime)RadDateTimePickerToDate.SelectedDate).AddDays(-1);
        }
        DisplayDates();
    }
}
