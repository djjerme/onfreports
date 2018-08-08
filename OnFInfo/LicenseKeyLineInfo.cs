namespace PBA.OnfInfo
{
    using System;

    [Serializable]
    public class LicenseKeyLineInfo
    {
        private string mCustomerOrderId;
        private int? mExistingSNCount;
        private int? mExpectedSNCount;
        private string mItemId;
        private string mLicenseKeyType;
        private int? mLineNo;
        private int? mNumberOfSeats;
        private int? mOrderId;
        private int? mOrderSuffix;
        private int? mQtyOrdered;
        private int? mStoreId;
        private string mUPC;
        private string mUPCDescription;
        private string mUPCText;

        public LicenseKeyLineInfo()
        {
        }

        public LicenseKeyLineInfo(int? storeid, int? orderid, int? ordersuffix, int? lineno, string itemid, int? qtyordered, string licensekeytype, int? existingsncount, int? expectedsncount, string upc, string upctext, string upcdescription, int? numberofseats, string customerorderid)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mLineNo = lineno;
            this.mItemId = itemid;
            this.mQtyOrdered = qtyordered;
            this.mLicenseKeyType = licensekeytype;
            this.mExistingSNCount = existingsncount;
            this.mExpectedSNCount = expectedsncount;
            this.mUPC = upc;
            this.mUPCText = upctext;
            this.mUPCDescription = upcdescription;
            this.mNumberOfSeats = numberofseats;
            this.mCustomerOrderId = customerorderid;
        }

        public string CustomerOrderId
        {
            get
            {
                return this.mCustomerOrderId;
            }
            set
            {
                this.mCustomerOrderId = value;
            }
        }

        public int? ExistingSNCount
        {
            get
            {
                return this.mExistingSNCount;
            }
            set
            {
                this.mExistingSNCount = value;
            }
        }

        public int? ExpectedSNCount
        {
            get
            {
                return this.mExpectedSNCount;
            }
            set
            {
                this.mExpectedSNCount = value;
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

        public int? QtyOrdered
        {
            get
            {
                return this.mQtyOrdered;
            }
            set
            {
                this.mQtyOrdered = value;
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

