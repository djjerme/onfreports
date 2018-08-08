<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomOrderReport.aspx.cs" Inherits="CustomOrderReport" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="report.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmReport" runat="server">
    
    <asp:Panel ID="pnlFilter" runat="server">
        
        <div class="divBand" style="height: 25px; left: 0px;">
            <div class="divIndent1">
                <asp:Button ID="ButtonGenerateReport" runat="server" CssClass="tableButton" Text="Generate Report" OnClick="ButtonGenerateReport_Click" /></div>
        </div>    
    
    </asp:Panel>
    
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
    
    
        <table class="ReportToolbar" width="850" height="22" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="600" class="ReportHeader" height="22" nowrap="true" align="left">
                    <asp:Label id="lblReportName" runat="server" Text="" />
                </td>
                <td width="350" class="ReportAction" align="left">
                    <asp:Image ID="imgExcel" class="ReportActionIcon" ImageUrl="/Images/ExcelIcon.gif" runat="server" />
                    <asp:LinkButton id="btnExcelExport" Text="EXPORT TO EXCEL" ToolTip="Excel Current Report to Microsoft Excel" onclick="btnExcelExport_Click" runat="server" />
                </td>
            </tr>
        </table>
    
        <asp:DataGrid id="dgReport" width="850" class="EvalTable" AllowSorting="True" AutoGenerateColumns="False" OnSortCommand="dgReport_Sort" GridLines="Horizontal" BorderColor="#8E92B8" BackColor="#F1F4F6" BorderStyle="solid" BorderWidth="1" CellPadding="2" CellSpacing="0" runat="server">
            <HeaderStyle cssclass="gridheader" />
            <AlternatingItemStyle cssclass="gridalternate" />
            <Columns>
                <asp:BoundColumn HeaderText="Order ID" DataField="order_number" SortExpression="order_id" />
            </Columns>
        </asp:DataGrid>
    
        
    </asp:Panel>
    

    </form>
</body>
</html>
