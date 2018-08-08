namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class UserTypeProductInfo
    {
        private bool? _accessFlag;
        private bool? _addtocartFlag;
        private int? _maxOrderQty;
        private int? _minOrderQty;
        private int? _productId;
        private int? _storeId;
        private string _userType;

        public UserTypeProductInfo()
        {
        }

        public UserTypeProductInfo(int? storeId, int? productId, string userType, int? maxOrderQty, int? minOrderQty, bool? accessFlag, bool? addtocartFlag)
        {
            this._storeId = storeId;
            this._productId = productId;
            this._userType = userType;
            this._maxOrderQty = maxOrderQty;
            this._minOrderQty = minOrderQty;
            this._accessFlag = accessFlag;
            this._addtocartFlag = addtocartFlag;
        }

        public bool? AccessFlag
        {
            get
            {
                return this._accessFlag;
            }
            set
            {
                this._accessFlag = value;
            }
        }

        public bool? AddtocartFlag
        {
            get
            {
                return this._addtocartFlag;
            }
            set
            {
                this._addtocartFlag = value;
            }
        }

        public int? MaxOrderQty
        {
            get
            {
                return this._maxOrderQty;
            }
            set
            {
                this._maxOrderQty = value;
            }
        }

        public int? MinOrderQty
        {
            get
            {
                return this._minOrderQty;
            }
            set
            {
                this._minOrderQty = value;
            }
        }

        public int? ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
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

