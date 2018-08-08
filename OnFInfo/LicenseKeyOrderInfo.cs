namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LicenseKeyOrderInfo : Info
    {
        private string mCCReferenceId;
        private string mCustomerName;
        private string mItemId;
        private int? mLicenseAssignedCount;
        private string mLicenseKeyType;
        private int? mLicenseRequiredCount;
        private int? mLicensesToAssignCount;
        private LicenseKeyLineInfo[] mLines;
        private int? mOrderId;
        private string mOrderIdShort;
        private int? mOrderSuffix;
        private DateTime? mOrderWhen;
        private int? mSerialNumberCount;
        private string mStatus;
        private int? mStoreId;
        private string mStoreName;

        public LicenseKeyOrderInfo()
        {
        }

        public LicenseKeyOrderInfo(int? storeid, int? orderid, int? ordersuffix, string storename, DateTime? orderwhen, string status, string orderidshort, string ccreferenceid, string customername, string itemid, int? licenserequiredcount, int? licenseassignedcount, int? serialnumbercount, int? licensestoassigncount, string licensekeytype) : base(true)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mStoreName = storename;
            this.mOrderWhen = orderwhen;
            this.mStatus = status;
            this.mOrderIdShort = orderidshort;
            this.mCCReferenceId = ccreferenceid;
            this.mCustomerName = customername;
            this.mItemId = itemid;
            this.mLicenseRequiredCount = licenserequiredcount;
            this.mLicenseAssignedCount = licenseassignedcount;
            this.mSerialNumberCount = serialnumbercount;
            this.mLicensesToAssignCount = licensestoassigncount;
            this.mLicenseKeyType = licensekeytype;
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

        public string LicenseKeyType
        {
            get
            {
                return this.mLicenseKeyType;
            }
            set
            {
                this.mLicenseKeyType = value;
            }
        }

        public int? LicenseRequiredCount
        {
            get
            {
                return this.mLicenseRequiredCount;
            }
            set
            {
                this.mLicenseRequiredCount = value;
            }
        }

        public int? LicensesToAssignCount
        {
            get
            {
                return this.mLicensesToAssignCount;
            }
            set
            {
                this.mLicensesToAssignCount = value;
            }
        }

        public LicenseKeyLineInfo[] Lines
        {
            get
            {
                return this.mLines;
            }
            set
            {
                this.mLines = value;
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

        public int? SerialNumberCount
        {
            get
            {
                return this.mSerialNumberCount;
            }
            set
            {
                this.mSerialNumberCount = value;
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

