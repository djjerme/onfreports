<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderShippingDetailReport.aspx.cs" Inherits="OrderShippingDetailReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Order Shipping Detail</title>
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
            </tr>
            <tr>
                <td valign="top">
                    <asp:Panel ID="PanelMenuBar" runat="server" Height="20px" Width="95%" CssClass="divMenu" >
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Order Shipping Detail Report" CssClass="labelNoWrapBold"></asp:Label></td>
            </tr>
            <tr>
                <td valign="top">
                </td>
            </tr>
            <tr>
                <td style="height: 21px;" valign="top">
                    <div class="divBand" >
                        <div class="divIndent1" >
                            <asp:Label ID="LabelCustomer" runat="server" CssClass="labelNoWrap" Text="Customer:"></asp:Label>
                        </div>
                        <div class="divIndent2" >
                    <asp:DropDownList ID="DropDownListStore" runat="server" AutoPostBack="True" CssClass="tableButton"
                        DataSourceID="ObjectDataSourceStoreNameID" DataTextField="StoreName" DataValueField="StoreId"
                        OnSelectedIndexChanged="DropDownListStore_SelectedIndexChanged" Width="243px">
                    </asp:DropDownList></div>  
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 28px;" valign="top">
                    <div class="divBand" >
                        <div class="divIndent1" >
                            <asp:Label ID="Label5" runat="server" CssClass="labelNoWrap" Text="Need Date on or after:"></asp:Label></div>
                        <div class="divIndent2" >
                            <telerik:RadDatePicker ID="RadDatePickerNeedDateAfter" runat="server" Skin="Vista">
                                <DateInput runat="server" Skin="Vista" CssClass="tableButton">
                                </DateInput>
                                <Calendar runat="server" Skin="Vista">
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 29px;" valign="top">
                    <div class="divBand" >
                        <div class="divIndent1" >
                            <asp:Label ID="Label6" runat="server" CssClass="labelNoWrap" Text="Need Date before:"></asp:Label></div>
                        <div class="divIndent2" >
                            <telerik:RadDatePicker ID="RadDatePickerNeedDateBefore" runat="server" Skin="Vista">
                                <DateInput runat="server" Skin="Vista" CssClass="tableButton">
                                </DateInput>
                                <Calendar runat="server" Skin="Vista">
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 29px" valign="top">
                    <div class="divBand" >
                        <div class="divIndent1" >
                            <asp:Label ID="Label2" runat="server" CssClass="labelNoWrap" Text="Requested Ship Method:"></asp:Label>
                        </div>
                        <div class="divIndent2" >
                            <asp:TextBox ID="TextBoxRequestedShipMethod" CssClass="tableButton" runat="server" Width="230px"></asp:TextBox>                    
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 26px">
                    <div class="divBand" >
                        <div class="divIndent1">
                            <asp:Button ID="ButtonApplyFilters" runat="server" CssClass="tableButton" Text="Apply Filters" OnClick="ButtonApplyFilters_Click" />
                        </div>
                        <div class="divIndent2">
                            <asp:Button ID="ButtonExport" runat="server" CssClass="tableButton" Text="Export to Excel" OnClick="ButtonExport_Click" />
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 51px">
                    <div class="divBand" >
                        <div class="divIndent1">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img src="Images/loading4.gif" alt="" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <telerik:RadGrid ID="RadGridOrderShippingDetail" runat="server" DataSourceID="ObjectDataSourceOrderShippingDetail"
                        GridLines="None" Skin="Office2007" AllowSorting="True" OnNeedDataSource="RadGridOrderShippingDetail_NeedDataSource1">
                        <MasterTableView AutoGenerateColumns="False" DataSourceID="ObjectDataSourceOrderShippingDetail">
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="StoreName" HeaderText="Store" SortExpression="StoreName"
                                    UniqueName="StoreName">
                                    <ItemStyle Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OrderNumber" HeaderText="Order Number" ReadOnly="True"
                                    SortExpression="OrderNumber" UniqueName="OrderNumber">
                                    <ItemStyle Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OrderWhen" DataFormatString="{0:d}" DataType="System.DateTime"
                                    HeaderText="Order When" SortExpression="OrderWhen" UniqueName="OrderWhen">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PickDate" DataType="System.DateTime" HeaderText="Pick Date"
                                    SortExpression="PickDate" UniqueName="PickDate">
                                    <ItemStyle Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NeedDate" DataFormatString="{0:d}" DataType="System.DateTime"
                                    EditFormHeaderTextFormat="{0d}:" HeaderText="Need Date" SortExpression="NeedDate"
                                    UniqueName="NeedDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RequestedShipMethod" HeaderText="Requested Ship Method"
                                    SortExpression="RequestedShipMethod" UniqueName="RequestedShipMethod">
                                    <ItemStyle Wrap="False" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ShipLabelComment" HeaderText="Ship Label Comment"
                                    SortExpression="ShipLabelComment" UniqueName="ShipLabelComment">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UrgencyCode" DataType="System.Int32" HeaderText="Urgency Code"
                                    SortExpression="UrgencyCode" UniqueName="UrgencyCode">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu EnableTheming="True" Skin="WinXP">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSourceStoreNameId" runat="server" SelectMethod="GetStoreNameIDAndSelectAll"
            TypeName="PBA.OnfDAL.StoreNameIDData" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceOrderShippingDetail" runat="server" SelectMethod="GetOrderShippingDetailList"
                TypeName="PBA.OnfList.OrderShippingDetailList"></asp:ObjectDataSource>
        </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ButtonExport" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp; &nbsp;
    </form>
</body>
</html>
