namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class CartInfo
    {
        private bool? _bulkOrderParentFlag;
        private int? _bulkOrderParentId;
        private string _cartError;
        private CartItemInfo[] _cartItems;
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
        private string _externalOrderType;
        private decimal? _grandTotal;
        private decimal? _handling;
        private DateTime? _lastAccessed;
        private DateTime? _needDate;
        private int? _orderFor;
        private string _orderReason;
        private string _paymentMethod;
        private int? _personId;
        private string _projectNumber;
        private int? _quoteId;
        private DateTime? _quoteStarted;
        private decimal? _salesTax;
        private string _salesTaxCounty;
        private int? _sendToAddress;
        private int? _sendToPerson;
        private string _shipAttnTo;
        private string _shipInvoiceTemplate;
        private string _shipLabelComment;
        private string _shipMethod;
        private decimal? _shipping;
        private int? _shipToId;
        private bool? _stagedOrderFlag;
        private int? _stagingId;
        private int? _storeId;
        private bool? _thirdPartyShipperFlag;
        private string _thirdPartyShipperInfo;
        private string _transactionId;
        private string _warehouseComment;

        public CartInfo()
        {
        }

        public CartInfo(int? storeId, int? quoteId, int? personId, DateTime? quoteStarted, DateTime? lastAccessed, decimal? shipping, decimal? handling, decimal? salesTax, DateTime? needDate, string shipMethod, string orderReason, string costCenter, string department, int? shipToId, int? orderFor, string shipLabelComment, string warehouseComment, int? sendToPerson, int? sendToAddress, string custOrderNo, string demographics10, string demographics20, string demographics21, string demographics22, string demographics23, string demographics30, string demographics24, string demographics25, string demographics26, string demographics27, string demographics28, string demographics29, string demographics210, string salesTaxCounty, string discountCode, string transactionId, string externalOrderType, bool? bulkOrderParentFlag, int? bulkOrderParentId, bool? thirdPartyShipperFlag, string thirdPartyShipperInfo, string paymentMethod, string shipAttnTo, string customMessage, string projectNumber, bool? stagedOrderFlag, int? stagingId, bool? cdFulfillmentFlag, int? cdQty, decimal? grandTotal, string expedite)
        {
            this._storeId = storeId;
            this._quoteId = quoteId;
            this._personId = personId;
            this._quoteStarted = quoteStarted;
            this._lastAccessed = lastAccessed;
            this._shipping = shipping;
            this._handling = handling;
            this._salesTax = salesTax;
            this._needDate = needDate;
            this._shipMethod = shipMethod;
            this._orderReason = orderReason;
            this._costCenter = costCenter;
            this._department = department;
            this._shipToId = shipToId;
            this._orderFor = orderFor;
            this._shipLabelComment = shipLabelComment;
            this._warehouseComment = warehouseComment;
            this._sendToPerson = sendToPerson;
            this._sendToAddress = sendToAddress;
            this._custOrderNo = custOrderNo;
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
            this._discountCode = discountCode;
            this._transactionId = transactionId;
            this._externalOrderType = externalOrderType;
            this._bulkOrderParentFlag = bulkOrderParentFlag;
            this._bulkOrderParentId = bulkOrderParentId;
            this._thirdPartyShipperFlag = thirdPartyShipperFlag;
            this._expedite = expedite;
            this._thirdPartyShipperInfo = thirdPartyShipperInfo;
            this._paymentMethod = paymentMethod;
            this._shipAttnTo = shipAttnTo;
            this._customMessage = customMessage;
            this._projectNumber = projectNumber;
            this._stagedOrderFlag = stagedOrderFlag;
            this._stagingId = stagingId;
            this._cdFulfillmentFlag = cdFulfillmentFlag;
            this._cdQty = cdQty;
            this._grandTotal = grandTotal;
        }

        public decimal GetExtendedInvCostTotal()
        {
            decimal num = 0M;
            if (this.CartItems != null)
            {
                foreach (CartItemInfo info in this.CartItems)
                {
                    decimal? nullable3 = info.InventoryCost * info.QtyOrdered;
                    num += nullable3.Value;
                }
            }
            return num;
        }

        public decimal GetExtendedTotal()
        {
            decimal num = 0M;
            if (this.CartItems != null)
            {
                foreach (CartItemInfo info in this.CartItems)
                {
                    num += info.ExtendedPrice.Value;
                }
            }
            return num;
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

        public string cartError
        {
            get
            {
                return this._cartError;
            }
            set
            {
                this._cartError = value;
            }
        }

        public CartItemInfo[] CartItems
        {
            get
            {
                return this._cartItems;
            }
            set
            {
                this._cartItems = value;
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

        public decimal? grandTotal
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

        public DateTime? LastAccessed
        {
            get
            {
                return this._lastAccessed;
            }
            set
            {
                this._lastAccessed = value;
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

        public int? QuoteId
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

        public DateTime? QuoteStarted
        {
            get
            {
                return this._quoteStarted;
            }
            set
            {
                this._quoteStarted = value;
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

        public string ShipMethod
        {
            get
            {
                return this._shipMethod;
            }
            set
            {
                this._shipMethod = value;
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

