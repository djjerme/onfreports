<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuBarNET.ascx.cs" Inherits="MenuBarNET" %>
<asp:Menu ID="Menu1" runat="server" BorderStyle="None" OnMenuItemClick="Menu1_MenuItemClick" BorderWidth="0px" Orientation="Horizontal" StaticEnableDefaultPopOutImage="False">
    <StaticMenuItemStyle CssClass="tableAlternate" />
    <DynamicHoverStyle CssClass="menuHover" />
    <Items>
        <asp:MenuItem Selectable="False" Text="Orders" Value="Orders">
            <asp:MenuItem Text="Pick Available" Value="PickAvailable"></asp:MenuItem>
            <asp:MenuItem Text="Pick Not Available" Value="PickNotAvailable"></asp:MenuItem>
            <asp:MenuItem Text="Pick Staged" Value="PickStaged"></asp:MenuItem>
            <asp:MenuItem Text="Ship" Value="Ship"></asp:MenuItem>
            <asp:MenuItem Text="Batch Shipping" Value="BatchShipping"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Selectable="False" Text="Inventory" Value="Inventory">
            <asp:MenuItem Text="Upates" Value="Upates"></asp:MenuItem>
            <asp:MenuItem Text="Inquiry" Value="Inquiry"></asp:MenuItem>
            <asp:MenuItem Text="Inbound Materials" Value="InboundMaterials"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Selectable="False" Text="Reports" Value="Reports">
            <asp:MenuItem Text="Receiving Report" Value="Receiving"></asp:MenuItem>
            <asp:MenuItem Text="Backorder Report By Order" Value="BackorderByOrder"></asp:MenuItem>
            <asp:MenuItem Text="Backorder Report by Part Number" Value="BackorderByPartNumber"></asp:MenuItem>
            <asp:MenuItem Text="Items that Cannot be Filled by Order" Value="ItemsCannotFillByOrder"></asp:MenuItem>
            <asp:MenuItem Text="Items that Cannot be Filled by Part Number" Value="ItemsCannotFillByPartNumber"></asp:MenuItem>
            <asp:MenuItem Text="Inventory Snapshot Report" Value="InventorySnapshotReport"></asp:MenuItem>
            <asp:MenuItem Text="Order Summary Report" Value="OrderSummaryReport"></asp:MenuItem>
            <asp:MenuItem Text="Order Detail Report" Value="OrderDetailReport"></asp:MenuItem>
            <asp:MenuItem Text="Freight Report" Value="FreightReport"></asp:MenuItem>
            <asp:MenuItem Text="Consolidated Freight Report" Value="ConsolidatedFreightReport"></asp:MenuItem>
            <asp:MenuItem Text="Credit Card Report" Value="CreditCardReport"></asp:MenuItem>
            <asp:MenuItem Text="Order Reconciliation Report" Value="ReconciliationReport"></asp:MenuItem>
            <asp:MenuItem Text="Order Shipping Detail Report" Value="OrderShippingDetailReport"></asp:MenuItem>
         </asp:MenuItem>
        <asp:MenuItem Selectable="False" Text="Tools" Value="Tools">
            <asp:MenuItem Text="Locations" Value="Locations"></asp:MenuItem>
            <asp:MenuItem Text="Batch Order Delete" Value="BatchOrderDelete"></asp:MenuItem>
            <asp:MenuItem Text="Rename Item" Value="RenameItem"></asp:MenuItem>
            <asp:MenuItem Text="Freight Rules" Value="FreightRules"></asp:MenuItem>
            <asp:MenuItem Text="Sibelius Orders" Value="SibeliusOrders"></asp:MenuItem>
            <asp:MenuItem Selectable="False" Text="License Keys" Value="LicenseKeys">
                <asp:MenuItem Text="Assign License Keys" Value="AssignLicenseKeys"></asp:MenuItem>
                <asp:MenuItem Text="Export Labels" Value="ExportLabels"></asp:MenuItem>
                <asp:MenuItem Text="License Keys and Masks" Value="LicenseKeysAndMasks"></asp:MenuItem>
                <asp:MenuItem Text="UPC Info" Value="UPCInfo"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Selectable="False" Text="Indicia Order Export" Value="IndiciaOrderExport">
                <asp:MenuItem Text="Store Settings" Value="StoreSettings"></asp:MenuItem>
                <asp:MenuItem Text="Item Settings" Value="ItemSettings"></asp:MenuItem>
                <asp:MenuItem Text="Template Settings" Value="TemplateSettings"></asp:MenuItem>
                <asp:MenuItem Text="Summary and Results" Value="SummaryAndResults"></asp:MenuItem>
                <asp:MenuItem Text="Dropouts" Value="Dropouts"></asp:MenuItem>
                <asp:MenuItem Text="Dropout Distribution List" Value="DropoutDistributionList"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Order Notification" Value="OrderNotification">
                <asp:MenuItem Text="Store Settings" Value="StoreSettings"></asp:MenuItem>
                <asp:MenuItem Text="Notification Definitions" Value="Definitions"></asp:MenuItem>
                <asp:MenuItem Text="Notification Results" Value="Results"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Selectable="True" Text="Logout" Value="Logout"/>
    </Items>
    <StaticHoverStyle CssClass="menuHover" />
    <LevelMenuItemStyles>
        <asp:MenuItemStyle BorderStyle="None" Font-Underline="False" ItemSpacing="10px" Width="75%" />
        <asp:MenuItemStyle BorderStyle="None" Font-Underline="False" CssClass="menuNormal" HorizontalPadding="2px" VerticalPadding="4px" />
        <asp:MenuItemStyle Font-Underline="False" BorderStyle="None" CssClass="menuNormal" HorizontalPadding="2px" VerticalPadding="4px" />
    </LevelMenuItemStyles>
    <LevelSubMenuStyles>
        <asp:SubMenuStyle Font-Underline="False" BorderStyle="None" />
        <asp:SubMenuStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Underline="False" />
        <asp:SubMenuStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Underline="False" />
    </LevelSubMenuStyles>
</asp:Menu>
