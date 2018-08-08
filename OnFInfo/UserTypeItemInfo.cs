namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class UserTypeItemInfo
    {
        private string _itemId;
        private decimal? _salePrice;
        private int? _storeId;
        private decimal? _unitPrice;
        private string _userType;
        private int? _userTypeItemId;

        public UserTypeItemInfo()
        {
        }

        public UserTypeItemInfo(int? userTypeItemId, int? storeId, string itemId, string userType, decimal? unitPrice, decimal? salePrice)
        {
            this._userTypeItemId = userTypeItemId;
            this._storeId = storeId;
            this._itemId = itemId;
            this._userType = userType;
            this._unitPrice = unitPrice;
            this._salePrice = salePrice;
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

        public int? UserTypeItemId
        {
            get
            {
                return this._userTypeItemId;
            }
            set
            {
                this._userTypeItemId = value;
            }
        }
    }
}

