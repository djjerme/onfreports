namespace PBA.OnfInfo
{
    using System;

    public class OrderDropoutInfo : Info
    {
        private string mAddress1;
        private string mAddress2;
        private string mCity;
        private string mCustomerOrderNumber;
        private string mEmail;
        private string mExceptionStatus;
        private int? mExceptionStatusCode;
        private string mExternalOrderId;
        private string mFullName;
        private string mItemId;
        private int? mOrderId;
        private string mOrderIdShort;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private string mProductName;
        private string mState;
        private string mStatus;
        private int? mStoreId;
        private string mZip;

        public OrderDropoutInfo()
        {
        }

        public OrderDropoutInfo(int? storeid, int? orderid, int? ordersuffix, DateTime? orderwhen, string status, string externalorderid, string exceptionstatus, int? exceptionstatuscode, string orderidshort, string itemid, string productname, string customerordernumber, string fullname, string address1, string address2, string city, string state, string zip, string email) : base(false)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mOrderWhen = orderwhen;
            this.mStatus = status;
            this.mExternalOrderId = externalorderid;
            this.mExceptionStatus = exceptionstatus;
            this.mExceptionStatusCode = exceptionstatuscode;
            this.mOrderIdShort = orderidshort;
            this.mItemId = itemid;
            this.mProductName = productname;
            this.mCustomerOrderNumber = customerordernumber;
            this.mFullName = fullname;
            this.mAddress1 = address1;
            this.mAddress2 = address2;
            this.mCity = city;
            this.mState = state;
            this.mZip = zip;
            this.mEmail = email;
        }

        public string Address1
        {
            get
            {
                return this.mAddress1;
            }
            set
            {
                this.mAddress1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this.mAddress2;
            }
            set
            {
                this.mAddress2 = value;
            }
        }

        public string City
        {
            get
            {
                return this.mCity;
            }
            set
            {
                this.mCity = value;
            }
        }

        public string CustomerOrderNumber
        {
            get
            {
                return this.mCustomerOrderNumber;
            }
            set
            {
                this.mCustomerOrderNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.mEmail;
            }
            set
            {
                this.mEmail = value;
            }
        }

        public string ExceptionStatus
        {
            get
            {
                return this.mExceptionStatus;
            }
            set
            {
                this.mExceptionStatus = value;
            }
        }

        public int? ExceptionStatusCode
        {
            get
            {
                return this.mExceptionStatusCode;
            }
            set
            {
                this.mExceptionStatusCode = value;
            }
        }

        public string ExternalOrderId
        {
            get
            {
                return this.mExternalOrderId;
            }
            set
            {
                this.mExternalOrderId = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.mFullName;
            }
            set
            {
                this.mFullName = value;
            }
        }

        public string ItemId
        {
            get
            {
                return this.mItemId;
            }
            set
            {
                this.mItemId = value;
            }
        }

        public int? OrderId
        {
            get
            {
                return this.mOrderId;
            }
            set
            {
                this.mOrderId = value;
            }
        }

        public string OrderIdShort
        {
            get
            {
                return this.mOrderIdShort;
            }
            set
            {
                this.mOrderIdShort = value;
            }
        }

        public int? OrderSuffix
        {
            get
            {
                return this.mOrderSuffix;
            }
            set
            {
                this.mOrderSuffix = value;
            }
        }

        public DateTime? OrderWhen
        {
            get
            {
                return this.mOrderWhen;
            }
            set
            {
                this.mOrderWhen = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.mProductName;
            }
            set
            {
                this.mProductName = value;
            }
        }

        public string State
        {
            get
            {
                return this.mState;
            }
            set
            {
                this.mState = value;
            }
        }

        public string Status
        {
            get
            {
                return this.mStatus;
            }
            set
            {
                this.mStatus = value;
            }
        }

        public int? StoreId
        {
            get
            {
                return this.mStoreId;
            }
            set
            {
                this.mStoreId = value;
            }
        }

        public string Zip
        {
            get
            {
                return this.mZip;
            }
            set
            {
                this.mZip = value;
            }
        }
    }
}

