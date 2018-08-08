<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderSummaryReport.aspx.cs" Inherits="OrderSummaryReport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Order Summary Report</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManagerOrderSummaryReport" runat="server">
    </asp:ScriptManager>   
    <asp:UpdatePanel ID="UpdatePanelOrderSummaryReport" runat="server">
    <ContentTemplate>
    <div>
        <table class="tableAlternate" width="95%">
            <tr>
                <td style="width: 3px" valign="top">
                    <asp:Label ID="Label1" runat="server" CssClass="labelNoWrapBold" Text="Order Summary Report"></asp:Label></td>
                <td colspan="2">
                    <asp:Panel ID="PanelMenuBar" runat="server" Height="20px" Width="95%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 3px">
                    Filters:</td>
                <td style="width: 298px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="height: 14px; width: 298px;">
                </td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="LabelCustomer" runat="server" CssClass="labelNoWrapBold" Text="Customer:"></asp:Label></td>
                <td style="height: 14px; width: 298px;">
                    <asp:DropDownList ID="DropDownListStore" runat="server" AutoPostBack="True" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceStoreNameID" DataTextField="StoreName" DataValueField="StoreId"
                        OnSelectedIndexChanged="DropDownListStore_SelectedIndexChanged" Width="243px">
                    </asp:DropDownList></td>
                <td style="height: 14px">
                    </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label2" runat="server" CssClass="labelNoWrapBold" Text="Product Department:"></asp:Label></td>
                <td style="height: 14px; width: 298px;">
                    <asp:DropDownList ID="DropDownListDepartment" runat="server" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceDepartment" OnSelectedIndexChanged="DropDownListDepartment_SelectedIndexChanged"
                        Width="243px" AutoPostBack="True" DataTextField="Name" DataValueField="DeptId">
                    </asp:DropDownList></td>
                <td style="height: 14px">
                    </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label4" runat="server" CssClass="labelNoWrapBold" Text="Product Sub-Department:"></asp:Label></td>
                <td style="height: 14px; width: 298px;">
                    <asp:DropDownList ID="DropDownListSubDepartment" runat="server" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceSubDepartment" Width="243px" DataTextField="Name" DataValueField="SubDeptId" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label7" runat="server" CssClass="labelNoWrapBold" Text="Item:"></asp:Label></td>
                <td style="width: 298px; height: 14px">
                    <asp:DropDownList ID="DropDownListItem" runat="server" CssClass="tableButton" DataSourceID="ObjectDataSourceItem"
                        DataTextField="ItemId" DataValueField="ItemId" Width="243px">
                    </asp:DropDownList></td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label5" runat="server" CssClass="labelNoWrapBold" Text="User Type:"></asp:Label></td>
                <td style="height: 14px; width: 298px;">
                    <asp:DropDownList ID="DropDownListUserType" runat="server" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceUserType" Width="244px" DataTextField="UserType" DataValueField="UserType">
                    </asp:DropDownList></td>
                <td style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label6" runat="server" CssClass="labelNoWrapBold" Text="Date Range:"></asp:Label></td>
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
                    <asp:CheckBox ID="CheckBoxSnapshotSync" runat="server" Text="Synchronize to Snapshots?" /></td>
                <td style="height: 14px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="width: 298px; height: 14px" valign="top"><asp:CheckBox ID="CheckBoxArchive" runat="server" Text="Use Archive data?" /></td>
                <td style="height: 14px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="width: 298px; height: 14px" valign="top">
                </td>
                <td style="height: 14px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                    <asp:Label ID="Label8" runat="server" CssClass="labelNoWrapBold" Text="Grouping:"></asp:Label></td>
                <td style="width: 298px; height: 14px" valign="top">
                    <asp:DropDownList ID="DropDownListGrouping" runat="server" CssClass="tableButton"
                        Width="163px">
                        <asp:ListItem>By Item</asp:ListItem>
                        <asp:ListItem>By Date</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="height: 14px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="width: 298px; height: 14px" valign="top">
                </td>
                <td style="height: 14px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 3px; height: 14px">
                </td>
                <td style="width: 298px; height: 14px">
                    <asp:Button ID="ButtonGenerateReport" runat="server" CssClass="tableButton" OnClick="ButtonGenerateReport_Click"
                        Text="Generate Report" /></td>
                <td style="height: 14px">
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
        <asp:ObjectDataSource ID="ObjectDataSourceStoreNameId" runat="server" SelectMethod="GetStoresOnly"
            TypeName="PBA.OnfDAL.StoreNameIDData">
            <SelectParameters>
                <asp:Parameter Name="storeid" Type="Int32" />
                <asp:SessionParameter Name="userid" SessionField="UserId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceDepartment" runat="server" SelectMethod="GetDepartmentsAndDefault"
            TypeName="PBA.OnfBLL.Department" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="storeid" SessionField="StoreId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSubDepartment" runat="server" SelectMethod="GetSubDepartmentsAndDefault"
            TypeName="PBA.OnfBLL.SubDepartment">
            <SelectParameters>
                <asp:SessionParameter Name="storeid" SessionField="StoreId" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListDepartment" Name="deptid" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceUserType" runat="server" SelectMethod="GetUserTypesAndDefault"
            TypeName="PBA.OnfBLL.UserType">
            <SelectParameters>
                <asp:SessionParameter Name="storeid" SessionField="StoreId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceItem" runat="server" SelectMethod="GetItemAndDefault"
            TypeName="PBA.OnfBLL.Item">
            <SelectParameters>
                <asp:SessionParameter Name="storeID" SessionField="StoreId" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListDepartment" Name="deptid" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListSubDepartment" Name="subdeptid" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
