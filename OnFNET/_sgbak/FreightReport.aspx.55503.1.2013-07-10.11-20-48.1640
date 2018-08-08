<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FreightReport.aspx.cs" Inherits="FreightReport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="MenuBarNET2.ascx" TagName="MenuBarNET2" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Freight Report</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManagerOrderDetailReport" runat="server">
    </asp:ScriptManager>   
    <asp:UpdatePanel ID="UpdatePanelOrderDetailReport" runat="server">
    <ContentTemplate>
    <div>
        <table class="tableAlternate" width="95%">
            <tr>
                <td style="width: 3px" valign="top">
                    <asp:Label ID="Label1" runat="server" CssClass="labelNoWrapBold" Text="Freight Report"></asp:Label></td>
                <td colspan=2>
                    <asp:Panel ID="PanelMenuBar" runat="server" Height="20px" Width="95%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                    <asp:Label ID="Label7" runat="server" CssClass="labelNoWrapBold" Text="Options:"></asp:Label></td>
                <td style="width: 3px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                </td>
                <td style="width: 3px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                    <asp:Label ID="Label2" runat="server" CssClass="labelNoWrap" Height="8px" Text="Subtotal By:"
                        Width="61px"></asp:Label></td>
                <td style="width: 3px">
                    <asp:DropDownList ID="DropDownListSubtotalBy" runat="server" CssClass="tableButton">
                        <asp:ListItem Value="none">-- No Subtotals --</asp:ListItem>
                        <asp:ListItem Value="ship_date">Ship Date</asp:ListItem>
                        <asp:ListItem Value="carrier_code">Carrier Code</asp:ListItem>
                        <asp:ListItem Value="user_type">User Type</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                </td>
                <td style="width: 3px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                    <asp:Label ID="Label8" runat="server" CssClass="labelNoWrapBold" Text="Filters:"></asp:Label></td>
                <td style="width: 3px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 20px;">
                    <asp:Label ID="LabelCustomer" runat="server" CssClass="labelNoWrap" Text="Customer:"></asp:Label></td>
                <td style="width: 3px; height: 20px;">
                    <asp:DropDownList ID="DropDownListStore" runat="server" AutoPostBack="True" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceStoreNameID" DataTextField="StoreName" DataValueField="StoreId"
                        OnSelectedIndexChanged="DropDownListStore_SelectedIndexChanged" Width="243px">
                    </asp:DropDownList></td>
                <td style="height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 3px" valign="top">
                    <asp:Label ID="Label3" runat="server" CssClass="labelNoWrap" Text="Products:"></asp:Label></td>
                <td colspan="2" >
                    <table style="width: 422px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="height: 22px" >
                                <asp:Label ID="Label4" runat="server" CssClass="labelNoWrapBold" Text="Available"></asp:Label></td>
                            <td style="height: 22px" >
                            </td>
                            <td valign="top" style="height: 22px">
                                <asp:Label ID="Label5" runat="server" CssClass="labelNoWrapBold" Text="Selected"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 125px" >
                                <asp:ListBox ID="ListBoxAvailableItems" runat="server" CssClass="tableButton" Height="100%" SelectionMode="Multiple" Width="100%"></asp:ListBox></td>
                            <td style="height: 125px" align="center" >
                                <table style="text-align: center">
                                    <tr>
                                        <td>
                                            <asp:Button ID="ButtonAddAll" runat="server" CssClass="tableButton" Text=" >> " OnClick="ButtonAddAll_Click" ToolTip="Add All" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="ButtonAddSelected" runat="server" CssClass="tableButton" Text="  >  " OnClick="ButtonAddSelected_Click" ToolTip="Add Selected" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="ButtonRemoveSelected" runat="server" CssClass="tableButton" Text="  <  " OnClick="ButtonRemoveSelected_Click" ToolTip="Remove Selected" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="ButtonRemoveAll" runat="server" CssClass="tableButton" Text=" << " OnClick="ButtonRemoveAll_Click" ToolTip="Remove All" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="height: 125px" >
                                <asp:ListBox ID="ListBoxSelectedItems" runat="server" CssClass="tableButton" Height="100%" SelectionMode="Multiple" Width="100%"></asp:ListBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                </td>
                <td style="width: 3px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label6" runat="server" CssClass="labelNoWrap" Text="Date Range:"></asp:Label></td>
                <td style="width: 298px; height: 14px" valign="top">
                    &nbsp;
                    <table width="95%">
                        <tr>
                            <td>
                                <asp:Label ID="LabelFromDate" runat="server" CssClass="labelNoWrap"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Calendar ID="CalendarFromDate" runat="server" BorderColor="Transparent"
                        BorderStyle="Solid" CssClass="tableNormal"
                        OnSelectionChanged="CalendarFromDate_SelectionChanged" OnVisibleMonthChanged="CalendarFromDate_VisibleMonthChanged"
                        SelectedDate="2006-04-26">
                        <SelectedDayStyle Font-Bold="True" />
                        <TodayDayStyle CssClass="tableBold" />
                        <DayHeaderStyle CssClass="tableHeader" />
                        <TitleStyle CssClass="tableHeaderSilver" />
                    </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 14px">
                                <asp:LinkButton ID="LinkButtonSelectMonth" runat="server" OnClick="LinkButtonSelectMonth_Click" CssClass="labelNoWrap"></asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 14px" valign="top">
                    &nbsp;
                    <table width="95%">
                        <tr>
                            <td>
                                <asp:Label ID="LabelToDate" runat="server" CssClass="labelNoWrap"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Calendar ID="CalendarToDate" runat="server" BorderColor="Transparent" BorderStyle="Solid"
                        CssClass="tableNormal" OnSelectionChanged="CalendarToDate_SelectionChanged" SelectedDate="2006-04-26">
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
                <td style="width: 3px; height: 14px">
                </td>
                <td style="width: 298px; height: 14px" valign="top">
                    <asp:Button ID="ButtonGenerateReport" runat="server" CssClass="tableButton" OnClick="ButtonGenerateReport_Click"
                        Text="Generate Report" /></td>
                <td style="height: 14px" valign="top">
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="HiddenFieldDate" runat="server" />
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonGenerateReport" />
        </Triggers>
    </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjectDataSourceStoreNameId" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetStoreNameIDAndSelectAll" TypeName="PBA.OnfDAL.StoreNameIDData">
            <SelectParameters>
                <asp:SessionParameter Name="userid" SessionField="UserId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;
    </form>
</body>
</html>
