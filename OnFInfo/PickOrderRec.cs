namespace PBA.OnfInfo
{
    using System;

    public class PickOrderRec
    {
        private string _itemId;
        private int? _lineNo;
        private string _locationId;
        private int? _orderId;
        private int? _orderSuffix;
        private string _picklistInvPickCommandSql;
        private string _pickStoreCommandSql;
        private string _pickUpdateCommandSql;
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

        public string PicklistInvPickCommandSql
        {
            get
            {
                return this._picklistInvPickCommandSql;
            }
            set
            {
                this._picklistInvPickCommandSql = value;
            }
        }

        public string PickStoreCommandSql
        {
            get
            {
                return this._pickStoreCommandSql;
            }
            set
            {
                this._pickStoreCommandSql = value;
            }
        }

        public string PickUpdateCommandSql
        {
            get
            {
                return this._pickUpdateCommandSql;
            }
            set
            {
                this._pickUpdateCommandSql = value;
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

