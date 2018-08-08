namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class CartItemInfo
    {
        private bool? _cdFulfillmentFlag;
        private string _custom1;
        private string _custom2;
        private string _custom3;
        private string _customContent;
        private string _dateField;
        private string _defaultContent;
        private decimal? _discountAmount;
        private string _discountCode;
        private int? _discountDept;
        private decimal? _extendedPrice;
        private decimal? _inventoryCost;
        private PBA.OnfInfo.ItemInfo _item;
        private string _itemContent;
        private string _itemId;
        private decimal? _lineFee;
        private int? _lineNo;
        private decimal? _OnfCost;
        private ProductInfo _product;
        private int? _qtyAvailable;
        private int? _qtyOrdered;
        private int? _quoteId;
        private decimal? _shippingFee;
        private int? _storeId;
        private decimal? _unitPrice;

        public CartItemInfo()
        {
        }

        public CartItemInfo(int? storeId, int? quoteId, int? lineNo, string itemId, int? qtyOrdered, decimal? unitPrice, decimal? lineFee, decimal? shippingFee, string discountCode, int? discountDept, decimal? discountAmount, string itemContent, string defaultContent, string customContent, string dateField, decimal? inventoryCost, string custom1, string custom2, string custom3, bool? cdFulfillmentFlag)
        {
            this._storeId = storeId;
            this._quoteId = quoteId;
            this._lineNo = lineNo;
            this._itemId = itemId;
            this._qtyOrdered = qtyOrdered;
            this._unitPrice = unitPrice;
            this._lineFee = lineFee;
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
            this._cdFulfillmentFlag = cdFulfillmentFlag;
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

        public decimal? DiscountAmount
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

        public PBA.OnfInfo.ItemInfo Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
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

        public ProductInfo Product
        {
            get
            {
                return this._product;
            }
            set
            {
                this._product = value;
            }
        }

        public int? QtyAvailable
        {
            get
            {
                return this._qtyAvailable;
            }
            set
            {
                this._qtyAvailable = value;
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

