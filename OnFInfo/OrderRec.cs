namespace PBA.OnfInfo
{
    using System;

    public class OrderRec
    {
        private string _itemId;
        private int? _lineNo;
        private int? _orderId;
        private int? _orderSuffix;
        private int? _qtyOrdered;
        private int? _storeId;
        private int? _whseId;

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

        public int? WhseId
        {
            get
            {
                return this._whseId;
            }
            set
            {
                this._whseId = value;
            }
        }
    }
}

