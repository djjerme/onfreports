namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class FulfillmentTypePricingInfo
    {
        private int? _fulfillmentTypeId;
        private string _itemId;
        private decimal? _salePrice;
        private int? _storeId;
        private int? _tableId;
        private decimal? _unitPrice;
        private string _userType;

        public FulfillmentTypePricingInfo()
        {
        }

        public FulfillmentTypePricingInfo(int? tableId, int? storeId, string itemId, string userType, int? fulfillmentTypeId, decimal? unitPrice, decimal? salePrice)
        {
            this._tableId = tableId;
            this._storeId = storeId;
            this._itemId = itemId;
            this._userType = userType;
            this._fulfillmentTypeId = fulfillmentTypeId;
            this._unitPrice = unitPrice;
            this._salePrice = salePrice;
        }

        public int? FulfillmentTypeId
        {
            get
            {
                return this._fulfillmentTypeId;
            }
            set
            {
                this._fulfillmentTypeId = value;
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

        public decimal? SalePrice
        {
            get
            {
                return this._salePrice;
            }
            set
            {
                this._salePrice = value;
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

        public int? TableId
        {
            get
            {
                return this._tableId;
            }
            set
            {
                this._tableId = value;
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

        public string UserType
        {
            get
            {
                return this._userType;
            }
            set
            {
                this._userType = value;
            }
        }
    }
}

