<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsolidatedPODReport.aspx.cs" Inherits="ConsolidatedPODReport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="MenuBarNET2.ascx" TagName="MenuBarNET2" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Consolidated POD Report</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="header">
        <div class="divIndent0">
            <asp:Label ID="Label3" runat="server" CssClass="labelNoWrapBold" Text="Consolidated POD Report"></asp:Label>
        </div>
        <div class="divMenuBar">
            <uc1:MenuBarNET2 ID="MenuBarNET21" runat="server" />
        </div>
    </div>
    <div id="main" >
        <div class="divBand" style="height: 39px; left: 0px; top: 0px;">
        </div>
        <div class="divBand" style="height: 39px; left: 0px; top: 0px;">
            <div class="divIndent0">
                <asp:Label ID="Label4" runat="server" Text="Date Range:" CssClass="labelNoWrapBold"></asp:Label>
            </div>        
        </div>
        <div class="divBand" style="height: 40px; left: 0px; top: 0px;">
            <div class="divIndent1">
                <asp:Label ID="LabelFromDate" runat="server"></asp:Label>
            </div>        
            <div class="divIndent3">
                <asp:Label ID="LabelToDate" runat="server" Width="132px"></asp:Label></div>
            <br />
            <br />
            </div>
        <div class="divBand" style="height: 166px; left: 0px; top: 0px;">
            <div class="divIndent1">
                <asp:Calendar ID="CalendarFromDate" runat="server" BorderColor="Transparent" BorderStyle="Solid"
                    CssClass="tableNormal" OnSelectionChanged="CalendarFromDate_SelectionChanged"
                    OnVisibleMonthChanged="CalendarFromDate_VisibleMonthChanged" SelectedDate="2006-04-26" Width="180px">
                    <SelectedDayStyle Font-Bold="True" />
                    <TodayDayStyle CssClass="tableBold" />
                    <DayHeaderStyle CssClass="tableHeader" />
                    <TitleStyle CssClass="tableHeaderSilver" />
                </asp:Calendar>
                &nbsp;</div>
            <div class="divIndent3">
                <asp:Calendar ID="CalendarToDate" runat="server" BorderColor="Transparent" BorderStyle="Solid"
                    CssClass="tableNormal"
                    SelectedDate="2006-04-26" OnSelectionChanged="CalendarToDate_SelectionChanged" Width="180px">
                    <SelectedDayStyle Font-Bold="True" />
                    <TodayDayStyle CssClass="tableBold" />
                    <DayHeaderStyle CssClass="tableHeader" />
                    <TitleStyle CssClass="tableHeaderSilver" />
                </asp:Calendar>
            </div>
        </div>
        <div class="divBand" style="height: 38px; left: 0px; top: 1px;">
            <div class="divIndent1">
                <asp:LinkButton ID="LinkButtonSelectMonth" runat="server" CssClass="labelNoWrap"
                    OnClick="LinkButtonSelectMonth_Click"></asp:LinkButton></div>
        </div>
        <div class="divBand" style="height: 25px; left: 0px;">
            <div class="divIndent1">
                <asp:Button ID="ButtonGenerateReport" runat="server" CssClass="tableButton" Text="Generate Report" OnClick="ButtonGenerateReport_Click" /></div>
        </div>
    </div>
        <asp:HiddenField ID="HiddenFieldDate" runat="server" />
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonGenerateReport" />
        </Triggers>
    </asp:UpdatePanel>    
    </form>
</body>
</html>
