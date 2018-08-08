namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class WarehousePrintInvoiceLine
    {
        private string _attribute1Label;
        private string _attribute1Value;
        private string _attribute2Label;
        private string _attribute2Value;
        private string _attribute3Label;
        private string _attribute3Value;
        private int? _backOrderCount;
        private string _custom1;
        private string _custom2;
        private int? _insufficientStock;
        private string _itemId;
        private int? _lineNo;
        private string _locationId;
        private string _name;
        private int? _orderId;
        private int? _orderSuffix;
        private int? _pickCount;
        private int? _qtyOnHand;
        private int? _qtyOrdered;
        private int? _qtyPicked;
        private string _shortDesc;
        private int? _storeId;
        private decimal? _unitPrice;

        public string Attribute1Label
        {
            get
            {
                return this._attribute1Label;
            }
            set
            {
                this._attribute1Label = value;
            }
        }

        public string Attribute1Value
        {
            get
            {
                return this._attribute1Value;
            }
            set
            {
                this._attribute1Value = value;
            }
        }

        public string Attribute2Label
        {
            get
            {
                return this._attribute2Label;
            }
            set
            {
                this._attribute2Label = value;
            }
        }

        public string Attribute2Value
        {
            get
            {
                return this._attribute2Value;
            }
            set
            {
                this._attribute2Value = value;
            }
        }

        public string Attribute3Label
        {
            get
            {
                return this._attribute3Label;
            }
            set
            {
                this._attribute3Label = value;
            }
        }

        public string Attribute3Value
        {
            get
            {
                return this._attribute3Value;
            }
            set
            {
                this._attribute3Value = value;
            }
        }

        public int? BackOrderCount
        {
            get
            {
                return this._backOrderCount;
            }
            set
            {
                this._backOrderCount = value;
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

        public int? InsufficientStock
        {
            get
            {
                return this._insufficientStock;
            }
            set
            {
                this._insufficientStock = value;
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

        public string LocationId
        {
            get
            {
                return this._locationId;
            }
            set
            {
                this._locationId = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
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

        public int? PickCount
        {
            get
            {
                return this._pickCount;
            }
            set
            {
                this._pickCount = value;
            }
        }

        public int? QtyOnHand
        {
            get
            {
                return this._qtyOnHand;
            }
            set
            {
                this._qtyOnHand = value;
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

        public string ShortDesc
        {
            get
            {
                return this._shortDesc;
            }
            set
            {
                this._shortDesc = value;
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

