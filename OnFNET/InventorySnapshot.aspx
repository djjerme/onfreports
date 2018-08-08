<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InventorySnapshot.aspx.cs" Inherits="InventorySnapshot" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Inventory Snapshot</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManagerInventorySnapshot" runat="server">
        </asp:ScriptManager>   
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table class="tableAlternate" width="95%">
            <tr>
                <td class="labelNoWrapBold" style="width: 178px" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Inventory Snapshot Report"></asp:Label></td>
                <td align="left" colspan="2" valign="top" rowspan="1">
                    <asp:Panel ID="PanelMenuBar" runat="server" Height="20px" Width="95%">
                    </asp:Panel>
                    </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px;">
                    Filters:</td>
                <td style="height: 14px;">
                </td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px">
                </td>
                <td style="height: 14px;">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px">
                    <asp:Label ID="LabelCustomer" runat="server" CssClass="labelNoWrapBold" Text="Customer:"></asp:Label></td>
                <td style="height: 14px">
                    <asp:DropDownList ID="DropDownListStore" runat="server" AutoPostBack="True" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceStoreNameID" DataTextField="StoreName" DataValueField="StoreId"
                        OnSelectedIndexChanged="DropDownListStore_SelectedIndexChanged" Width="243px">
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 14px;">
                    </td>
                <td style="height: 14px;">
                    &nbsp;
                </td>
                <td style="height: 14px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                    <asp:Label ID="Label2" runat="server" CssClass="labelNoWrapBold" Text="Date Range:"></asp:Label></td>
                <td>
                    <table width="95%">
                        <tr>
                            <td class="labelNoWrap">
                    <asp:Label ID="LabelFromDate" runat="server" CssClass="labelNoWrap"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 146px">
                    <asp:Calendar ID="CalendarFromDate" runat="server" BorderColor="Transparent" BorderStyle="Solid"
                        CssClass="tableNormal" OnSelectionChanged="CalendarFromDate_SelectionChanged" OnVisibleMonthChanged="CalendarFromDate_VisibleMonthChanged">
                        <SelectedDayStyle Font-Bold="True" />
                        <TodayDayStyle CssClass="tableBold" />
                        <DayHeaderStyle CssClass="tableHeader" />
                        <TitleStyle CssClass="tableHeaderSilver" />
                    </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 18px">
                                <asp:LinkButton ID="LinkButtonSelectMonth" runat="server" CssClass="labelNoWrap"
                                    OnClick="LinkButtonSelectMonth_Click"></asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table width="95%">
                        <tr>
                            <td class="labelNoWrap">
                    <asp:Label ID="LabelToDate" runat="server" CssClass="labelNoWrap"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 146px">
                    <asp:Calendar ID="CalendarToDate" runat="server" BorderColor="Transparent" BorderStyle="Solid"
                        CssClass="tableNormal" OnSelectionChanged="CalendarToDate_SelectionChanged">
                        <SelectedDayStyle Font-Bold="True" />
                        <TodayDayStyle CssClass="tableBold" />
                        <DayHeaderStyle CssClass="tableHeader" />
                        <TitleStyle CssClass="tableHeaderSilver" />
                    </asp:Calendar>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxArchive" runat="server" Text="Use Archive data?" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 178px">
                </td>
                <td>
                    <asp:Button ID="ButtonGenerateReport" runat="server" CssClass="tableButton" Text="Generate Report" OnClick="ButtonGenerateReport_Click" /></td>
                <td>
                    </td>
            </tr>
        </table>
        <asp:HiddenField ID="HiddenFieldDate" runat="server" />
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
        &nbsp;
    </form>
</body>
</html>
