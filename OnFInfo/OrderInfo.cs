namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class OrderInfo
    {
        private string _actual_shipping_currency;
        private string _actualShipMethod;
        private decimal? _actualShipping;
        private string _barcodeId;
        private bool? _bulkOrderParentFlag;
        private int? _bulkOrderParentId;
        private string _bundleId;
        private int? _carrierId;
        private bool? _cdFulfillmentFlag;
        private int? _cdQty;
        private string _costCenter;
        private string _customMessage;
        private string _custOrderNo;
        private string _demographics10;
        private string _demographics20;
        private string _demographics21;
        private string _demographics210;
        private string _demographics22;
        private string _demographics23;
        private string _demographics24;
        private string _demographics25;
        private string _demographics26;
        private string _demographics27;
        private string _demographics28;
        private string _demographics29;
        private string _demographics30;
        private string _department;
        private string _discountCode;
        private string _expedite;
        private string _externalOrderId;
        private string _externalOrderType;
        private string _fulfillment_vendor;
        private string _fulfillment_vendor_sender_of_record;
        private string _fulfillment_vendor_third_party_account_number;
        private decimal? _grandTotal;
        private decimal? _handling;
        private decimal? _internal_shipping_cost;
        private string _internal_shipping_currency;
        private DateTime? _needDate;
        private int? _numberOfPackages;
        private int? _orderFor;
        private int? _orderId;
        private OrderItemInfo[] _orderItems;
        private string _orderReason;
        private string _orderSource;
        private int? _orderSuffix;
        private string _orderType;
        private DateTime? _orderWhen;
        private string _paymentMethod;
        private int? _personId;
        private string _pickBy;
        private DateTime? _pickDate;
        private int? _print_shop_id;
        private bool? _processedFlag;
        private string _productFamily;
        private string _projectNumber;
        private string _quoteId;
        private string _referralSourceId;
        private string _requestedShipMethod;
        private decimal? _salesTax;
        private string _salesTaxCounty;
        private string _salesTaxId;
        private int? _sendToAddress;
        private int? _sendToPerson;
        private string _shipAttnTo;
        private string _shipBy;
        private DateTime? _shipDate;
        private string _shipInvoiceTemplate;
        private string _shipLabelComment;
        private decimal? _shipping;
        private DateTime? _shipProcessDate;
        private int? _shipToId;
        private bool? _stagedOrderFlag;
        private int? _stagingId;
        private string _status;
        private int? _storeId;
        private bool? _thirdPartyShipperFlag;
        private string _thirdPartyShipperInfo;
        private string _trackingNo;
        private string _transactionId;
        private string _warehouseComment;

        public OrderInfo()
        {
        }

        public OrderInfo(int? storeId, int? orderId, int? orderSuffix, string orderType, string status, int? personId, int? orderFor, DateTime? orderWhen, DateTime? pickDate, string pickBy, DateTime? shipDate, string shipBy, string requestedShipMethod, string actualShipMethod, DateTime? needDate, string trackingNo, string orderReason, string shipLabelComment, decimal? grandTotal, decimal? shipping, decimal? handling, decimal? salesTax, string salesTaxId, int? shipToId, string costCenter, string department, string warehouseComment, int? sendToPerson, int? sendToAddress, string bundleId, string custOrderNo, bool? processedFlag, string demographics10, string demographics20, string demographics21, string demographics22, string demographics23, string demographics30, string demographics24, string demographics25, string demographics26, string demographics27, string demographics28, string demographics29, string demographics210, string quoteId, string salesTaxCounty, string productFamily, string discountCode, string transactionId, string externalOrderType, string referralSourceId, string externalOrderId, bool? bulkOrderParentFlag, int? bulkOrderParentId, bool? thirdPartyShipperFlag, string thirdPartyShipperInfo, string paymentMethod, string shipAttnTo, string customMessage, string barcodeId, bool? stagedOrderFlag, string projectNumber, string orderSource, int? stagingId, bool? cdFulfillmentFlag, int? cdQty, int? carrierId, int? numberOfPackages, decimal? actualShipping, DateTime? shipProcessDate, string expedite, string shipInvoiceTemplate)
        {
            this._storeId = storeId;
            this._orderId = orderId;
            this._orderSuffix = orderSuffix;
            this._orderType = orderType;
            this._status = status;
            this._personId = personId;
            this._orderFor = orderFor;
            this._orderWhen = orderWhen;
            this._pickDate = pickDate;
            this._pickBy = pickBy;
            this._shipDate = shipDate;
            this._shipBy = shipBy;
            this._requestedShipMethod = requestedShipMethod;
            this._actualShipMethod = actualShipMethod;
            this._needDate = needDate;
            this._trackingNo = trackingNo;
            this._orderReason = orderReason;
            this._shipLabelComment = shipLabelComment;
            this._grandTotal = grandTotal;
            this._shipping = shipping;
            this._handling = handling;
            this._salesTax = salesTax;
            this._salesTaxId = salesTaxId;
            this._shipToId = shipToId;
            this._costCenter = costCenter;
            this._department = department;
            this._warehouseComment = warehouseComment;
            this._sendToPerson = sendToPerson;
            this._sendToAddress = sendToAddress;
            this._bundleId = bundleId;
            this._custOrderNo = custOrderNo;
            this._processedFlag = processedFlag;
            this._demographics10 = demographics10;
            this._demographics20 = demographics20;
            this._demographics21 = demographics21;
            this._demographics22 = demographics22;
            this._demographics23 = demographics23;
            this._demographics30 = demographics30;
            this._demographics24 = demographics24;
            this._demographics25 = demographics25;
            this._demographics26 = demographics26;
            this._demographics27 = demographics27;
            this._demographics28 = demographics28;
            this._demographics29 = demographics29;
            this._demographics210 = demographics210;
            this._quoteId = quoteId;
            this._salesTaxCounty = salesTaxCounty;
            this._productFamily = productFamily;
            this._discountCode = discountCode;
            this._transactionId = transactionId;
            this._externalOrderType = externalOrderType;
            this._referralSourceId = referralSourceId;
            this._externalOrderId = externalOrderId;
            this._bulkOrderParentFlag = bulkOrderParentFlag;
            this._bulkOrderParentId = bulkOrderParentId;
            this._thirdPartyShipperFlag = thirdPartyShipperFlag;
            this._thirdPartyShipperInfo = thirdPartyShipperInfo;
            this._paymentMethod = paymentMethod;
            this._shipAttnTo = shipAttnTo;
            this._customMessage = customMessage;
            this._barcodeId = barcodeId;
            this._stagedOrderFlag = stagedOrderFlag;
            this._projectNumber = projectNumber;
            this._orderSource = orderSource;
            this._stagingId = stagingId;
            this._cdFulfillmentFlag = cdFulfillmentFlag;
            this._cdQty = cdQty;
            this._carrierId = carrierId;
            this._numberOfPackages = numberOfPackages;
            this._shipProcessDate = shipProcessDate;
            this._actualShipping = actualShipping;
            this._expedite = expedite;
            this._shipInvoiceTemplate = shipInvoiceTemplate;
        }

        public decimal GetExtendedTotal()
        {
            decimal num = 0M;
            if (this.OrderItems != null)
            {
                foreach (OrderItemInfo info in this.OrderItems)
                {
                    num += info.ExtendedPrice.Value;
                }
            }
            return num;
        }

        public string ActualShipMethod
        {
            get
            {
                return this._actualShipMethod;
            }
            set
            {
                this._actualShipMethod = value;
            }
        }

        public decimal? ActualShipping
        {
            get
            {
                return this._actualShipping;
            }
            set
            {
                this._actualShipping = value;
            }
        }

        public string ActualShippingCurrency
        {
            get
            {
                return this._actual_shipping_currency;
            }
            set
            {
                this._actual_shipping_currency = value;
            }
        }

        public string BarcodeId
        {
            get
            {
                return this._barcodeId;
            }
            set
            {
                this._barcodeId = value;
            }
        }

        public bool? BulkOrderParentFlag
        {
            get
            {
                return this._bulkOrderParentFlag;
            }
            set
            {
                this._bulkOrderParentFlag = value;
            }
        }

        public int? BulkOrderParentId
        {
            get
            {
                return this._bulkOrderParentId;
            }
            set
            {
                this._bulkOrderParentId = value;
            }
        }

        public string BundleId
        {
            get
            {
                return this._bundleId;
            }
            set
            {
                this._bundleId = value;
            }
        }

        public int? CarrierId
        {
            get
            {
                return this._carrierId;
            }
            set
            {
                this._carrierId = value;
            }
        }

        public bool? CdFulfillmentFlag
        {
            get
            {
                return this._cdFulfillmentFlag;
            }
            set
            {
                this._cdFulfillmentFlag = value;
            }
        }

        public int? CdQty
        {
            get
            {
                return this._cdQty;
            }
            set
            {
                this._cdQty = value;
            }
        }

        public string CostCenter
        {
            get
            {
                return this._costCenter;
            }
            set
            {
                this._costCenter = value;
            }
        }

        public string CustomMessage
        {
            get
            {
                return this._customMessage;
            }
            set
            {
                this._customMessage = value;
            }
        }

        public string CustOrderNo
        {
            get
            {
                return this._custOrderNo;
            }
            set
            {
                this._custOrderNo = value;
            }
        }

        public string Demographics10
        {
            get
            {
                return this._demographics10;
            }
            set
            {
                this._demographics10 = value;
            }
        }

        public string Demographics20
        {
            get
            {
                return this._demographics20;
            }
            set
            {
                this._demographics20 = value;
            }
        }

        public string Demographics21
        {
            get
            {
                return this._demographics21;
            }
            set
            {
                this._demographics21 = value;
            }
        }

        public string Demographics210
        {
            get
            {
                return this._demographics210;
            }
            set
            {
                this._demographics210 = value;
            }
        }

        public string Demographics22
        {
            get
            {
                return this._demographics22;
            }
            set
            {
                this._demographics22 = value;
            }
        }

        public string Demographics23
        {
            get
            {
                return this._demographics23;
            }
            set
            {
                this._demographics23 = value;
            }
        }

        public string Demographics24
        {
            get
            {
                return this._demographics24;
            }
            set
            {
                this._demographics24 = value;
            }
        }

        public string Demographics25
        {
            get
            {
                return this._demographics25;
            }
            set
            {
                this._demographics25 = value;
            }
        }

        public string Demographics26
        {
            get
            {
                return this._demographics26;
            }
            set
            {
                this._demographics26 = value;
            }
        }

        public string Demographics27
        {
            get
            {
                return this._demographics27;
            }
            set
            {
                this._demographics27 = value;
            }
        }

        public string Demographics28
        {
            get
            {
                return this._demographics28;
            }
            set
            {
                this._demographics28 = value;
            }
        }

        public string Demographics29
        {
            get
            {
                return this._demographics29;
            }
            set
            {
                this._demographics29 = value;
            }
        }

        public string Demographics30
        {
            get
            {
                return this._demographics30;
            }
            set
            {
                this._demographics30 = value;
            }
        }

        public string Department
        {
            get
            {
                return this._department;
            }
            set
            {
                this._department = value;
            }
        }

        public string DiscountCode
        {
            get
            {
                return this._discountCode;
            }
            set
            {
                this._discountCode = value;
            }
        }

        public string Expedite
        {
            get
            {
                return this._expedite;
            }
            set
            {
                this._expedite = value;
            }
        }

        public string ExternalOrderId
        {
            get
            {
                return this._externalOrderId;
            }
            set
            {
                this._externalOrderId = value;
            }
        }

        public string ExternalOrderType
        {
            get
            {
                return this._externalOrderType;
            }
            set
            {
                this._externalOrderType = value;
            }
        }

        public string FulfillmentVendor
        {
            get
            {
                return this._fulfillment_vendor;
            }
            set
            {
                this._fulfillment_vendor = value;
            }
        }

        public string FulfillmentVendorSenderOfRecord
        {
            get
            {
                return this._fulfillment_vendor_sender_of_record;
            }
            set
            {
                this._fulfillment_vendor_sender_of_record = value;
            }
        }

        public string FulfillmentVendorThirdPartyAccountNumber
        {
            get
            {
                return this._fulfillment_vendor_third_party_account_number;
            }
            set
            {
                this._fulfillment_vendor_third_party_account_number = value;
            }
        }

        public decimal? GrandTotal
        {
            get
            {
                return this._grandTotal;
            }
            set
            {
                this._grandTotal = value;
            }
        }

        public decimal? Handling
        {
            get
            {
                return this._handling;
            }
            set
            {
                this._handling = value;
            }
        }

        public decimal? InternalShippingCost
        {
            get
            {
                return this._internal_shipping_cost;
            }
            set
            {
                this._internal_shipping_cost = value;
            }
        }

        public string InternalShippingCurrency
        {
            get
            {
                return this._internal_shipping_currency;
            }
            set
            {
                this._internal_shipping_currency = value;
            }
        }

        public DateTime? NeedDate
        {
            get
            {
                return this._needDate;
            }
            set
            {
                this._needDate = value;
            }
        }

        public int? NumberOfPackages
        {
            get
            {
                return this._numberOfPackages;
            }
            set
            {
                this._numberOfPackages = value;
            }
        }

        public int? OrderFor
        {
            get
            {
                return this._orderFor;
            }
            set
            {
                this._orderFor = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this._orderId;
            }
            set
            {
                this._orderId = value;
            }
        }

        public OrderItemInfo[] OrderItems
        {
            get
            {
                return this._orderItems;
            }
            set
            {
                this._orderItems = value;
            }
        }

        public string OrderReason
        {
            get
            {
                return this._orderReason;
            }
            set
            {
                this._orderReason = value;
            }
        }

        public string OrderSource
        {
            get
            {
                return this._orderSource;
            }
            set
            {
                this._orderSource = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this._orderSuffix;
            }
            set
            {
                this._orderSuffix = value;
            }
        }

        public string OrderType
        {
            get
            {
                return this._orderType;
            }
            set
            {
                this._orderType = value;
            }
        }

        public DateTime? OrderWhen
        {
            get
            {
                return this._orderWhen;
            }
            set
            {
                this._orderWhen = value;
            }
        }

        public string PaymentMethod
        {
            get
            {
                return this._paymentMethod;
            }
            set
            {
                this._paymentMethod = value;
            }
        }

        public int? PersonId
        {
            get
            {
                return this._personId;
            }
            set
            {
                this._personId = value;
            }
        }

        public string PickBy
        {
            get
            {
                return this._pickBy;
            }
            set
            {
                this._pickBy = value;
            }
        }

        public DateTime? PickDate
        {
            get
            {
                return this._pickDate;
            }
            set
            {
                this._pickDate = value;
            }
        }

        public int? PrintShopId
        {
            get
            {
                return this._print_shop_id;
            }
            set
            {
                this._print_shop_id = value;
            }
        }

        public bool? ProcessedFlag
        {
            get
            {
                return this._processedFlag;
            }
            set
            {
                this._processedFlag = value;
            }
        }

        public string ProductFamily
        {
            get
            {
                return this._productFamily;
            }
            set
            {
                this._productFamily = value;
            }
        }

        public string ProjectNumber
        {
            get
            {
                return this._projectNumber;
            }
            set
            {
                this._projectNumber = value;
            }
        }

        public string QuoteId
        {
            get
            {
                return this._quoteId;
            }
            set
            {
                this._quoteId = value;
            }
        }

        public string ReferralSourceId
        {
            get
            {
                return this._referralSourceId;
            }
            set
            {
                this._referralSourceId = value;
            }
        }

        public string RequestedShipMethod
        {
            get
            {
                return this._requestedShipMethod;
            }
            set
            {
                this._requestedShipMethod = value;
            }
        }

        public decimal? SalesTax
        {
            get
            {
                return this._salesTax;
            }
            set
            {
                this._salesTax = value;
            }
        }

        public string SalesTaxCounty
        {
            get
            {
                return this._salesTaxCounty;
            }
            set
            {
                this._salesTaxCounty = value;
            }
        }

        public string SalesTaxId
        {
            get
            {
                return this._salesTaxId;
            }
            set
            {
                this._salesTaxId = value;
            }
        }

        public int? SendToAddress
        {
            get
            {
                return this._sendToAddress;
            }
            set
            {
                this._sendToAddress = value;
            }
        }

        public int? SendToPerson
        {
            get
            {
                return this._sendToPerson;
            }
            set
            {
                this._sendToPerson = value;
            }
        }

        public string ShipAttnTo
        {
            get
            {
                return this._shipAttnTo;
            }
            set
            {
                this._shipAttnTo = value;
            }
        }

        public string ShipBy
        {
            get
            {
                return this._shipBy;
            }
            set
            {
                this._shipBy = value;
            }
        }

        public DateTime? ShipDate
        {
            get
            {
                return this._shipDate;
            }
            set
            {
                this._shipDate = value;
            }
        }

        public string ShipInvoiceTemplate
        {
            get
            {
                return this._shipInvoiceTemplate;
            }
            set
            {
                this._shipInvoiceTemplate = value;
            }
        }

        public string ShipLabelComment
        {
            get
            {
                return this._shipLabelComment;
            }
            set
            {
                this._shipLabelComment = value;
            }
        }

        public decimal? Shipping
        {
            get
            {
                return this._shipping;
            }
            set
            {
                this._shipping = value;
            }
        }

        public DateTime? ShipProcessDate
        {
            get
            {
                return this._shipProcessDate;
            }
            set
            {
                this._shipProcessDate = value;
            }
        }

        public int? ShipToId
        {
            get
            {
                return this._shipToId;
            }
            set
            {
                this._shipToId = value;
            }
        }

        public bool? StagedOrderFlag
        {
            get
            {
                return this._stagedOrderFlag;
            }
            set
            {
                this._stagedOrderFlag = value;
            }
        }

        public int? StagingId
        {
            get
            {
                return this._stagingId;
            }
            set
            {
                this._stagingId = value;
            }
        }

        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this._storeId;
            }
            set
            {
                this._storeId = value;
            }
        }

        public bool? ThirdPartyShipperFlag
        {
            get
            {
                return this._thirdPartyShipperFlag;
            }
            set
            {
                this._thirdPartyShipperFlag = value;
            }
        }

        public string ThirdPartyShipperInfo
        {
            get
            {
                return this._thirdPartyShipperInfo;
            }
            set
            {
                this._thirdPartyShipperInfo = value;
            }
        }

        public string TrackingNo
        {
            get
            {
                return this._trackingNo;
            }
            set
            {
                this._trackingNo = value;
            }
        }

        public string TransactionId
        {
            get
            {
                return this._transactionId;
            }
            set
            {
                this._transactionId = value;
            }
        }

        public string WarehouseComment
        {
            get
            {
                return this._warehouseComment;
            }
            set
            {
                this._warehouseComment = value;
            }
        }
    }
}

