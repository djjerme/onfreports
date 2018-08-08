namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class StoreProductInfo : ProductInfo
    {
        private string _firstItemId = null;
        private int? _sqn = null;
        private StoreItemList _storeItems = null;
        private UserTypeProductInfo _userTypeProduct = null;

        public string FirstItemId
        {
            get
            {
                return this._firstItemId;
            }
            set
            {
                this._firstItemId = value;
            }
        }

        public StoreItemList Items
        {
            get
            {
                return this._storeItems;
            }
            set
            {
                this._storeItems = value;
            }
        }

        public int? Sequence
        {
            get
            {
                return this._sqn;
            }
            set
            {
                this._sqn = value;
            }
        }

        public UserTypeProductInfo UserTypeProduct
        {
            get
            {
                return this._userTypeProduct;
            }
            set
            {
                this._userTypeProduct = value;
            }
        }
    }
}

