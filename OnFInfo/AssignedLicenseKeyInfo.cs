namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class AssignedLicenseKeyInfo
    {
        private string mExternalOrderId;
        private string mItemId;
        private string mLicenseKey;
        private int? mLineNo;
        private int? mNumberOfSeats;
        private int? mOrderId;
        private int? mOrderSuffix;
        private int? mStoreId;
        private string mUPC;
        private string mUPCDescription;
        private string mUPCText;

        public AssignedLicenseKeyInfo()
        {
        }

        public AssignedLicenseKeyInfo(int? storeid, int? orderid, int? ordersuffix, string externalorderid, int? lineno, string itemid, string upc, string upctext, string upcdescription, int? numberofseats, string licensekey)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mExternalOrderId = externalorderid;
            this.mLineNo = lineno;
            this.mItemId = itemid;
            this.mUPC = upc;
            this.mUPCText = upctext;
            this.mUPCDescription = upcdescription;
            this.mNumberOfSeats = numberofseats;
            this.mLicenseKey = licensekey;
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

        public int? NumberOfSeats
        {
            get
            {
                return this.mNumberOfSeats;
            }
            set
            {
                this.mNumberOfSeats = value;
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

        public string UPC
        {
            get
            {
                return this.mUPC;
            }
            set
            {
                this.mUPC = value;
            }
        }

        public string UPCDescription
        {
            get
            {
                return this.mUPCDescription;
            }
            set
            {
                this.mUPCDescription = value;
            }
        }

        public string UPCText
        {
            get
            {
                return this.mUPCText;
            }
            set
            {
                this.mUPCText = value;
            }
        }
    }
}

