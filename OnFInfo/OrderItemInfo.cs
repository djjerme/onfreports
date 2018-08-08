namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class OrderItemInfo
    {
        private bool? _backOrderFlag;
        private bool? _ccrFlag;
        private bool? _cdFulfillmentFlag;
        private string _custom1;
        private string _custom2;
        private string _custom3;
        private string _customContent;
        private string _custOrderLineNo;
        private string _dateField;
        private string _defaultContent;
        private string _deptProduct;
        private double? _discountAmount;
        private string _discountCode;
        private int? _discountDept;
        private decimal? _extendedPrice;
        private decimal? _inventoryCost;
        private string _itemContent;
        private string _itemId;
        private decimal? _lineFee;
        private int? _lineNo;
        private decimal? _OnfCost;
        private int? _orderId;
        private int? _orderSuffix;
        private bool? _printOnDemandFlag;
        private bool? _processedFlag;
        private string _productName;
        private int? _qtyOrdered;
        private int? _qtyPicked;
        private int? _qtyShipped;
        private decimal? _shippingFee;
        private int? _storeId;
        private decimal? _unitPrice;

        public OrderItemInfo()
        {
        }

        public OrderItemInfo(int? storeId, int? orderId, int? orderSuffix, int? lineNo, string itemId, int? qtyOrdered, int? qtyPicked, int? qtyShipped, decimal? unitPrice, decimal? lineFee, string deptProduct, decimal? shippingFee, string discountCode, int? discountDept, double? discountAmount, string itemContent, string defaultContent, string customContent, string dateField, decimal? inventoryCost, string custom1, string custom2, string custom3, string custOrderLineNo, bool? processedFlag, bool? cdFulfillmentFlag, bool? printOnDemandFlag)
        {
            this._storeId = storeId;
            this._orderId = orderId;
            this._orderSuffix = orderSuffix;
            this._lineNo = lineNo;
            this._itemId = itemId;
            this._qtyOrdered = qtyOrdered;
            this._qtyPicked = qtyPicked;
            this._qtyShipped = qtyShipped;
            this._unitPrice = unitPrice;
            this._lineFee = lineFee;
            this._deptProduct = deptProduct;
            this._shippingFee = shippingFee;
            this._discountCode = discountCode;
            this._discountDept = discountDept;
            this._discountAmount = discountAmount;
            this._itemContent = itemContent;
            this._defaultContent = defaultContent;
            this._customContent = customContent;
            this._dateField = dateField;
            this._inventoryCost = inventoryCost;
            this._custom1 = custom1;
            this._custom2 = custom2;
            this._custom3 = custom3;
            this._custOrderLineNo = custOrderLineNo;
            this._processedFlag = processedFlag;
            this._cdFulfillmentFlag = cdFulfillmentFlag;
            this._printOnDemandFlag = printOnDemandFlag;
        }

        public bool? backOrderFlag
        {
            get
            {
                return this._backOrderFlag;
            }
            set
            {
                this._backOrderFlag = value;
            }
        }

        public bool? ccrFlag
        {
            get
            {
                return this._ccrFlag;
            }
            set
            {
                this._ccrFlag = value;
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

        public string Custom1
        {
            get
            {
                return this._custom1;
            }
            set
            {
                this._custom1 = value;
            }
        }

        public string Custom2
        {
            get
            {
                return this._custom2;
            }
            set
            {
                this._custom2 = value;
            }
        }

        public string Custom3
        {
            get
            {
                return this._custom3;
            }
            set
            {
                this._custom3 = value;
            }
        }

        public string CustomContent
        {
            get
            {
                return this._customContent;
            }
            set
            {
                this._customContent = value;
            }
        }

        public string CustOrderLineNo
        {
            get
            {
                return this._custOrderLineNo;
            }
            set
            {
                this._custOrderLineNo = value;
            }
        }

        public string DateField
        {
            get
            {
                return this._dateField;
            }
            set
            {
                this._dateField = value;
            }
        }

        public string DefaultContent
        {
            get
            {
                return this._defaultContent;
            }
            set
            {
                this._defaultContent = value;
            }
        }

        public string DeptProduct
        {
            get
            {
                return this._deptProduct;
            }
            set
            {
                this._deptProduct = value;
            }
        }

        public double? DiscountAmount
        {
            get
            {
                return this._discountAmount;
            }
            set
            {
                this._discountAmount = value;
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

        public int? DiscountDept
        {
            get
            {
                return this._discountDept;
            }
            set
            {
                this._discountDept = value;
            }
        }

        public decimal? ExtendedPrice
        {
            get
            {
                return this._extendedPrice;
            }
            set
            {
                this._extendedPrice = value;
            }
        }

        public decimal? InventoryCost
        {
            get
            {
                return this._inventoryCost;
            }
            set
            {
                this._inventoryCost = value;
            }
        }

        public string ItemContent
        {
            get
            {
                return this._itemContent;
            }
            set
            {
                this._itemContent = value;
            }
        }

        public string ItemId
        {
            get
            {
                return this._itemId;
            }
            set
            {
                this._itemId = value;
            }
        }

        public decimal? LineFee
        {
            get
            {
                return this._lineFee;
            }
            set
            {
                this._lineFee = value;
            }
        }

        public int? LineNo
        {
            get
            {
                return this._lineNo;
            }
            set
            {
                this._lineNo = value;
            }
        }

        public decimal? OnfCost
        {
            get
            {
                return this._OnfCost;
            }
            set
            {
                this._OnfCost = value;
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

        public bool? printOnDemandFlag
        {
            get
            {
                return this._printOnDemandFlag;
            }
            set
            {
                this._printOnDemandFlag = value;
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

        public string ProductName
        {
            get
            {
                return this._productName;
            }
            set
            {
                this._productName = value;
            }
        }

        public int? QtyOrdered
        {
            get
            {
                return this._qtyOrdered;
            }
            set
            {
                this._qtyOrdered = value;
            }
        }

        public int? QtyPicked
        {
            get
            {
                return this._qtyPicked;
            }
            set
            {
                this._qtyPicked = value;
            }
        }

        public int? QtyShipped
        {
            get
            {
                return this._qtyShipped;
            }
            set
            {
                this._qtyShipped = value;
            }
        }

        public decimal? ShippingFee
        {
            get
            {
                return this._shippingFee;
            }
            set
            {
                this._shippingFee = value;
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

        public decimal? UnitPrice
        {
            get
            {
                return this._unitPrice;
            }
            set
            {
                this._unitPrice = value;
            }
        }
    }
}

