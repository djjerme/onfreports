<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuBarNET2.ascx.cs" Inherits="MenuBarNET2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadMenu ID="RadMenuBar2" runat="server" Skin="Vista" OnItemClick="RadMenuBar2_ItemClick">
    <Items>
        <telerik:RadMenuItem runat="server" Text="Orders" Value="Orders">
            <Items>
                <telerik:RadMenuItem runat="server" Text="Pick Available"  Value="PickAvailable">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Pick Not Available" Value="PickNotAvailable">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Pick Staged" Value="PickStaged">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Ship" Value="Ship">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Batch Shipping" Value="BatchShipping">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Inventory" Value="Inventory">
            <Items>
                <telerik:RadMenuItem runat="server" Text="Updates" Value="Updates">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Inquiry" Value="Inquiry">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Inbound Materials" Value="InboundMaterials">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="OnHand Negative" Value="OnHandNeg">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Reports" Value="Reports">
            <Items>
                <telerik:RadMenuItem runat="server" Text="Receiving Report" Value="Receiving">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Backorder Report By Order" Value="BackorderByOrder">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Backorder Report by Part Number" Value="BackorderByPartNumber">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Items that Cannot be Filled by Order" Value="ItemsCannotFillByOrder">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Items that Cannot be Filled by Part Number" Value="ItemsCannotFillByPartNumber">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Inventory Snapshot Report" Value="InventorySnapshotReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Order Summary Report" Value="OrderSummaryReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Order Detail Report" Value="OrderDetailReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Freight Report" Value="FreightReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Consolidated Freight Report" Value="ConsolidatedFreightReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Credit Card Report" Value="CreditCardReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Order Reconciliation Report" Value="ReconciliationReport">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Order Shipping Detail Report" Value="OrderShippingDetailReport" >
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="POD Report" Value="PODReport" >
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Consolidated POD Report" Value="ConsolidatedPODReport" >
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Tools" Value="Tools">
            <Items>
                <telerik:RadMenuItem runat="server" Text="Locations" Value="Locations">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Batch Order Delete" Value="BatchOrderDelete">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Rename Item" Value="RenameItem">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Freight Rules" Value="FreightRules">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Sibelius Orders" Value="SibeliusOrders">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="License Keys" Value="LicenseKeys">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Assign License Keys" Value="AssignLicenseKeys">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Export Labels" Value="ExportLabels">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="License Keys and Masks" Value="LicenseKeysAndMasks">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="UPC Info" Value="UPCInfo">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Indicia Order Export" Value="IndiciaOrderExport">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Store Settings" Value="StoreSettings">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Item Settings" Value="ItemSettings">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Template Settings" Value="TemplateSettings">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Summary and Results" Value="SummaryAndResults">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Dropouts" Value="Dropouts">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Dropout Distribution List" Value="DropoutDistributionList">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Order Notification" Value="OrderNotification">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Store Settings" Value="StoreSettings">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Notification Definitions" Value="Definitions">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Notification Results" Value="Results">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" Text="Logout" Value="Logout">
        </telerik:RadMenuItem>
    </Items>
</telerik:RadMenu>
