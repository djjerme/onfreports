using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PBA.OnfInfo;
using PBA.OnfDAL;
using PBA.OnfList;

public partial class OrderShippingDetailReport : System.Web.UI.Page
{
    private List<OrderShippingDetailInfo> mOrderShippingDetail;
    private CollectionView mOrderShippingDetailView;

    protected void Page_Load(object sender, EventArgs e)
    {
        Control UserControl;
        UserControl = LoadControl("MenuBarNET2.ascx");

        PanelMenuBar.Controls.Add(UserControl);

        if (!IsPostBack)
        {
            RefreshGrid();
            RadGridOrderShippingDetail.DataBind();
        }
    }
    protected void DropDownListStore_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void RefreshGrid()
    {
        RadGridOrderShippingDetail.DataSourceID = null;
        mOrderShippingDetail = OrderShippingDetailList.GetOrderShippingDetailList();
        mOrderShippingDetailView = new CollectionView(mOrderShippingDetail);
        RadGridOrderShippingDetail.DataSource = mOrderShippingDetailView;
    }
    protected void ButtonApplyFilters_Click(object sender, EventArgs e)
    {
        RadGridOrderShippingDetail.DataSourceID = null;
        mOrderShippingDetail = OrderShippingDetailList.GetOrderShippingDetailList(
            DropDownListStore.SelectedValue == "0" ? (int?) null : Convert.ToInt32(DropDownListStore.SelectedValue),
            RadDatePickerNeedDateAfter.SelectedDate,
            RadDatePickerNeedDateBefore.SelectedDate,
            TextBoxRequestedShipMethod.Text);

        mOrderShippingDetailView = new CollectionView(mOrderShippingDetail);
        RadGridOrderShippingDetail.DataSource = mOrderShippingDetailView;
        RadGridOrderShippingDetail.DataBind();
    }
    protected void ButtonExport_Click(object sender, EventArgs e)
    {
        mOrderShippingDetail = OrderShippingDetailList.GetOrderShippingDetailList(
            DropDownListStore.SelectedValue == "0" ? (int?)null : Convert.ToInt32(DropDownListStore.SelectedValue),
            RadDatePickerNeedDateAfter.SelectedDate,
            RadDatePickerNeedDateBefore.SelectedDate,
            TextBoxRequestedShipMethod.Text);

        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        // Set the worksheet name.
        worksheet.Name = "Order Shipping Detail";

        string filters = "Filters: ";

        bool filtered = false;
        if (Convert.ToInt32(DropDownListStore.SelectedValue) != 0)
        {
            filters += string.Format("Store = {0}", DropDownListStore.SelectedItem.Text);
            filtered = true;
        }

        if (RadDatePickerNeedDateAfter.SelectedDate != null)
        {
            filters += string.Format("{0}Need Date on or after {1d}",
                filtered ? ", " : "",
                (DateTime)RadDatePickerNeedDateAfter.SelectedDate);
            filtered = true;
        }

        if (RadDatePickerNeedDateBefore.SelectedDate != null)
        {
            filters += string.Format("{0}Need Date before {1d}",
                filtered ? ", " : "",
                (DateTime)RadDatePickerNeedDateBefore.SelectedDate);
            filtered = true;
        }

        if (TextBoxRequestedShipMethod.Text != "")
        {
            filters += string.Format("{0}Requested ship method contains '{1}'",
                filtered ? ", " : "",
                TextBoxRequestedShipMethod.Text);
            filtered = true;
        }

        if (!filtered)
        {
            filters += "None";
        }

        cells[0, 0].Formula = "Order Shipping Detail";

        cells[0, 0, 0, 7].Merge();
        cells[0, 0, 0, 7].Font.Bold = true;
        cells[0, 0, 0, 7].HorizontalAlignment = SpreadsheetGear.HAlign.Center;

        cells[1, 0].Formula = filters;
        cells[1, 0, 1, 7].Merge();
        cells[1, 0, 1, 7].Font.Bold = true;
        cells[1, 0, 1, 7].HorizontalAlignment = SpreadsheetGear.HAlign.Left;

        // Load column titles and center.
        cells[3, 0].Formula = "Store";
        cells[3, 1].Formula = "Order Number";
        cells[3, 2].Formula = "Order When";
        cells[3, 3].Formula = "Pick Date/Time";
        cells[3, 4].Formula = "Need Date";
        cells[3, 5].Formula = "Requested Shipping Method";
        cells[3, 6].Formula = "Ship Label Comments";
        cells[3, 7].Formula = "Urgency";
        cells[3, 0, 3, 7].Font.Bold = true;

        int row = 4;
        foreach (OrderShippingDetailInfo dtl in mOrderShippingDetail)
        {
            cells[row, 0].Formula = dtl.StoreName;
            cells[row, 1].Formula = dtl.OrderNumber;
            cells[row, 2].Formula =
                dtl.OrderWhen != null ? string.Format("{0:d}", (DateTime)dtl.OrderWhen) : "";
            cells[row, 3].Formula =
                dtl.PickDate != null ? ((DateTime)dtl.PickDate).ToString() : "";
            cells[row, 4].Formula =
                dtl.NeedDate != null ? string.Format("{0:d}", (DateTime)dtl.NeedDate) : "";
            cells[row, 5].Formula = dtl.RequestedShipMethod != null ? dtl.RequestedShipMethod : "";
            cells[row, 6].Formula = dtl.ShipLabelComment != null ? dtl.ShipLabelComment : "" ;
            cells[row, 7].Formula = dtl.UrgencyCode != null ? ((int) dtl.UrgencyCode).ToString() : "";

            row++;
            
        }

        cells[3, 6, row, 6].WrapText = true;
        cells[3, 0, row, 5].Columns.AutoFit();
        cells[3, 6, row, 6].ColumnWidth = 50;
        cells[3, 7, row, 7].Columns.AutoFit();

        byte[] data = workbook.SaveToMemory(SpreadsheetGear.FileFormat.XLS97);
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=OrderShippingDetail.xls");
        Response.BinaryWrite(data);
        Response.End();
    }
    protected void RadGridOrderShippingDetail_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RefreshGrid();
    }
}
