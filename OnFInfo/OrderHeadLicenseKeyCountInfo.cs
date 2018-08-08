namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class OrderHeadLicenseKeyCountInfo : Info
    {
        private string mCCReferenceId;
        private string mCustomerName;
        private int? mLicenseAssignedCount;
        private int? mLicenseKeyStatus;
        private LicenseKeyLineInfo[] mLines;
        private int? mOrderId;
        private string mOrderIdShort;
        private string mOrderStatus;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private int? mQtyNoLicenseKey;
        private int? mStoreId;
        private string mStoreName;

        public OrderHeadLicenseKeyCountInfo()
        {
        }

        public OrderHeadLicenseKeyCountInfo(int? storeid, int? orderid, int? ordersuffix, string storename, DateTime? orderwhen, string orderstatus, string orderidshort, string ccreferenceid, string customername, int? licenseassignedcount, int? qtynolicensekey, int? licensekeystatus) : base(true)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mStoreName = storename;
            this.mOrderWhen = orderwhen;
            this.mOrderStatus = orderstatus;
            this.mOrderIdShort = orderidshort;
            this.mCCReferenceId = ccreferenceid;
            this.mCustomerName = customername;
            this.mLicenseAssignedCount = licenseassignedcount;
            this.mQtyNoLicenseKey = qtynolicensekey;
            this.mLicenseKeyStatus = licensekeystatus;
        }

        public string CCReferenceId
        {
            get
            {
                return this.mCCReferenceId;
            }
            set
            {
                this.mCCReferenceId = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return this.mCustomerName;
            }
            set
            {
                this.mCustomerName = value;
            }
        }

        public int? LicenseAssignedCount
        {
            get
            {
                return this.mLicenseAssignedCount;
            }
            set
            {
                this.mLicenseAssignedCount = value;
            }
        }

        public int? LicenseKeyStatus
        {
            get
            {
                return this.mLicenseKeyStatus;
            }
            set
            {
                this.mLicenseKeyStatus = value;
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

        public string OrderStatus
        {
            get
            {
                return this.mOrderStatus;
            }
            set
            {
                this.mOrderStatus = value;
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

        public int? QtyNoLicenseKey
        {
            get
            {
                return this.mQtyNoLicenseKey;
            }
            set
            {
                this.mQtyNoLicenseKey = value;
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

        public string StoreName
        {
            get
            {
                return this.mStoreName;
            }
            set
            {
                this.mStoreName = value;
            }
        }
    }
}

