<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JuniperCostReport.aspx.cs" Inherits="JuniperCostReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Juniper Cost Report</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="pnlGenerateReport" runat="server">
        <table class="tableAlternate" width="95%">
            <tr>
                <td style="width: 3px" valign="top">
                    <asp:Label ID="Label1" runat="server" CssClass="labelNoWrapBold" Text="Juniper Cost Report"></asp:Label></td>
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
                    <asp:Label ID="Label3" runat="server" CssClass="labelNoWrapBold" Text="Output report in HTML:"></asp:Label></td>
                <td style="height: 14px; width: 298px;">
                    <asp:CheckBox runat="server" ID="chkboxOutputHTML" />    
                </td>
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
    
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pnlHTMLReport" Visible="false">
        <asp:Table runat="server" ID="htmlTable"></asp:Table>
    </asp:Panel>
    
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
        <asp:HiddenField ID="HiddenFieldDate" runat="server" />
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
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
