<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SynderoReconciliationReport.aspx.cs" Inherits="SynderoReconciliationReport" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Inventory Reconciliation Report</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManagerSynderoReconciliationReport" runat="server">
    </asp:ScriptManager>   
    <asp:UpdatePanel ID="UpdatePanelSynderoReconciliationReport" runat="server">
    <ContentTemplate>
    <div>
        <table class="tableAlternate" width="95%">
            <tr>
                <td class="labelNoWrapBold" style="width: 178px" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Order Reconciliation Report"></asp:Label></td>
                <td align="left" colspan="2" rowspan="1" valign="top">
                    <asp:Panel ID="PanelMenuBar" runat="server" Height="20px" Width="95%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px">
                </td>
                <td style="height: 14px; width: 322px;">
                    &nbsp;
                </td>
                <td style="height: 14px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px">
                    <asp:Label ID="LabelCustomer" runat="server" CssClass="labelNoWrapBold" Text="Customer:"></asp:Label></td>
                <td style="width: 322px; height: 14px">
                    <asp:DropDownList ID="DropDownListStore" runat="server" AutoPostBack="True" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceStoreNameID" DataTextField="StoreName" DataValueField="StoreId"
                        OnSelectedIndexChanged="DropDownListStore_SelectedIndexChanged" Width="243px">
                    </asp:DropDownList></td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px">
                </td>
                <td style="width: 322px; height: 14px">
                </td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                    <asp:Label ID="Label2" runat="server" CssClass="labelNoWrapBold" Text="Select Dates:"></asp:Label></td>
                <td style="width: 322px">
                    <table width="95%">
                        <tr>
                            <td class="labelNoWrap">
                                <asp:Label ID="LabelFromDate" runat="server" CssClass="labelNoWrap">Date Orders were Imported</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 16px">
                               <telerik:RadDateTimePicker ID="RadDateTimePickerFromDate" runat="server" AutoPostBackControl="Calendar"
                                  CssClass="tableButton" FocusedDate="2007-06-26" OnSelectedDateChanged="RadDateTimePickerFromDate_SelectedDateChanged1"
                                  SelectedDate="2007-06-26">
                                  <TimeView Skin="" Style="display: none;">
                                  </TimeView>
                               </telerik:RadDateTimePicker>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table width="95%">
                        <tr>
                            <td class="labelNoWrap">
                                <asp:Label ID="LabelToDate" runat="server" CssClass="labelNoWrap">As of Date</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 10px">
                               <telerik:RadDateTimePicker ID="RadDateTimePickerToDate" runat="server" AutoPostBackControl="Calendar"
                                  CssClass="tableButton" FocusedDate="2007-06-26" OnSelectedDateChanged="RadDateTimePickerToDate_SelectedDateChanged1"
                                  SelectedDate="2007-06-26">
                                  <TimeView Skin="" Style="display: none;">
                                  </TimeView>
                               </telerik:RadDateTimePicker>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                </td>
                <td style="width: 322px">
                    <asp:CheckBox ID="CheckBoxShowIntermediateDates" runat="server" CssClass="tableButton"
                        Text="Show Intermediate Dates" /></td>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                </td>
                <td style="width: 322px">
                    <asp:Button ID="ButtonGenerateReport" runat="server" CssClass="tableButton" OnClick="ButtonGenerateReport_Click"
                        Text="Generate Report" /></td>
                <td>
                </td>
            </tr>
        </table>
    
    </div>
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonGenerateReport" />
        </Triggers>
    </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjectDataSourceStoreNameId" runat="server" SelectMethod="GetStoresOnly"
            TypeName="PBA.OnfDAL.StoreNameIDData">
            <SelectParameters>
                <asp:Parameter Name="storeid" Type="Int32" />
                <asp:SessionParameter Name="userid" SessionField="UserId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
