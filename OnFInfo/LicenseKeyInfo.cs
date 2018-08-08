namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LicenseKeyInfo
    {
        private DateTime? mDateAssigned;
        private DateTime? mDateLoaded;
        private string mLicenseKey;
        private string mLicenseKeyType;
        private int? mLineNo;
        private int? mOrderId;
        private int? mOrderSuffix;
        private int? mStatus;
        private int? mStoreId;

        public LicenseKeyInfo()
        {
        }

        public LicenseKeyInfo(int storeid, string licensekeytype, string licensekey, int? status, DateTime? dateloaded, DateTime? dateassigned, int? orderid, int? ordersuffix, int? lineno)
        {
            this.mStoreId = new int?(storeid);
            this.mLicenseKeyType = licensekeytype;
            this.mLicenseKey = licensekey;
            this.mStatus = status;
            this.mDateLoaded = dateloaded;
            this.mDateAssigned = dateassigned;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mLineNo = lineno;
        }

        public DateTime? DateAssigned
        {
            get
            {
                return this.mDateAssigned;
            }
            set
            {
                this.mDateAssigned = value;
            }
        }

        public DateTime? DateLoaded
        {
            get
            {
                return this.mDateLoaded;
            }
            set
            {
                this.mDateLoaded = value;
            }
        }

        public string LicenseKey
        {
            get
            {
                return this.mLicenseKey;
            }
            set
            {
                this.mLicenseKey = value;
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

        public int? LineNo
        {
            get
            {
                return this.mLineNo;
            }
            set
            {
                this.mLineNo = value;
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

        public int? Status
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
    }
}

