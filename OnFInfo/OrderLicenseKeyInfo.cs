namespace PBA.OnfInfo
{
    using System;

    public class OrderLicenseKeyInfo : Info
    {
        private string mItemId;
        private int? mLineNo;
        private int? mOrderId;
        private int? mOrderSuffix;
        private string mProductName;
        private int? mQtyOrdered;
        private int? mRowNumber;
        private int? mSequence;
        private string mSerialNumber;
        private int? mStoreId;

        public OrderLicenseKeyInfo()
        {
        }

        public OrderLicenseKeyInfo(int? storeid, int? orderid, int? ordersuffix, int? lineno, string itemid, string productname, int? qtyordered, int? sequence, string serialnumber, int? rownumber) : base(false)
        {
            this.mStoreId = storeid;
            this.mOrderId = orderid;
            this.mOrderSuffix = ordersuffix;
            this.mLineNo = lineno;
            this.mItemId = itemid;
            this.mProductName = productname;
            this.mQtyOrdered = qtyordered;
            this.mSequence = sequence;
            this.mSerialNumber = serialnumber;
            this.mRowNumber = rownumber;
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

        public int? RowNumber
        {
            get
            {
                return this.mRowNumber;
            }
            set
            {
                this.mRowNumber = value;
            }
        }

        public int? Sequence
        {
            get
            {
                return this.mSequence;
            }
            set
            {
                this.mSequence = value;
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

