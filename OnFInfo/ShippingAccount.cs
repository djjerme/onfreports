namespace PBA.OnfInfo
{
    using System;

    public class ShippingAccount
    {
        private string _accnum;
        private int _account_id;
        private string _carrier;
        private int? _personId;
        private string _shippingName;
        private int? _storeId;

        public int account_id
        {
            get
            {
                return this._account_id;
            }
            set
            {
                this._account_id = value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return this._accnum;
            }
            set
            {
                this._accnum = value;
            }
        }

        public string Carrier
        {
            get
            {
                return this._carrier;
            }
            set
            {
                this._carrier = value;
            }
        }

        public int? personId
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

        public string ShippingName
        {
            get
            {
                return this._shippingName;
            }
            set
            {
                this._shippingName = value;
            }
        }

        public int? storeId
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
    }
}

