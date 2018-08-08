namespace PBA.OnfInfo
{
    using System;

    public class NotificationOrderLineInfo
    {
        private string mDocumentationURL;
        private string mItemDescription;
        private string mItemId;
        private int? mLicenseSeatCount;
        private int? mLicenseTerm;
        private int? mLineNo;
        private decimal? mOnFCost;
        private int? mOrderId;
        private int? mOrderSuffix;
        private int? mQtyOrdered;
        private int? mQtyShipped;
        private string mSerialNumber;
        private bool? mStampDocument;
        private int? mStoreId;
        private decimal? mUnitPrice;
        private string mURL;

        public string DocumentationURL
        {
            get
            {
                return this.mDocumentationURL;
            }
            set
            {
                this.mDocumentationURL = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return this.mItemDescription;
            }
            set
            {
                this.mItemDescription = value;
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

        public int? LicenseSeatCount
        {
            get
            {
                int? mLicenseSeatCount = this.mLicenseSeatCount;
                if (!mLicenseSeatCount.HasValue)
                {
                    try
                    {
                        mLicenseSeatCount = new int?(Convert.ToInt32(this.mItemId.Substring(7, 3)));
                    }
                    catch (Exception)
                    {
                    }
                }
                return mLicenseSeatCount;
            }
            set
            {
                this.mLicenseSeatCount = value;
            }
        }

        public int? LicenseTerm
        {
            get
            {
                int? mLicenseTerm = this.mLicenseTerm;
                if (!mLicenseTerm.HasValue)
                {
                    try
                    {
                        mLicenseTerm = new int?(Convert.ToInt32(this.mItemId.Substring(6, 1)));
                    }
                    catch (Exception)
                    {
                    }
                }
                return mLicenseTerm;
            }
            set
            {
                this.mLicenseTerm = value;
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

        public decimal? OnFCost
        {
            get
            {
                return this.mOnFCost;
            }
            set
            {
                this.mOnFCost = value;
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

        public int? QtyShipped
        {
            get
            {
                return this.mQtyShipped;
            }
            set
            {
                this.mQtyShipped = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return this.mSerialNumber;
            }
            set
            {
                this.mSerialNumber = value;
            }
        }

        public bool? StampDocument
        {
            get
            {
                return this.mStampDocument;
            }
            set
            {
                this.mStampDocument = value;
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

        public decimal? UnitPrice
        {
            get
            {
                return this.mUnitPrice;
            }
            set
            {
                this.mUnitPrice = value;
            }
        }

        public string URL
        {
            get
            {
                return this.mURL;
            }
            set
            {
                this.mURL = value;
            }
        }
    }
}

