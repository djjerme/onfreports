using System;
using Telerik.Web.UI;

public partial class MenuBarNET2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string GetMenuPath(RadMenuItem item)
    {
        string menu = "";

        if (item.Level == 0)
        {
            menu = item.Value;
        }
        else
        {
            string menu0 = GetMenuPath((RadMenuItem) item.Owner);

            if (menu0 != "")
            {
                menu = menu0 + "/" + item.Value;
            }
            else
            {
                menu = item.Value;
            }
        }

        return menu;
    }

    protected void RadMenuBar2_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        string URL;
        string path = GetMenuPath(e.Item);

        string[] lStrs = path.Split('/');

        switch (lStrs[0])
        {
            case "Orders":
                if (lStrs.Length == 1)
                {
                    break;
                }
                switch (lStrs[1])
                {
                    case "PickAvailable":
                        URL = "/estore/whse/orders.asp?u=" + Session["UserId"] + "&mode=pick&filter=available";
                        Response.Redirect(URL, true);
                        break;
                    case "PickNotAvailable":
                        URL = "/estore/whse/orders.asp?u=" + Session["UserId"] + "&mode=pick&filter=notavailable";
                        Response.Redirect(URL, true);
                        break;
                    case "PickStaged":
                        URL = "/estore/whse/orders.asp?u=" + Session["UserId"] + "&mode=pick&filter=staged";
                        Response.Redirect(URL, true);
                        break;
                    case "Ship":
                        URL = "/estore/whse/orders.asp?u=" + Session["UserId"] + "&mode=ship";
                        Response.Redirect(URL, true);
                        break;
                    case "BatchShipping":
                        URL = "/estore/whse/WhseNET/ShippingBatch.aspx?u=" + Session["UserId"] + "&s=" +
                              Session["StoreId"];
                        Response.Redirect(URL, true);
                        break;
                    default:
                        break;
                }
                break;
            case "Inventory":
                if (lStrs.Length == 1)
                {
                    break;
                }
                switch (lStrs[1])
                {
                    case "Upates":
                        URL = "/estore/whse/inventory.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "Inquiry":
                        URL = "/estore/whse/inquiry.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "InboundMaterials":
                        URL = "/estore/whse/inbound_receipts.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "OnHandNeg":
                        URL = "/estore/whse/WhseNET/Inventory1.aspx?u=" + Session["UserId"] + "&s=" +
                              Session["StoreId"];
                        Response.Redirect(URL, true);
                        break;
                    default:
                        break;
                }
                break;
            case "Reports":
                if (lStrs.Length == 1)
                {
                    break;
                }
                switch (lStrs[1])
                {
                    case "Receiving":
                        URL = "/estore/whse/reportreceiving.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "BackorderByOrder":
                        URL = "/estore/whse/reportbackorderbyorder.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "BackorderByPartNumber":
                        URL = "/estore/whse/reportbackorderbypartno.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "ItemsCannotFillByOrder":
                        URL = "/estore/whse/reportitemsthatcannotbefilledbyorder.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "ItemsCannotFillByPartNumber":
                        URL = "/estore/whse/reportitemsthatcannotbefilledbypartno.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "InventorySnapshotReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/InventorySnapshot.aspx?u=" + Session["UserId"] + "&s=" + Session["StoreId"] +
                              "&W=4964";
                        Response.Redirect(URL, true);
                        break;
                    case "OrderSummaryReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/OrderSummaryReport.aspx?u=" + Session["UserId"] + "&s=" + Session["StoreId"] +
                              "&W=4964";
                        Response.Redirect(URL, true);
                        break;
                    case "OrderDetailReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/OrderDetailReport.aspx?u=" + Session["UserId"] + "&s=" + Session["StoreId"] +
                              "&W=4964";
                        Response.Redirect(URL, true);
                        break;
                    case "FreightReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/FreightReport.aspx?u=" + Session["UserId"] + "&s=" + Session["StoreId"] +
                              "&W=4964";
                        Response.Redirect(URL, true);
                        break;
                    case "ConsolidatedFreightReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/ConsolidatedFreightReport.aspx?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "CreditCardReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/CreditCardReport.aspx?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "ReconciliationReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/SynderoReconciliationReport.aspx?u=" + Session["UserId"] + "&s=" +
                              Session["StoreId"] + "&W=4964";
                        Response.Redirect(URL, true);
                        break;
                    case "OrderShippingDetailReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/OrderShippingDetailReport.aspx?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "PODReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/PODReport.aspx?u=" + Session["UserId"] + "&sid=" + Session["StoreId"] + "&W=4964";
                        Response.Redirect(URL, true);
                        break;
                    case "ConsolidatedPODReport":
                        Session["WhseUser"] = "Y";
                        URL = "/ReportNET/ConsolidatedPODReport.aspx?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    default:
                        break;
                }
                break;
            case "Tools":
                if (lStrs.Length == 1)
                {
                    break;
                }
                switch (lStrs[1])
                {
                    case "Locations":
                        URL = "/estore/whse/locations.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "BatchOrderDelete":
                        URL = "/estore/whse/batchOrderDelete.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "RenameItem":
                        URL = "/estore/whse/renameItem.asp?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "FreightRules":
                        URL = "/whseNET/FreightRules.aspx?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "SibeliusOrders":
                        URL = "/whseNET/SibeliusOrders.aspx?u=" + Session["UserId"];
                        Response.Redirect(URL, true);
                        break;
                    case "LicenseKeys":
                        if (lStrs.Length == 2)
                        {
                            break;
                        }
                        switch (lStrs[2])
                        {
                            case "AssignLicenseKeys":
                                URL = "/WhseNET/LicenseKeyAssignment.aspx?u=" + Session["UserId"] + "&s=" +
                                      Session["StoreId"];
                                Response.Redirect(URL, true);
                                break;
                            case "ExportLabels":
                                URL = "/WhseNET/MindjetOrderExport.aspx?u=" + Session["UserId"] + "&s=" +
                                      Session["StoreId"];
                                Response.Redirect(URL, true);
                                break;
                            case "LicenseKeysAndMasks":
                                URL = "/WhseNET/LicenseKeysAndMasks.aspx?u=" + Session["UserId"] + "&s=" +
                                      Session["StoreId"];
                                Response.Redirect(URL, true);
                                break;
                            case "UPCInfo":
                                URL = "/WhseNET/ItemUPCInfo.aspx?u=" + Session["UserId"] + "&s=" + Session["StoreId"];
                                Response.Redirect(URL, true);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "IndiciaOrderExport":
                        if (lStrs.Length == 2)
                        {
                            break;
                        }
                        switch (lStrs[2])
                        {
                            case "StoreSettings":
                                Response.Redirect("/WhseNET/OrderExportDashboard.aspx?u=" + Session["UserId"]);
                                break;
                            case "ItemSettings":
                                Response.Redirect("/WhseNET/OrderExportDashboardItems.aspx?u=" + Session["UserId"]);
                                break;
                            case "TemplateSettings":
                                Response.Redirect("/WhseNET/OrderExportDashboardTemplates.aspx?u=" + Session["UserId"]);
                                break;
                            case "SummaryAndResults":
                                Response.Redirect("/WhseNET/OrderExportDashboardSummary.aspx?u=" + Session["UserId"]);
                                break;
                            case "Dropouts":
                                Response.Redirect("/WhseNET/OrderDropouts.aspx?u=" + Session["UserId"]);
                                break;
                            case "DropoutDistributionList":
                                Response.Redirect("/WhseNET/EmailNotificationAddresses.aspx?u=" + Session["UserId"]
                                                  + "&s=257&mt=Dropout");
                                break;
                            default:
                                break;
                        }
                        break;
                    case "OrderNotification":
                        if (lStrs.Length == 2)
                        {
                            break;
                        }
                        switch (lStrs[2])
                        {
                            case "StoreSettings":
                                URL = "/WhseNET/OrderNotificationStoreSettings.aspx?u=" + Session["UserId"];
                                Response.Redirect(URL);
                                break;
                            case "Definitions":
                                URL = "/WhseNET/OrderNotificationDefinitions.aspx?u=" + Session["UserId"];
                                Response.Redirect(URL);
                                break;
                            case "Results":
                                URL = "/WhseNET/OrderNotificationResults.aspx?u=" + Session["UserId"];
                                Response.Redirect(URL);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case "Logout":
                URL = "/estore/whse/login.asp";
                Response.Redirect(URL, true);
                break;
            default:
                break;
        }
    }
}
